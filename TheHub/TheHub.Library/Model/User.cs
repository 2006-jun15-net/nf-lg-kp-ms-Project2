using System;
using System.Collections.Generic;


namespace TheHub.Library.Model
{
    public class User
    {
        public int UserId { get; set; }

        public string _firstName { get; set; }

        public string _lastName { get; set; }
        
        public string _userName { get; set; }

        public string Email { get; set; }

        public string _password { get; set; }

        public string Picture { get; set; }

        public string Bio { get; set; }

        public bool Admin { get; set; }

        List<User> Followers { get; set; }

        List<User> Following { get; set; }


        public string FirstName
        {
            get => _firstName;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("First Name cannot be empty", nameof(value));
                }
                _firstName = value;
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Last Name cannot be empty", nameof(value));
                }
                _lastName = value;
            }
        }

        public string UserName
        {
            get => _userName;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException(" Username cannot be empty", nameof(value));
                }
                _userName = value;
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("First Name cannot be empty", nameof(value));
                }
                _password = value;
            }
        }
    }
}