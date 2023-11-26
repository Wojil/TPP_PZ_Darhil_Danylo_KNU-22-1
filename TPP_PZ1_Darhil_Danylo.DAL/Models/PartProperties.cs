namespace TPP_PZ1_Darhil_Danylo.DAL.Models
{
    public class PartProperties
    {
        public virtual List<AutoModel> AutoModels { get; set; } = null!;

        public virtual List<ManufacturerBrand> ManufacturerBrands { get; set; } = null!;

        public virtual List<ManufacturerCountry> ManufacturerCountries { get; set; } = null!;

        public virtual List<PartCategory> PartCategories { get; set; } = null!;

        public virtual List<PartType> PartTypes { get; set; } = null!;

        public virtual AutoPart AutoPart { get; set; }=null!;

        public PartProperties()
        {
            AutoModels = new List<AutoModel>();
            ManufacturerBrands = new List<ManufacturerBrand>();
            ManufacturerCountries = new List<ManufacturerCountry>();
            PartCategories = new List<PartCategory>();
            PartTypes = new List<PartType>();
            AutoPart = null;
        }
    }
}
