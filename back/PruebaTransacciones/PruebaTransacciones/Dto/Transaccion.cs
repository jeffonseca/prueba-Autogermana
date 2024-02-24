using System.ComponentModel.DataAnnotations;

namespace PruebaTransacciones.Dto
{
    public class Transaccion
    {
        public class Vehiculos
        {
            [Key]
            public int VehiculoID { get; set; }
            public string Marca { get; set; }
            public string Modelo { get; set; }
            public int Anio { get; set; }
            public decimal Precio { get; set; }
        }

        public class Clientes
        {
            [Key]
            public int ClienteID { get; set; }
            public string Nombre { get; set; }
            public string Email { get; set; }
            public string Telefono { get; set; }
        }

        public class Concesionarios
        {
            [Key]
            public int ConcesionarioID { get; set; }
            public string Nombre { get; set; }
            public string Direccion { get; set; }
            public string Ciudad { get; set; }
        }

        public class Transacciones
        {
            [Key]
            public int TransaccionID { get; set; }
            public int VehiculoID { get; set; }
            public int ClienteID { get; set; }
            public int ConcesionarioID { get; set; }
            public DateTime FechaVenta { get; set; }
            public decimal PrecioVenta { get; set; }
        }
    }
}
