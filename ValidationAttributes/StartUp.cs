using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ValidationAttributes
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var person = new Person
             (
                 null,
                 -1
             );

            bool isValidEntity = Validator.IsValid(person);

            Console.WriteLine(isValidEntity);


            //bool IsValid =  Validator.TryValidateObject(
            //     person, 
            //     new ValidationContext(person),
            //     new List<ValidationResult>()
            //     ); Задачата е ние да си направим това  "държавното"!
            // Console.WriteLine(IsValid);
        }
    }
}
