namespace TPP_PZ1_Darhil_Danylo.DAL.Models
{
    public partial class PartType
    {
        public int Id { get; set; }

        public string TypeName { get; set; } = null!;
        private PartType() { }
        public class Builder
        {
            private PartType _parttype = new PartType();
            public Builder WithId(int id)
            {
                _parttype.Id = id;
                return this;
            }
            public Builder WithName(string name)
            {
                _parttype.TypeName = name;
                return this;
            }
            public PartType Build()
            {
                if (string.IsNullOrEmpty(_parttype.TypeName))
                {
                    throw new InvalidOperationException("Назва типу автозапчастини є null або порожня");
                }
                else return _parttype;
            }
        }
    }

}
