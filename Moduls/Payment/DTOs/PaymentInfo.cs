using MediatR;

public readonly record struct CreatePaymentInfo(
    BasePaymentInfo BasePaymentInfo
) : IRequest<Result<bool>>;

public readonly record struct UpdatePaymentInfo(
    int Id,
    BasePaymentInfo BasePaymentInfo
) : IRequest<Result<bool>>;

public readonly record struct ReadPaymentInfo(
    int Id,
    BasePaymentInfo BasePaymentInfo,
    DateTime CreatedAt
);