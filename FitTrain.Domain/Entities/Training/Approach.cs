using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitTrain.Domain.Entities.Training
{
    public class Approach
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Exercise")]
        public int ExcesiceId { get; set; }

        public decimal Weight { get; set; }
        public int Times { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public virtual Exercise Exercise { get; set; }
    }
}