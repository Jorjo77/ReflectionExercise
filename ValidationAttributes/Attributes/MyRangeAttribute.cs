using System;

namespace ValidationAttributes.Attributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private int minValue;
        private int maxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public override bool IsValid(object objProperty)
        {

            int intObj = (int)objProperty;
            //int intObj = Convert.ToInt32(objProperty);// това е друг начин, еквивалентен на горното касване!
            if (intObj >= minValue && intObj <= maxValue)
            {
                return true;
            }
            return false;
            //return intObj >= minValue && intObj <= maxValue - това е кратък запис, показва при какви условия връща true
            //(горния е по описателен и ясен за мен)
        }
    }
}
