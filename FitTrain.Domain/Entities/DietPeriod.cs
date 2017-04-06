using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitTrain.Domain.Entities
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
