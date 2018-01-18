﻿namespace VoiceSystem.Web.Infrastructure.Binders
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Web.Mvc;

    public class NullableDoubleModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var result = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (result != null && !string.IsNullOrEmpty(result.AttemptedValue))
            {
                if (bindingContext.ModelType == typeof(Nullable<double>))
                {
                    double temp;
                    var attempted = result.AttemptedValue.Replace(",", ".");
                    if (double.TryParse(
                        attempted,
                        NumberStyles.Number,
                        CultureInfo.InvariantCulture,
                        out temp))
                    {
                        return (double?)temp;
                    }
                }
            }

            return base.BindModel(controllerContext, bindingContext);
        }
    }
}
