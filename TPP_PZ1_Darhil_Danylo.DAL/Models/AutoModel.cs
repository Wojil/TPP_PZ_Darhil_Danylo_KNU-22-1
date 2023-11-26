namespace TPP_PZ1_Darhil_Danylo.DAL.Models
{
    public partial class AutoModel
    {
        public int Id { get; set; }

        public string AutoModelName { get; set; } = null!;
        private AutoModel()
        { }
        public class Builder
        {
            private AutoModel _automodel = new AutoModel();
            public Builder WithId(int id)
            {
                _automodel.Id = id;
                return this;
            }
            public Builder WithName(string name)
            {
                _automodel.AutoModelName=name;
                return this;
            }
            public AutoModel Build()
            {
                if (string.IsNullOrEmpty(_automodel.AutoModelName))
                {
                    throw new InvalidOperationException("Назва автомоделі є null або порожня");
                }
                else return _automodel;
            }
        }
    }
}
