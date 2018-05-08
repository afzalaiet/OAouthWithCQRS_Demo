using CeremonyBazar.Comman.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CeremonyBazar.Model
{
    public class UserRegistartionModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Password { get; set; }

        public UserNameTypes UserNameType { get; set; }
    }
}