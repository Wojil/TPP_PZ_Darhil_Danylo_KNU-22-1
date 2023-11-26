namespace TPP_PZ1_Darhil_Danylo.DAL.Models
{
    public class CartPart
    {
        public AutoPart AutoPart { get; set; }
        public int Quantity { get; set; }
        public CartPart(AutoPart autopart,int quantity)
        {
            AutoPart = autopart;
            Quantity = quantity;
        }
    }
}
