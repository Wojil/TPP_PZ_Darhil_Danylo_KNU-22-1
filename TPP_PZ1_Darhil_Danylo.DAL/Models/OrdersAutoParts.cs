namespace TPP_PZ1_Darhil_Danylo.DAL.Models
{
    public class OrdersAutoParts
    {
        public AutoPart AutoPart { get; set; } = null!;
        public Order Order { get; set; } = null!;
        public double Price { get; set; }

    }
}
