public static class PaymentMapping
{
    public static Payment ToCreate(this CreatePaymentInfo payment)
    {
        return new Payment()
        {
            UserId = payment.BasePaymentInfo.UserId,
            VideoId = payment.BasePaymentInfo.VideoId,
            Amount = payment.BasePaymentInfo.Amount
        };
    }

    public static Payment ToUpdate(this Payment payment, UpdatePaymentInfo updatePayment)
    {
        payment.Amount = updatePayment.BasePaymentInfo.Amount;
        payment.UserId = updatePayment.BasePaymentInfo.UserId;
        payment.VideoId = updatePayment.BasePaymentInfo.VideoId;
        payment.UpdatedAt = DateTime.UtcNow;
        return payment;
    }

    public static Payment ToDelete(this Payment payment)
    {
        payment.DeletedAt = DateTime.UtcNow;
        payment.IsDeleted = true;
        return payment;
    }

    public static ReadPaymentInfo ToRead(this Payment payment)
    {
        return new ReadPaymentInfo()
        {
            Id = payment.Id,
            CreatedAt = payment.CreatedAt,
            BasePaymentInfo = new BasePaymentInfo()
            {
                Amount = payment.Amount,
                UserId = payment.UserId,
                VideoId = payment.VideoId
            }
        };
    }
}