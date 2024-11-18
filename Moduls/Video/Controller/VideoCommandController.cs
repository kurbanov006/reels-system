using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/videos")]
public class VideoCommandController(ISender sender) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromForm] CreateVideoInfo video)
    {
        Result<bool> res = await sender.Send(video);
        return res == Result<bool>.Success(true)
        ? Ok("Успешно создано видео")
        : BadRequest("Ne sozdano");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int delete)
    {
        DeleteVideo video = new DeleteVideo(delete);

        Result<bool> res = await sender.Send(video);
        return res.IsSuccess == false
        ? BadRequest(ApiResponse<bool>.Fail(null, false))
        : Ok(ApiResponse<bool>.Success(null, true));
    }
}