using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TheHub.Library.Model
{
    public class User
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "First name required.")]
        public string _firstName { get; set; }
        
        [Required(ErrorMessage = "Last name required.")]
        public string _lastName { get; set; }
        
        [Required(ErrorMessage = "Username required.")]
        public string _userName { get; set; }
        
        [Required(ErrorMessage = "Email required.")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Password required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string _password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public string Picture { get; set; }

        public string Bio { get; set; }

        public bool AdminUser { get; set; }

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