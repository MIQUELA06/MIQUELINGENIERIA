using System;
using System.ComponentModel.DataAnnotations;

namespace MIQUELINGENIERIA.Models
{
    public class Usuario
    {
        [Required, StringLength(100)]
        public string Nombres { get; set; }

        [Required, StringLength(100)]
        public string Apellidos { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }

        [Required, EmailAddress, StringLength(100)]
        public string Correo { get; set; }

        [Required, StringLength(20)]
        public string Telefono { get; set; }

        [Required, StringLength(200)]
        public string Direccion { get; set; }

        [Required, StringLength(10)]
        public string Sexo { get; set; }

    }
}
