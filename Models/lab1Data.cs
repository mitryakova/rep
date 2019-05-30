using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Lab2
{

public class Lab1Data
   {
      public Guid Id { get; set; } = Guid.NewGuid();
       public string Surname { get; set; }
       public string Name { get; set; }
       public string Firstname { get; set; }
       public int Age { get; set; }
       public BaseModelValidationResult Validate()
       {
           var validationResult = new BaseModelValidationResult();

           if (string.IsNullOrWhiteSpace(Surname)) validationResult.Append($"Surname cannot be empty");
           if (string.IsNullOrWhiteSpace(Name)) validationResult.Append($"Name cannot be empty");
           if (string.IsNullOrWhiteSpace(Firstname)) validationResult.Append($"Firstname cannot be empty");
           if (!(0 < Age && Age < 100)) validationResult.Append($"Age {Age} is out of range (0..100)");

           if (!string.IsNullOrEmpty(Surname) && !char.IsUpper(Surname.FirstOrDefault())) validationResult.Append($"Surname {Surname} should start from capital letter");
           if (!string.IsNullOrEmpty(Name) && !char.IsUpper(Name.FirstOrDefault())) validationResult.Append($"Name {Name} should start from capital letter");

           return validationResult;
       }

       public override string ToString()
       {
           return $"{Surname} {Name} {Firstname}, {Age}";
       }
   }
   
}