using Microsoft.AspNetCore.Mvc;
using AppERP.Infraestructura.Datos.Configs;
using AppERP.Infraestructura.Datos.Contexto;
using AppERP.Dominio.Interfaces.Repositorios;
using AppERP.Infraestructura.Datos.Repositorios;
using Microsoft.EntityFrameworkCore.Diagnostics;
using AppERP.Aplicaciones.Servicios;
using AppERP.Dominio.Interfaces;
using AppERP.Dominio;
using Microsoft.OpenApi.Validations;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppERP.Infraestructura.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        ProductoServicio CrearServicio()
        {
            CompraContexto db = new CompraContexto();
            ProductoRepositorio repo = new ProductoRepositorio(db);
            ProductoServicio servicio = new ProductoServicio(repo);
            return servicio;
        }
        // GET: api/<ProducotController>
        [HttpGet]
        public ActionResult<List<Producto>> Get()
        {
            var servicio = CrearServicio();
            return Ok (servicio.Listar());
        }

        // GET api/<ProducotController>/5
        [HttpGet("{id}")]
        public ActionResult<Producto> Get(Guid id)
        {
            var servicio = CrearServicio();
            return Ok(servicio.SeleccionarPorID(id));
        }

        // POST api/<ProducotController>
        [HttpPost]
        public ActionResult Post([FromBody] Producto producto)
        {
            var servicio = CrearServicio();
            servicio.Agregar(producto); 
            return Ok("Agregado");
        }

        // PUT api/<ProducotController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Producto producto)
        {
            var servicio = CrearServicio();
            producto.productoId = id;
            servicio.Editar(producto);
            return Ok("MODIFICADO EXITOSAMENTE");

        }

        // DELETE api/<ProducotController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var servicio = CrearServicio();
            servicio.Eliminar(id);
            return Ok("Elminado");
        }
    }
}
