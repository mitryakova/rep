using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text;
namespace Lab2
{
public class BaseModelValidationResult
   {
       private StringBuilder _errorBuilder = new StringBuilder();

       public bool IsValid { get; private set; } = true;
       public string Errors { get => _errorBuilder.ToString().Trim(); }

       public void Append(string error)
       {
           IsValid = false;
           _errorBuilder.AppendLine(error);
       }
   }
}