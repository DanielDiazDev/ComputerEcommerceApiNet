﻿using System.ComponentModel.DataAnnotations;

namespace ComputerEcommerce.Shared.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Ingrese correo")]
        public string? Email { get; set; }


        [Required(ErrorMessage = "Ingrese contraseña")]
        public string? Password { get; set; }
    }
}
