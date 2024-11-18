using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/users/")]
public class UserQueryController(ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] UserFilter filter)
    {
        Result<PaginationResponse<IQueryable<ReadUserInfo>>>? res = await sender.Send(filter);
        if (res is null)
            return NotFound(ApiResponse<Result<PaginationResponse<IQueryable<ReadUserInfo>>>>.Fail(null, null!));
        return Ok(ApiResponse<Result<PaginationResponse<IQueryable<ReadUserInfo>>>>.Success(null, res));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetById getById = new GetById(id);
        Result<ReadUserInfo> res = await sender.Send(getById);
        if (res is null)
            return NotFound(ApiResponse<ReadUserInfo>.Fail(null, default));
        return Ok(ApiResponse<Result<ReadUserInfo>>.Fail(null, res));
    }
}