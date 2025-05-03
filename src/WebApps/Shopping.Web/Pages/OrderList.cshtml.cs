using Shopping.Web.Models.Ordering;

namespace Shopping.Web.Pages
{
    public class OrderListModel(IOrderService orderingService, ILogger<OrderListModel> logger)
        : PageModel
    {
        public IEnumerable<OrderModel> Orders { get; set; } = [];

        public async Task<IActionResult> OnGetAsync()
        {
            var customerId = new Guid("344dd904-a008-4e0b-b6d6-2c2b23d25996");
            var response = await orderingService.GetOrdersByCustomerId(customerId);
            Orders = response.Orders;

            return Page();
        }
    }
}
