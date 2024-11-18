using MediatR;

public class GetByIdPaymentQueryHandler(IPaymentRepository repository) : IRequestHandler<GetByIdPayment, Result<ReadPaymentInfo>>
{
    public async Task<Result<ReadPaymentInfo>> Handle(GetByIdPayment request, CancellationToken cancellationToken)
    {
        Payment? payment = await repository.GetByIdAsync(request.Id);
        // if (payment is not null)
        //     if (payment.IsDeleted)
        //         return Result<ReadPaymentInfo>.Fail(Error.NotFound());

        if (payment is null)
            return Result<ReadPaymentInfo>.Fail(Error.NotFound());

        return Result<ReadPaymentInfo>.Success(payment.ToRead());
    }
}


public record GetByIdPayment(int Id) : IRequest<Result<ReadPaymentInfo>>;