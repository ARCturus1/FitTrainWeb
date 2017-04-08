using System;
using FitTrain.Domain.Enums;

namespace FitTrain.Logic.Helpers
{
    public class DietCalculator
    {
        #region Constants

        private const decimal CarbEnergy = 4.6m;
        private const decimal ProteintEnergy = 4.6m;
        private const decimal FatEnergy = 9.2m;

        private const decimal CarbsDaylyNorm = 0;
        private const decimal ProteinsDaylyNorm = 1.5m;
        private const decimal FatsDaylyNorm = 0.12m;

        #endregion
        
        #region Fields

        private readonly decimal _weight;
        private readonly decimal _height;
        private readonly int _age;
        private readonly bool _gender;
        private readonly ActivityOfHuman _activity;
        private readonly double _percent;

        private decimal _dci;
        private decimal _protein;
        private decimal _fats;
        private decimal _carbs;

        #endregion

        #region Constructors

        public DietCalculator(decimal weight, decimal height, int age, bool gender, ActivityOfHuman activity,
            double percent)
        {
            _weight = weight;
            _height = height;
            _age = age;
            _gender = gender;
            _activity = activity;
            _percent = percent;
        }

        #endregion


        public decimal Dci
        {
            get
            {
                if (_dci == 0)
                {
                    _dci = GetDci();
                }
                return _dci;
            }
        }

        public decimal Protein
        {
            get
            {
                if (_protein == 0)
                {
                    _protein = GetProteins();
                }
                return _protein;
            }
        }

        public decimal Fats
        {
            get
            {
                if (_fats == 0)
                {
                    _fats = GetFats();
                }
                return _fats;
            }
        }

        public decimal Carbs
        {
            get
            {
                if (_carbs == 0)
                {
                    _carbs = GetCarbo();
                }
                return _carbs;
            }
        }

        private decimal GetDci()
        {
            var agePrefix = _gender ? 5 : - 160;
            var result = Math.Round(((_weight*10) + (_height*6.25m) - (_age*5) + agePrefix)*GetActivityValue(_activity));
            return Math.Abs(_percent) > 0 ? result + result * (decimal)_percent : result;
        }

        private decimal GetProteins()
        {
            return Math.Round(_weight * ProteinsDaylyNorm);
        }

        private decimal GetFats()
        {
            return Math.Round(this.Dci * FatsDaylyNorm / FatEnergy);
        }

        private decimal GetProteinsK()
        {
            return _weight * ProteinsDaylyNorm * ProteintEnergy;
        }

        private decimal GetFatsK()
        {
            return Math.Round(this.Dci * FatsDaylyNorm);
        }

        private decimal GetCarboK()
        {
            var dci = this.Dci;
            var proteins = GetProteinsK();
            var fats = GetFatsK();
            return dci - proteins - fats;
        }

        private decimal GetCarbo()
        {
            return Math.Round(GetCarboK() / CarbEnergy);
        }

        private decimal GetActivityValue(ActivityOfHuman activity)
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