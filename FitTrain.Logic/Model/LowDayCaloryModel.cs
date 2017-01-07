using FitTrain.Domain.Entities;
using FitTrain.Domain.Interfaces;
using FitTrain.Logic.Helpers;

namespace FitTrain.Logic.Model
{
    public sealed class LowDayCaloryModel : UserSetting
    {
        private readonly DietCalculator _dietCalculator;
        public LowDayCaloryModel(IUserSetting setting)
        {
            FillToObject(setting);
            _dietCalculator = new DietCalculator(setting.Weight, setting.Height, setting.ApplicationUser.Age,
                setting.ApplicationUser.Gender, setting.ActivityOfHuman, 0);
        }

        public override decimal Dci => _dietCalculator.Dci;

        public override decimal Proteins => _dietCalculator.Protein;

        public override decimal Fats => _dietCalculator.Fats;

        public override decimal Carbs => _dietCalculator.Carbs;
    }
}
