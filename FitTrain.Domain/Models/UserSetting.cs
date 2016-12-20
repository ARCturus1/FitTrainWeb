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
        [Required]
        public int Id { get; set; }

        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public ActivityOfHuman ActivityOfHuman { get; set; }
        public DateTime AddedDate { get; set; }

        [Index]
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }

        
        //[InverseProperty("UserSettings")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        [NotMapped]
        public virtual decimal Dci
        {
            get {
                if (ApplicationUser != null)
                    return DietHelper.GetDci(Weight, Height, ApplicationUser.Age, ApplicationUser.Gender, ActivityOfHuman);
                return 0m;
            }
        }
    }
}
