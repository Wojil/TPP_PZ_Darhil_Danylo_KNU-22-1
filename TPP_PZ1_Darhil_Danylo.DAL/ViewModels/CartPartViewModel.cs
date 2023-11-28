using TPP_PZ1_Darhil_Danylo.DAL.Models;

namespace TPP_PZ1_Darhil_Danylo.DAL.ViewModels
{
    public class CartPartViewModel
    {
        public AutoPart AutoPart { get; set; }
        public int Quantity { get; set; }
        public CartPartViewModel(AutoPart autopart, int quantity)
        {
            AutoPart = autopart;
            Quantity = quantity;
        }
    }
}
