namespace TPP_PZ1_Darhil_Danylo.DAL.Models
{
    public class OrderStatus
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        private OrderStatus() {}
        public class Builder
        {
            private OrderStatus _orderstatus = new OrderStatus();
            public Builder WithId(int id)
            {
                _orderstatus.Id = id;
                return this;
            }
            public Builder WithName(string name)
            {
                _orderstatus.Name = name;
                return this;
            }
            public OrderStatus Build()
            {
                if (string.IsNullOrEmpty(_orderstatus.Name))
                {
                    throw new InvalidOperationException("Назва статусу замовлення є null або порожня");
                }
                else return _orderstatus;
            }
        }

    }
}
