using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/payments")]
public class PaymentQueryController(ISender sender) : ControllerBase
{
     [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] PaymentFilter filter)
    {
        Result<PaginationResponse<IQueryable<ReadPaymentInfo>>>? res = await sender.Send(filter);
        if (res is null)
            return NotFound(ApiResponse<Result<PaginationResponse<IQueryable<ReadPaymentInfo>>>>.Fail(null, null!));
        return Ok(ApiResponse<Result<PaginationResponse<IQueryable<ReadPaymentInfo>>>>.Success(null, res));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdPayment getById = new GetByIdPayment(id);
        Result<ReadPaymentInfo> res = await sender.Send(getById);
        if (res is null)
            return NotFound(ApiResponse<ReadPaymentInfo>.Fail(null, default));
        return Ok(ApiResponse<Result<ReadPaymentInfo>>.Fail(null, res));
    }
}