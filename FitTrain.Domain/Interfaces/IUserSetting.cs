using System;
using FitTrain.Domain.Entities;
using FitTrain.Domain.Enums;

namespace FitTrain.Domain.Interfaces
{
    public interface IUserSetting
    {
        decimal Weight { get; set; }
        decimal Height { get; set; }
        ActivityOfHuman ActivityOfHuman { get; set; }
        string ApplicationUserId { get; set; }
        ApplicationUser ApplicationUser { get; set; }
    }
}