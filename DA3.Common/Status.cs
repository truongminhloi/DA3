namespace DA3.Common
{
    public enum Status
    {
        ACTIVE = 1,
        DELETE = 99
    }

    public enum StatusOrder
    {
        PENDING = 1,
        CONFIRMED = 2,
        Delivery = 3,
        Delivered = 4,
        REFUSED = 5,
    }
}
