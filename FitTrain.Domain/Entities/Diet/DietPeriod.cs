using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitTrain.Domain.Entities.Diet
{
    public class DietPeriod
    {
        [Key]
        public int Id { get; set; }

        [Index]
        [ForeignKey("UserSetting")]
        public int UserSettingId { get; set; }

        [Required]
        public DateTime CreatedDate{ get; set; }

        public ICollection<DietDay> Days { get; set; }

        public virtual UserSetting UserSetting { get; set; }
    }
}
