using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppERP.Dominio.Interfaces;

namespace AppERP.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioBase<TEntidad, TEntidadID>
    : IAgregar<TEntidad>, IEditar<TEntidad>, IEliminar<TEntidadID>,IListar<TEntidad, TEntidadID>, ITransaccion
    {
        
    }
}
