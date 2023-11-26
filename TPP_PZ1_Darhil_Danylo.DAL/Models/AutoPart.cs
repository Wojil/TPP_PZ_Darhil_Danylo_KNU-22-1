namespace TPP_PZ1_Darhil_Danylo.DAL.Models
{
    public partial class AutoPart
    {
        public int Id { get; set; }

        public string Code { get; set; } = null!;

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public string Description { get; set; } = null!;

        public int Quantity { get; set; }
        public virtual AutoModel AutoModel { get; set; } = null!;

        public virtual ManufacturerBrand ManufacturerBrand { get; set; } = null!;

        public virtual ManufacturerCountry ManufacturerCountry { get; set; } = null!;

        public virtual PartCategory PartCategory { get; set; } = null!;

        public virtual PartType PartType { get; set; } = null!;
        public int SelectedPartCount { get; set; }


    }
}
