namespace TPP_PZ1_Darhil_Danylo.DAL.Models
{
    public partial class ManufacturerBrand
    {
        public int Id { get; set; }

        public string BrandName { get; set; } = null!;
        private ManufacturerBrand() { }
        public class Builder
        {
            private ManufacturerBrand _manufacturerbrand = new ManufacturerBrand();
            public Builder WithId(int id)
            {
                _manufacturerbrand.Id = id;
                return this;
            }
            public Builder WithName(string name)
            {
                _manufacturerbrand.BrandName = name;
                return this;
            }
            public ManufacturerBrand Build()
            {
                if (string.IsNullOrEmpty(_manufacturerbrand.BrandName))
                {
                    throw new InvalidOperationException("Назва бренду автозапчастини є null або порожня");
                }
                else return _manufacturerbrand;
            }
        }

    }
}
