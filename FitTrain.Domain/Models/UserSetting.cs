using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FitTrain.Domain.Enums;
using FitTrain.Logic.Helpers;

namespace FitTrain.Domain.Models
{
    public class UserSetting
    {
        [Key]
        public Guid Id { get; set; }

        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public ActivityOfHuman ActivityOfHuman { get; set; }

        public int ApplicationUserId { get; set; }

        [ForeignKey("Id")]
        [InverseProperty("UserSettings")]
        public ApplicationUser ApplicationUser { get; set; }

        [NotMapped]
        public decimal Dci => DietHelper.GetDci(Weight, Height, ApplicationUser.Age, ApplicationUser.Gender, ActivityOfHuman);
    }
}
