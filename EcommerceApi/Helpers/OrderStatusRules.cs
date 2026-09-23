namespace EcommerceApi.Helpers
{
    public class OrderStatusRules
    {
        public static bool CanTransition(string currentStatus,string newStatus)
        {
            return currentStatus switch
            {
                OrderStatus.Pending =>
                 newStatus == OrderStatus.Processing ||
                 newStatus == OrderStatus.Cancelled,

                 OrderStatus.Processing=>
                 newStatus==OrderStatus.Shipped ||
                 newStatus==OrderStatus.Cancelled,

                 OrderStatus.Shipped=>
                 newStatus==OrderStatus.Delivered,

                 OrderStatus.Delivered=>false,
                 OrderStatus.Cancelled=>false,

                 _=>false

            };
        }
    }
}
