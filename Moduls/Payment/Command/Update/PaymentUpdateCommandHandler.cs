using MediatR;

public class PaymentUpdateCommandHandler(IPaymentRepository repository) : IRequestHandler<UpdatePaymentInfo, Result<bool>>
{
    public async Task<Result<bool>> Handle(UpdatePaymentInfo request, CancellationToken cancellationToken)
    {
        Payment? payment = await repository.GetByIdAsync(request.Id);
        if (payment is null)
            return Result<bool>.Fail(Error.NotFound());

        payment.ToUpdate(request);
        int res = await repository.UpdateAsync(payment);
        return res > 0
        ? Result<bool>.Success(true)
        : Result<bool>.Fail(Error.BadRequest());
    }
}