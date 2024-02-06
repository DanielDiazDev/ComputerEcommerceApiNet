﻿using System.ComponentModel.DataAnnotations;

namespace ComputerEcommerce.Shared.DTOs
{
    public class RegisterDTO //Ver si usar
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Ingrese nombre completo")]
        public string? FullName { get; set; }
        [Required(ErrorMessage = "Ingrese correo")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Ingrese contraseña")]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Ingrese confirmar contraseña")]
        public string? ConfirmPassword { get; set; }

        public string? Role { get; set; }

    }
}
