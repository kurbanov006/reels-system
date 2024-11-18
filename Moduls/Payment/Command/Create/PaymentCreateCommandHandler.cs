using MediatR;

public class PaymentCreateCommandHandler(IPaymentRepository repository) : IRequestHandler<CreatePaymentInfo, Result<bool>>
{
    public async Task<Result<bool>> Handle(CreatePaymentInfo request, CancellationToken cancellationToken)
    {
        if (request.BasePaymentInfo.Amount <= 0)
            return Result<bool>.Fail(Error.BadRequest("Payment amount must be greater than zero."));

        int res = await repository.CreateAsync(request.ToCreate());
        return res > 0
        ? Result<bool>.Success(true)
        : Result<bool>.Fail(Error.BadRequest());
    }
}