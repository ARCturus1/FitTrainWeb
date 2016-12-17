using System;
using FitTrain.Domain.Enums;

namespace FitTrain.Logic.Helpers
{
    public static class DietHelper
    {
        public static decimal GetDci(decimal weight, decimal height, int age, bool gender, ActivityOfHuman activity)
        {
            var agePrefix = gender ? 5 : -160;

            return Math.Round(((weight*10) + (height*6.25m) - (age*5) + agePrefix)*GetActivityValue(activity));
        }

        private static decimal GetActivityValue(ActivityOfHuman activity)
        {
            switch (activity)
            {
                case ActivityOfHuman.Minimal:
                    return 1.2m;
                case ActivityOfHuman.Medium3:
                    return 1.38m;
                case ActivityOfHuman.Medium5:
                    return 1.46m;
                case ActivityOfHuman.High5:
                    return 1.55m;
                case ActivityOfHuman.High7:
                    return 1.64m;
                case ActivityOfHuman.Hight72:
                    return 1.73m;
                case ActivityOfHuman.Max:
                    return 1.9m;

                default:
                    return 1.2m;
            }
        }
    }
}