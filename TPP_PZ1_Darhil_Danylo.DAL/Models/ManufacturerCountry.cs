namespace TPP_PZ1_Darhil_Danylo.DAL.Models
{
    public partial class ManufacturerCountry
    {
        public int Id { get; set; }

        public string CountryName { get; set; } = null!;
        private ManufacturerCountry() { }
        public class Builder
        {
            private ManufacturerCountry _manufacturercountry = new ManufacturerCountry();
            public Builder WithId(int id)
            {
                _manufacturercountry.Id = id;
                return this;
            }
            public Builder WithName(string name)
            {
                _manufacturercountry.CountryName = name;
                return this;
            }
            public ManufacturerCountry Build()
            {
                if (string.IsNullOrEmpty(_manufacturercountry.CountryName))
                {
                    throw new InvalidOperationException("Назва країни виробника автозапчастини є null або порожня");
                }
                else return _manufacturercountry;
            }
        }

    }
}
