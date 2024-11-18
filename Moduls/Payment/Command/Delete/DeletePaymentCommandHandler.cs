using MediatR;

public class DeletePaymentCommandHandler(IPaymentRepository repository) : IRequestHandler<DeletePayment, Result<bool>>
{
    public async Task<Result<bool>> Handle(DeletePayment request, CancellationToken cancellationToken)
    {
        Payment? payment = await repository.GetByIdAsync(request.Id);
        if (payment is null)
            return Result<bool>.Fail(Error.NotFound());

        payment.ToDelete();
        int res = await repository.UpdateAsync(payment);
        return res > 0
        ? Result<bool>.Success(true)
        : Result<bool>.Fail(Error.BadRequest());
    }
}



public record DeletePayment(int Id) : IRequest<Result<bool>>;