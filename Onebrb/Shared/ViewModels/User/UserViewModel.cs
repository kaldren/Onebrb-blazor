using System;
using System.Collections.Generic;
using System.Text;

namespace Onebrb.Shared.ViewModels.User
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
    }
}
