using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTransacciones.Dto;
using PruebaTransacciones.Interfaces;
using static PruebaTransacciones.Dto.Transaccion;

namespace PruebaTransacciones.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class TransaccionController : ControllerBase
    {
        private readonly ItransaccionService _transaccionServices;

        public TransaccionController(ItransaccionService transaccionServices)
        {
            _transaccionServices = transaccionServices;
        }

        [Authorize]
        [HttpGet("GetAllTransacciones")]
        public async Task<ActionResult<List<Transaccion>>> GetAllTransacciones()
        {
            var transacciones = await _transaccionServices.GetAllTransaccionesAsync();
            return Ok(transacciones);
        }
        [Authorize]
        [HttpGet("GetTransaccionById/{id}")]
        public async Task<ActionResult<Transaccion>> GetTransaccionById(int id)
        {
            var transacciones = await _transaccionServices.GetAllTransaccionesByIdAsync(id);
            return Ok(transacciones);
        }
        [Authorize]
        [HttpPost("CreateTransaction")]
        public async Task<ActionResult<Transaccion>> CreateTransaction(Transacciones transaccion)
        {
            try
            {
                var createTransacion = await _transaccionServices.CreateTransaccionAsync(transaccion);
                return CreatedAtAction(nameof(GetTransaccionById), new { id = createTransacion.TransaccionID }, createTransacion);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpPost("UpdateTransaccion/{id}")]
        public async Task<ActionResult<Transaccion>> UpdateTransaccion(int id , Transacciones transaccion)
        {
            try
            {
                var updateTransaccion = await _transaccionServices.UpdateTransaccionAsync(id,transaccion);
                return NoContent();
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpPost("DeleteTransaccion/{id}")]
        public async Task<ActionResult<Transaccion>> DeleteTransaccion(int id)
        {
            try
            {
                await _transaccionServices.DeleteTransactionAsync(id);
                return NoContent();
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}
