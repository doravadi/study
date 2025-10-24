using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study
{
    public class User
    {
        private string _username;
        private string _password;
        private string _email;
        private string _firstName;
        private string _lastName;

        public Guid Id { get; private set; }

        public string Username
        {
            get => _username;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Username boş geçilemez.");

                if (value.Length > 20)
                    _username = value.Substring(0, 20);
                else if (value.Length < 3)
                    _username = value.PadLeft(3, '*');
                else
                    _username = value;
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    _password = "********";
                else if (value.Length < 8)
                    _password = value.PadRight(8, '*');
                else
                    _password = value;
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Email boş geçilemez.");
                _email = value;
            }
        }

        public string EmailConfirm => _email;

        public string FirstName
        {
            get => _firstName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("FirstName boş geçilemez.");
                _firstName = value;
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("LastName boş geçilemez.");
                _lastName = value;
            }
        }

        public DateTime CreatedDate { get; set; }

        public User()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.Now;
        }
    }

    
    
}
