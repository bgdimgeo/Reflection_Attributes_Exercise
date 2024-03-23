using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using ValidationAttributes.Utilities.Attributes;

namespace ValidationAttributes.Utilities
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            //ValidationContext validation = new ValidationContext(obj);
            //ICollection<ValidationResult> errors = new List<ValidationResult>();

            //return System.ComponentModel.DataAnnotations.Validator.TryValidateObject(obj, validation, errors);
            Type objType = obj.GetType();
            PropertyInfo[] properties = objType.GetProperties().
                Where(pi => pi.CustomAttributes.
                Any(a => a.AttributeType.BaseType == typeof(MyValidationAttribute)))
                .ToArray();
            foreach (PropertyInfo property in properties) 
            {
                object propValue = property.GetValue(obj);
                foreach (CustomAttributeData customAttribute in property.CustomAttributes)
                {
                    Type custAttributeType = customAttribute.AttributeType;
                    object attributeInstance = property.GetCustomAttribute(custAttributeType);
                    MethodInfo validationMethod = custAttributeType.GetMethods().First(m => m.Name == "isValid");

                    bool result = (bool)validationMethod.Invoke(attributeInstance, new object[] { propValue });
                    if (result == false)
                    {
                        return false;
                    }
                }

            }


            return true;
        }
    }
}
