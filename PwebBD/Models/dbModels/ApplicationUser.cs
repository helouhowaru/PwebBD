using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace PwebBD.Models.dbModels
{
    public class ApplicationUser : IdentityUser<int>
    {
        public object Datosreservacions { get; internal set; } = null!;

        public partial class Usuario
        {
            [Key]
            public int IdUsuario { get; set; }

            [Column("nombre")]
            [StringLength(50)]
            public string Nombre { get; set; } = null!;

            [Column("correo")]
            [StringLength(50)]
            public string Correo { get; set; } = null!;

            [Column("contraseña")]
            [StringLength(50)]
            public string Contraseña { get; set; } = null!;

            [Column("telefono")]
            public int Telefono { get; set; }

            [InverseProperty("IdUsuarioNavigation")]
            public virtual ICollection<Datosreservacion> Datosreservacions { get; set; } = new List<Datosreservacion>();
        }
    }
}
