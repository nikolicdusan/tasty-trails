using DeliveryChannel.Domain.Enums;

namespace DeliveryChannel.Domain.Entities;

public class DiscountTier
{
    public TierType Id { get; set; }
    public int MinimumOrderAmount { get; set; }
    public int DiscountAmount { get; set; }
}