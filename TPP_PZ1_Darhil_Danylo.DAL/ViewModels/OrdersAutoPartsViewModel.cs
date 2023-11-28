using TPP_PZ1_Darhil_Danylo.DAL.Models;

namespace TPP_PZ1_Darhil_Danylo.DAL.ViewModels
{
    public class OrdersAutoPartsViewModel
    {
        public List<OrdersAutoParts> OrdersAutoParts { get; set; } = null!;
        public List<OrderStatus> OrdersStatuses { get; set; } = null!;
        public int Change { get; set; }
    }
}
