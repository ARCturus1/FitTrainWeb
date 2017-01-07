using FitTrain.Domain.Entities;
using FitTrain.Domain.Enums;
using FitTrain.Domain.Interfaces;
using FitTrain.Logic.Model;

namespace FitTrain.Logic.Factories
{
    public class DietModelFactory
    {
        public UserSetting CreateDietModel(DietMode mode, IUserSetting setting)
        {
            switch (mode)
            {
                case DietMode.Low: return new LowDayCaloryModel(setting);
                case DietMode.Normal: return new NormalDayCaloryModel(setting);
                case DietMode.High: return new HighDayCaloryModel(setting);
                default: return new NormalDayCaloryModel(setting);
            }
        }
    }
}
