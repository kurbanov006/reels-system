using System.ComponentModel;
using MediatR;

public record PaymentFilter : BaseFilter, IRequest<Result<PaginationResponse<IQueryable<ReadPaymentInfo>>>>
{

}