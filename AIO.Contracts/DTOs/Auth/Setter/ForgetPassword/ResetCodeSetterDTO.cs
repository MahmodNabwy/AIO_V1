﻿using System.ComponentModel.DataAnnotations;
#nullable disable
namespace AIO.Contracts.DTOs.Auth.Setter.ForgetPassword
{
    public class ResetCodeSetterDTO
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public string ResetCode { get; set; }
    }
}
