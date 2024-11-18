using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/payments")]
public class PaymentCommandController(ISender sender) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePaymentInfo payment)
    {
        Result<bool> res = await sender.Send(payment);
        return res.IsSuccess == false
        ? BadRequest(ApiResponse<bool>.Fail(null, false))
        : Ok(ApiResponse<bool>.Success(null, true));
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdatePaymentInfo payment)
    {
        Result<bool> res = await sender.Send(payment);
        return res.IsSuccess == false
        ? BadRequest(ApiResponse<bool>.Fail(null, false))
        : Ok(ApiResponse<bool>.Success(null, true));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletePayment user = new DeletePayment(id);

        Result<bool> res = await sender.Send(user);
        return res.IsSuccess == false
        ? BadRequest(ApiResponse<bool>.Fail(null, false))
        : Ok(ApiResponse<bool>.Success(null, true));
    }
}