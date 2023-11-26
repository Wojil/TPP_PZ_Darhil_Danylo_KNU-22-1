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
        public int SelectedPartCount { get; set; }//additional parametr

        private AutoPart() { }
        public class Builder
        {
            private AutoPart _autopart = new AutoPart();
            public Builder WithId(int id)
            {
                _autopart.Id = id;
                return this;
            }
            public Builder WithCode(string Code)
            {
                _autopart.Code = Code;
                return this;
            }
            public Builder WithName(string Name)
            {
                _autopart.Name = Name;
                return this;
            }
            public Builder WithPrice(decimal Price)
            {
                _autopart.Price = Price;
                return this;
            }
            public Builder WithDescription(string Description)
            {
                _autopart.Description = Description;
                return this;
            }
            public Builder WithQuantity(int Quantity)
            {
                _autopart.Quantity = Quantity;
                return this;
            }
            public Builder WithAutomodel(int Id, string Name)
            {
                _autopart.AutoModel = new AutoModel.Builder().WithId(Id).WithName(Name).Build();
                return this;
            }
            public Builder WithManufacturerBrand(int Id, string Name)
            {
                _autopart.ManufacturerBrand = new ManufacturerBrand.Builder().WithId(Id).WithName(Name).Build();
                return this;
            }
            public Builder WithManufacturerCountry(int Id, string Name)
            {
                _autopart.ManufacturerCountry = new ManufacturerCountry.Builder().WithId(Id).WithName(Name).Build();
                return this;
            }
            public Builder WithPartCategory(int Id, string Name)
            {
                _autopart.PartCategory = new PartCategory.Builder().WithId(Id).WithName(Name).Build();
                return this;
            }
            public Builder WithPartType(int Id, string Name)
            {
                _autopart.PartType = new PartType.Builder().WithId(Id).WithName(Name).Build();
                return this;
            }
            public Builder WithSelectedPartCount(int Count)
            {
                _autopart.SelectedPartCount = Count;
                return this;
            }
            public AutoPart Build()
            {
                if (string.IsNullOrEmpty(_autopart.Name) || string.IsNullOrEmpty(_autopart.Code))
                {
                    throw new InvalidOperationException("Назва або код автозапчастини є null або порожнім");
                }
                else return _autopart;
            }
        }

    }
}
