using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sigesco.Models
{
    public class UsuarioModel
    {
        public string Rut { get; set; }
        public string Dv { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string TipoUsuario { get; set; }
        public string Departamento { get; set; }

    }
}