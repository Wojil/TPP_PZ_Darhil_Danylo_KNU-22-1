namespace TPP_PZ1_Darhil_Danylo.DAL.Models
{
    public class Order
    {
        public int Id { get; set; }
        public OrderStatus Status { get; set; } = null!;
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Comment { get; set; } = null!;
        public Client Client { get; set; }= null!;
        public Manager Manager { get; set; } = null!;
    }
}
