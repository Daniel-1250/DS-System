//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DS_System.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Productos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Productos()
        {
            this.Ventas = new HashSet<Ventas>();
        }
    
        public string CDBarras { get; set; }
        public int IdProveedor { get; set; }
        public string NommbreProduc { get; set; }
        public string Descripcion { get; set; }
        public decimal Stock { get; set; }
        public decimal PrecioCom { get; set; }
        public decimal PrecioVen { get; set; }
        public System.DateTime Caducidad { get; set; }
        public System.DateTime FechaRegis { get; set; }
        public int IdClasificacion { get; set; }
    
        public virtual Clasificacion Clasificacion { get; set; }
        public virtual Proveedores Proveedores { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ventas> Ventas { get; set; }
    }
}
