using Shared.DDD;

namespace Payment.Models;

public class PaymentDetail : Aggregate<Guid>
{
    public Guid OrderId { get; private set; }
    public decimal Amount { get; private set; }
    public string Status { get; private set; } = default!;

    public static PaymentDetail Create(Guid id, Guid orderId, decimal amount, string status)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amount);
        ArgumentException.ThrowIfNullOrWhiteSpace(status);

        return new PaymentDetail
        {
            Id = id,
            OrderId = orderId,
            Amount = amount,
            Status = status
        };
    }

    public void Complete()
    {
        Status = "Completed";
    }

    public void Fail()
    {
        Status = "Failed";
    }
}
