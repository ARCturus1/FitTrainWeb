using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FitTrain.Domain.Enums;

namespace FitTrain.Domain.Entities.Training
{
    public class Exercise
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [ForeignKey("ExerciseType")]
        public int ExerciseTypeId { get; set; }

        [ForeignKey("Training")]
        public int TrainingId { get; set; }

        public ICollection<Approach> Approaches { get; set; }
        public virtual Training Training { get; set; }
        public virtual ExerciseType ExerciseType { get; set; }
    }

    public class ExerciseType
    {
        [Key]
        public int Id { get; set; }

        public ICollection<Exercise> Exercises { get; set; }
        public MusscleGroup? MusscleGroup { get; set; }
    }
}