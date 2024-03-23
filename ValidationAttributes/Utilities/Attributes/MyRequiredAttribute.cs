using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes.Utilities.Attributes
{
    public class MyRequiredAttribute : MyValidationAttribute
    {

        public override bool isValid(object obj)
        {
            if (obj is string str) 
            {
                return !string.IsNullOrEmpty(str);
            }
            return false;
        }
    }
}
