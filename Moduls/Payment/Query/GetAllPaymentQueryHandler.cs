using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetAllPaymentQueryHandler(IPaymentRepository repository)
 : IRequestHandler<PaymentFilter, Result<PaginationResponse<IQueryable<ReadPaymentInfo>>>>
{
    public async Task<Result<PaginationResponse<IQueryable<ReadPaymentInfo>>>> Handle(PaymentFilter request, CancellationToken cancellationToken)
    {
        IQueryable<Payment> payments = await repository.GetAllAsync();

        if (payments is null)
            return Result<PaginationResponse<IQueryable<ReadPaymentInfo>>>.Fail(Error.NotFound());

        IQueryable<ReadPaymentInfo> readPayments = payments
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .Where(x => !x.IsDeleted)
            .Select(x => x.ToRead());

        int count = await readPayments.CountAsync();

        PaginationResponse<IQueryable<ReadPaymentInfo>> response =
        PaginationResponse<IQueryable<ReadPaymentInfo>>.Create(request.PageNumber, request.PageSize, count, readPayments);

        return Result<PaginationResponse<IQueryable<ReadPaymentInfo>>>.Success(response);
    }
}