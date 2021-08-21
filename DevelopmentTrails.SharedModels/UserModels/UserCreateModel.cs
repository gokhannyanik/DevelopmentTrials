using System;
using System.Collections.Generic;
using System.Text;

namespace DevelopmentTrails.SharedModels.UserModels
{
    public class UserCreateModel
    {
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
    }
}
