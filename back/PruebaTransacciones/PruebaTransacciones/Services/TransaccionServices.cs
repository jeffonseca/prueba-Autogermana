using Microsoft.EntityFrameworkCore;
using PruebaTransacciones.Data;
using PruebaTransacciones.Dto;
using PruebaTransacciones.Interfaces;
using static PruebaTransacciones.Dto.Transaccion;

namespace PruebaTransacciones.Services
{
    public class TransaccionServices : ItransaccionService
    {

        private readonly YourBDContext _dbContext;

        public TransaccionServices( YourBDContext dbContext) {
            _dbContext = dbContext;
        }
        public async Task<Transacciones> CreateTransaccionAsync(Transaccion.Transacciones transacciones)
        {
            _dbContext.Transacciones.Add(transacciones);
            await _dbContext.SaveChangesAsync();    
            return transacciones;
        }

        public async Task DeleteTransactionAsync(int id)
        {
           var transaccionDelete = await _dbContext.Transacciones.FindAsync(id);
            if (transaccionDelete == null) {
                throw new KeyNotFoundException("Transaccion no encontrada");
            }
            _dbContext.Transacciones.Remove(transaccionDelete);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Transacciones>> GetAllTransaccionesAsync()
        {
            return await _dbContext.Transacciones.ToListAsync();    
        }

        public async Task<Transacciones> GetAllTransaccionesByIdAsync(int id)
        {
            return await _dbContext.Transacciones.FindAsync(id);
        }

        public async Task<Transacciones> UpdateTransaccionAsync(int id, Transaccion.Transacciones transacciones)
        {
            if (id != transacciones.TransaccionID) {
                throw new ArgumentException("Id de transaccion no coincide");
            }
            var existingTransaccion = await _dbContext.Transacciones.FindAsync(id);
            if (existingTransaccion == null) {
                throw new KeyNotFoundException("la transaccion no existe");
            }

            _dbContext.Entry(existingTransaccion).CurrentValues.SetValues(transacciones);
            await _dbContext.SaveChangesAsync();
            return transacciones;
        }
    }
}
