using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
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

        public string Name { get; set; }
        public string Descriprtion { get; set; }
        public ICollection<Exercise> Exercises { get; set; }
        public string MusscleGroupsStr { get; set; }

        [NotMapped]
        public virtual IEnumerable<MusscleGroup> MusscleGroups
        {
            get
            {
                return MusscleGroupsStr.Split(',').Select(x => (MusscleGroup)int.Parse(x));
            }
            set
            {
                MusscleGroupsStr = string.Join(",", value.Select(x => (int)x));
            }
        }
    }
}