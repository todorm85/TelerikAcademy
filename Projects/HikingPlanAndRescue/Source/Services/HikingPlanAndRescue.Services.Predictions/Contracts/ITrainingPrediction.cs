﻿namespace HikingPlanAndRescue.Services.Logic.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data.Models;
    public interface ITrainingPrediction
    {
        Training Predict(Training training);
    }
}
