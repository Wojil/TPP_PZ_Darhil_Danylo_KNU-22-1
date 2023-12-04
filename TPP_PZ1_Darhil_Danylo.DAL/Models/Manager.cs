namespace TPP_PZ1_Darhil_Danylo.DAL.Models
{
    public class Manager
    {
        public int Id { get; set; }
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Patronymic { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
        private Manager() { }
        public class Builder
        {
            private Manager _manager = new Manager();
            public Builder WithId(int id)
            {
                _manager.Id = id;
                return this;
            }
            public Builder WithLogin(string Login)
            {
                _manager.Login = Login;
                return this;
            }
            public Builder WithPassword(string Password)
            {
                _manager.Password = Password;
                return this;
            }
            public Builder WithName(string name)
            {
                _manager.Name = name;
                return this;
            }
            public Builder WithSurname(string Surname)
            {
                _manager.Surname = Surname;
                return this;
            }
            public Builder WithPatronymic(string Patronymic)
            {
                _manager.Patronymic = Patronymic;
                return this;
            }
            public Builder WithPhone(string Phone)
            {
                _manager.Phone = Phone;
                return this;
            }
            public Builder WithEmail(string Email)
            {
                _manager.Email = Email;
                return this;
            }
            public Manager Build()
            {
                return _manager;
            }
        }

    }
}
