namespace TPP_PZ1_Darhil_Danylo.DAL.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Patronymic { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Adress { get; set; } = null!;
        private Client() { }
        public class Builder
        {
            private Client _client = new Client();
            public Builder WithId(int id)
            {
                _client.Id = id;
                return this;
            }
            public Builder WithLogin(string Login)
            {
                _client.Login = Login;
                return this;
            }
            public Builder WithPassword(string Password)
            {
                _client.Password = Password;
                return this;
            }
            public Builder WithName(string name)
            {
                _client.Name = name;
                return this;
            }
            public Builder WithSurname(string Surname)
            {
                _client.Surname= Surname;
                return this;
            }
            public Builder WithPatronymic(string Patronymic)
            {
                _client.Patronymic = Patronymic;
                return this;
            }
            public Builder WithPhone(string Phone)
            {
                _client.Phone = Phone;
                return this;
            }
            public Builder WithEmail(string Email)
            {
                _client.Email = Email;
                return this;
            }
            public Builder WithAdress(string Adress)
            {
                _client.Adress = Adress;
                return this;
            }
            public Client Build()
            {
                return _client;
            }
        }

    }
}
