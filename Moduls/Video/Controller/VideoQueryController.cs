using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/videos")]
public class VideoQueryController(ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] VideoFilter filter)
    {
        Result<PaginationResponse<IQueryable<ReadVideoInfo>>>? res = await sender.Send(filter);
        if (res is null)
            return NotFound(ApiResponse<Result<PaginationResponse<IQueryable<ReadVideoInfo>>>>.Fail(null, null!));
        return Ok(ApiResponse<Result<PaginationResponse<IQueryable<ReadVideoInfo>>>>.Success(null, res));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdVideo getById = new GetByIdVideo(id);
        Result<ReadVideoInfo> res = await sender.Send(getById);
        if (res is null)
            return NotFound(ApiResponse<ReadVideoInfo>.Fail(null, default));
        return Ok(ApiResponse<Result<ReadVideoInfo>>.Fail(null, res));
    }
    [HttpGet("comment{id}")]
    public async Task<IActionResult> GetVideoAndComment([FromRoute] int id)
    {
        IdVideoAndComments getById = new IdVideoAndComments(id);
        Result<VideoAndComments> res = await sender.Send(getById);
        if (res is null)
            return NotFound(ApiResponse<VideoAndComments>.Fail(null, default));
        return Ok(ApiResponse<Result<VideoAndComments>>.Fail(null, res));
    }

    [HttpGet]
    public async Task<IActionResult> SearchVideos([FromQuery] string search)
    {
        SearchVideo searchVideo = new SearchVideo(search);
        Result<IQueryable<VideoSearch>> res = await sender.Send(searchVideo);
        return res is null
        ? NotFound("Not found")
        : Ok(res);
    }
}