using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FitTrain.Domain.Enums;

namespace FitTrain.Domain.Entities.Diet
{
    public class DietDay
    {
        [Key]
        public int Id { get; set; }

        [Index]
        [ForeignKey("DietPeriod")]
        public int DietPeroidId { get; set; }

        [Required]
        public DietMode DietMode { get; set; }

        public virtual DietPeriod DietPeriod { get; set; }
    }
}