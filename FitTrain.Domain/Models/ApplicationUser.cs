using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FitTrain.Domain.Models
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }
        public ICollection<UserSetting> UserSettings { get; set; }
        public bool Gender { get; set; }
    }
}