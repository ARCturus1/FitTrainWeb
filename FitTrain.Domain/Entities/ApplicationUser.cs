using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FitTrain.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime BirthDate { get; set; }
        public ICollection<UserSetting> UserSettings { get; set; }
        public bool Gender { get; set; }

        public virtual int Age => DateTime.Now.Year - BirthDate.Year;
    }
}