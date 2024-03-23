using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes.Utilities.Attributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private  int minValue;
        private int maxValue;

        public MyRangeAttribute(int minValue,int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }
        public override bool isValid(object obj)
        {
            if (obj is int num) 
            {
                return minValue <= num && num <= maxValue;
            }
            return false;
        }
    }
}
