using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/categories")]
public class CategoryCommandController(ISender sender) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCategoryInfo category)
    {
        Result<bool> res = await sender.Send(category);
        return res.IsSuccess == false
        ? BadRequest(ApiResponse<bool>.Fail(null, false))
        : Ok(ApiResponse<bool>.Success(null, true));
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCategoryInfo category)
    {
        Result<bool> res = await sender.Send(category);
        return res.IsSuccess == false
        ? BadRequest(ApiResponse<bool>.Fail(null, false))
        : Ok(ApiResponse<bool>.Success(null, true));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeleteCategory user = new DeleteCategory(id);

        Result<bool> res = await sender.Send(user);
        return res.IsSuccess == false
        ? BadRequest(ApiResponse<bool>.Fail(null, false))
        : Ok(ApiResponse<bool>.Success(null, true));
    }
}