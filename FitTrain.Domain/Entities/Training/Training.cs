using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitTrain.Domain.Entities.Training
{
    public class Training
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public ICollection<Exercise> Exercises { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}