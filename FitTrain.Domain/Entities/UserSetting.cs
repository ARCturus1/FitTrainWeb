using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FitTrain.Domain.Enums;
using FitTrain.Domain.Interfaces;

namespace FitTrain.Domain.Entities
{
    public class UserSetting : IUserSetting
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
        
        public virtual ApplicationUser ApplicationUser { get; set; }

        [NotMapped]
        public virtual decimal Dci { get; }

        [NotMapped]
        public virtual decimal Proteins { get; }

        [NotMapped]
        public virtual decimal Fats { get; }

        [NotMapped]
        public virtual decimal Carbs { get; }

        public virtual void FillToObject(IUserSetting setting)
        {
            Weight = setting.Weight;
            Height = setting.Height;
            ActivityOfHuman = setting.ActivityOfHuman;
            ApplicationUserId = setting.ApplicationUserId;
            ApplicationUser = setting.ApplicationUser;
        }
    }
}
