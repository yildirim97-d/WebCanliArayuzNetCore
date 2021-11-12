﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;

namespace AppCore.Business.Services.Validations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class StringDecimalAttribute : ValidationAttribute
    {

        public override bool IsValid(object value)
        {
            bool validationResult;
            if (value == null)
            {
                validationResult = true;
            }
            else
            {
                double result;
                string valueText = value.ToString().Replace(",", ".");
                validationResult = double.TryParse(valueText, NumberStyles.Any, CultureInfo.InvariantCulture, out result);
            }
            return validationResult;
        }

    }
}
