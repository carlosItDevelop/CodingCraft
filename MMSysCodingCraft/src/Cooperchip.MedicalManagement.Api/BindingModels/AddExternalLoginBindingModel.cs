﻿using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Cooperchip.MedicalManagement.Api.BindingModels
{
    // Models used as parameters to AccountController actions.

    public class AddExternalLoginBindingModel
    {
        [Required]
        [Display(Name = "External access token")]
        public string ExternalAccessToken { get; set; }
    }
}
