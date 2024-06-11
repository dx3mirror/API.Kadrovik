using System.ComponentModel.DataAnnotations;


namespace Domain.Entity
{
    public class UserAutorization
    {
        private int id;
        private string login;
        private string password;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        [Required]
        [StringLength(50)]
        public string Login
        {
            get { return login; }
            set { login = value; }
        }
        [Required]
        [StringLength(50)]
        public string Password
        {
            get { return password; }
            set { password = value; } 
        }

        public UserAutorization() {
            this.Id = -1; 
            this.Login = null;
            this.Password = null;
        } 

        public UserAutorization(int id, string login,string password)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Недопустимое значение Id");
            }

            if (string.IsNullOrWhiteSpace(login))
            {
                throw new ArgumentException("Login не может быть null или пустым");
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Login не может быть null или пустым");
            }

            this.Id = id;
            this.Login = login;
            this.Password = password;
        }
    }
}
