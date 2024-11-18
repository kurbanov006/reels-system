using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/users")]
public class UserCommandController(ISender sender) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserInfo user)
    {
        Result<bool> res = await sender.Send(user);
        return res.IsSuccess == false
        ? BadRequest(ApiResponse<bool>.Fail(null, false))
        : Ok(ApiResponse<bool>.Success(null, true));
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateUserInfo user)
    {
        Result<bool> res = await sender.Send(user);
        return res.IsSuccess == false
        ? BadRequest(ApiResponse<bool>.Fail(null, false))
        : Ok(ApiResponse<bool>.Success(null, true));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeleteUserInfo user = new DeleteUserInfo(id);

        Result<bool> res = await sender.Send(user);
        return res.IsSuccess == false
        ? BadRequest(ApiResponse<bool>.Fail(null, false))
        : Ok(ApiResponse<bool>.Success(null, true));
    }
}