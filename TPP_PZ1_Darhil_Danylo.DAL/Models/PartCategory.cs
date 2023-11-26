namespace TPP_PZ1_Darhil_Danylo.DAL.Models
{
    public partial class PartCategory
    {
         
        public int Id { get; set; }

        public string CategoryName { get; set; } = null!;
        private PartCategory() { }
        public class Builder
        {
            private PartCategory _partcategory = new PartCategory();
            public Builder WithId(int id)
            {
                _partcategory.Id = id;
                return this;
            }
            public Builder WithName(string name)
            {
                _partcategory.CategoryName = name;
                return this;
            }
            public PartCategory Build()
            {
                if (string.IsNullOrEmpty(_partcategory.CategoryName))
                {
                    throw new InvalidOperationException("Назва категорії автозапчастини є null або порожня");
                }
                else return _partcategory;
            }
        }

    }
}
