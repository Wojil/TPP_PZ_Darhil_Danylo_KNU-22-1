namespace TPP_PZ1_Darhil_Danylo.DAL.Models
{
    public class Order
    {
        public int Id { get; set; }
        public OrderStatus Status { get; set; } = null!;
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Comment { get; set; } = null!;
        public Client Client { get; set; }= null!;
        public Manager Manager { get; set; } = null!;
        private Order() { }
        public class Builder
        {
            private Order _order = new Order();
            public Builder WithId(int id)
            {
                _order.Id = id;
                return this;
            }
            public Builder WithStatus(int Id, string Name="")
            {
                _order.Status = new OrderStatus.Builder().WithId(Id).WithName(Name).Build();
                return this;
            }
            public Builder WithCreateDate(DateTime CreateDate)
            {
                _order.CreateDate = CreateDate;
                return this;
            }
            public Builder WithUpdateDate(DateTime UpdateDate)
            {
                _order.UpdateDate = UpdateDate;
                return this;
            }
            public Builder WithComment(string Comment)
            {
                _order.Comment = Comment;
                return this;
            }

            public Builder WithClient(int Id, string Login,string Password, string Name,string Surname, string Patronymic, string Phone, string Email, string Adress)
            {
                _order.Client = new Client.Builder().WithId(Id).WithLogin(Login).WithPassword(Password).WithName(Name).WithSurname(Surname).WithPatronymic(Patronymic).WithPhone(Phone).WithEmail(Email).WithAdress(Adress).Build();
                return this;
            }
            public Builder WithClient(int Id, string Login, string Name, string Surname, string Patronymic, string Phone, string Email, string Adress)
            {
                _order.Client = new Client.Builder().WithId(Id).WithLogin(Login).WithName(Name).WithSurname(Surname).WithPatronymic(Patronymic).WithPhone(Phone).WithEmail(Email).WithAdress(Adress).Build();
                return this;
            }
            public Builder WithManager(int Id, string Login, string Password, string Name, string Surname, string Patronymic, string Phone, string Email)
            {
                _order.Manager = new Manager.Builder().WithId(Id).WithLogin(Login).WithPassword(Password).WithName(Name).WithSurname(Surname).WithPatronymic(Patronymic).WithPhone(Phone).WithEmail(Email).Build();
                return this;
            }
            public Builder WithManager(int Id, string Login, string Name, string Surname, string Patronymic, string Phone, string Email)
            {
                _order.Manager = new Manager.Builder().WithId(Id).WithLogin(Login).WithName(Name).WithSurname(Surname).WithPatronymic(Patronymic).WithPhone(Phone).WithEmail(Email).Build();
                return this;
            }
            public Builder WithClient(int Id, string Name, string Surname, string Patronymic, string Login)
            {
                _order.Client = new Client.Builder().WithId(Id).WithLogin(Login).WithName(Name).WithSurname(Surname).WithPatronymic(Patronymic).Build();
                return this;
            }
            public Builder WithManager(int Id, string Name, string Surname, string Patronymic, string Login)
            {
                _order.Manager = new Manager.Builder().WithId(Id).WithLogin(Login).WithName(Name).WithSurname(Surname).WithPatronymic(Patronymic).Build();
                return this;
            }
            public Builder WithManager(int Id)
            {
                _order.Manager = new Manager.Builder().WithId(Id).Build();
                return this;
            }
            public Builder WithClient(int Id)
            {
                _order.Client = new Client.Builder().WithId(Id).Build();
                return this;
            }
            public Order Build()
            {
                if (_order.Client==null || _order.Status==null)
                {
                    throw new InvalidOperationException("Клієнт або статус замовлення є null");
                }
                else return _order;
            }
        }

    }
}
