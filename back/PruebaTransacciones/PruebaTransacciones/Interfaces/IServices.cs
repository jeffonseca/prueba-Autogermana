using static PruebaTransacciones.Dto.Transaccion;

namespace PruebaTransacciones.Interfaces
{
    public interface ItransaccionService
    {
        Task<List<Transacciones>> GetAllTransaccionesAsync();

        Task<Transacciones> GetAllTransaccionesByIdAsync( int id );

        Task<Transacciones> CreateTransaccionAsync(Transacciones transacciones);

        Task<Transacciones> UpdateTransaccionAsync(int id, Transacciones transacciones);

        Task DeleteTransactionAsync(int id);

    }
}
