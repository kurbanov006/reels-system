using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/comment")]
public class CommentController(ISender sender) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCommentInfo comment)
    {
        Result<bool> res = await sender.Send(comment);
        return res.IsSuccess == false
        ? BadRequest(ApiResponse<bool>.Fail(null, false))
        : Ok(ApiResponse<bool>.Success(null, true));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeleteComment user = new DeleteComment(id);

        Result<bool> res = await sender.Send(user);
        return res.IsSuccess == false
        ? BadRequest(ApiResponse<bool>.Fail(null, false))
        : Ok(ApiResponse<bool>.Success(null, true));
    }
}