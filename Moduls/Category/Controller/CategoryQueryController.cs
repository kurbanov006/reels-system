using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/categories")]
public class CategoryQueryController(ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] CategoryFilter filter)
    {
        Result<PaginationResponse<IQueryable<ReadCategoryInfo>>>? res = await sender.Send(filter);
        if (res is null)
            return NotFound(ApiResponse<Result<PaginationResponse<IQueryable<ReadCategoryInfo>>>>.Fail(null, null!));
        return Ok(ApiResponse<Result<PaginationResponse<IQueryable<ReadCategoryInfo>>>>.Success(null, res));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdCategory getById = new GetByIdCategory(id);
        Result<ReadCategoryInfo> res = await sender.Send(getById);
        if (res is null)
            return NotFound(ApiResponse<ReadCategoryInfo>.Fail(null, default));
        return Ok(ApiResponse<Result<ReadCategoryInfo>>.Fail(null, res));
    }
}