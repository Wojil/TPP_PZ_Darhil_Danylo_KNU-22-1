using TPP_PZ1_Darhil_Danylo.DAL.Models;

namespace TPP_PZ1_Darhil_Danylo.DAL.ViewModels
{
    public class PartPropertiesViewModel
    {
        public virtual List<AutoModel> AutoModels { get; set; } = null!;

        public virtual List<ManufacturerBrand> ManufacturerBrands { get; set; } = null!;

        public virtual List<ManufacturerCountry> ManufacturerCountries { get; set; } = null!;

        public virtual List<PartCategory> PartCategories { get; set; } = null!;

        public virtual List<PartType> PartTypes { get; set; } = null!;

        public virtual AutoPart AutoPart { get; set; } = null!;

        public PartPropertiesViewModel()
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
