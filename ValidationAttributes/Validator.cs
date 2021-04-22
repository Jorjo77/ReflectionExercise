using System;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using ValidationAttributes.Attributes;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            Type objType = obj.GetType();
            PropertyInfo[] propertyInfos = objType.GetProperties();
            foreach (var propertyInfo in propertyInfos)
            {

                var allMyAttributes = propertyInfo.GetCustomAttributes<MyValidationAttribute>();

               object propertyObj =  propertyInfo.GetValue(obj);
                foreach (var myValidationAttribute in allMyAttributes)
                {
                    bool IsValide = myValidationAttribute.IsValid(propertyObj);
                    if (!IsValide)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
