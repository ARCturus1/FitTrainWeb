using System;
using FitTrain.Domain.Enums;

namespace FitTrain.Logic.Helpers
{
    public static class DietHelper
    {
        public static decimal GetDci(decimal weight, decimal height, int age, bool gender, ActivityOfHuman activity)
        {
            var agePrefix = gender ? 5 : - 160;
            return Math.Round(((weight*10) + (height*6.25m) - (age*5) + agePrefix)*GetActivityValue(activity));
        }

        public static decimal GetProteins(decimal weight)
        {
            return weight * 1.5m;
        }

        public static decimal GetFats(decimal dci)
        {
            return Math.Round(dci * 0.12m / 9.2m);
        }

        public static decimal GetProteinsK(decimal weight)
        {
            return weight * 1.5m * 4.6m;
        }

        public static decimal GetFatsK(decimal dci)
        {
            return Math.Round(dci * 0.12m);
        }

        public static decimal GetCarboK(decimal weight, decimal height, int age, bool gender, ActivityOfHuman activity)
        {
            var dci = GetDci(weight, height, age, gender, activity);
            var proteins = GetProteinsK(weight);
            var fats = GetFatsK(dci);
            return dci - proteins - fats;
        }

        public static decimal GetCarbo(decimal weight, decimal height, int age, bool gender, ActivityOfHuman activity)
        {
            return GetCarboK(weight, height, age, gender, activity) / 4.6m;
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