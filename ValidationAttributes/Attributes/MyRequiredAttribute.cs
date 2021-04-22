using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes.Attributes
{
    class MyRequiredAttribute : MyValidationAttribute
    {
        public override bool IsValid(object objProperty)
        {
            if (objProperty != null)
            {
                return true;
            }
            return false;

            //return objProperty != null;//краткия запис
        }
    }
}
