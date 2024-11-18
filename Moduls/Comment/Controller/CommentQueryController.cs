using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/comments/")]
public class CommentQueryController(ISender sender) : ControllerBase
{
     [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] CommentFilter filter)
    {
        Result<PaginationResponse<IQueryable<ReadCommentInfo>>>? res = await sender.Send(filter);
        if (res is null)
            return NotFound(ApiResponse<Result<PaginationResponse<IQueryable<ReadCommentInfo>>>>.Fail(null, null!));
        return Ok(ApiResponse<Result<PaginationResponse<IQueryable<ReadCommentInfo>>>>.Success(null, res));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdComment getById = new GetByIdComment(id);
        Result<ReadCommentInfo> res = await sender.Send(getById);
        if (res is null)
            return NotFound(ApiResponse<ReadCommentInfo>.Fail(null, default));
        return Ok(ApiResponse<Result<ReadCommentInfo>>.Fail(null, res));
    }
}