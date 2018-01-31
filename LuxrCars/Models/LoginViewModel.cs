using LuxrCars.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LuxrCars.Models
{
    public class LoginViewModel: Model
    {
        [DataType(DataType.EmailAddress)]
        public string Emailing { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

    }
}