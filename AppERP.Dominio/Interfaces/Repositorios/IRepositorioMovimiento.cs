﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppERP.Dominio.Interfaces;

namespace AppERP.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioMovimiento <TEntidad, TEntidadID>
    : IAgregar <TEntidad>, IListar<TEntidad, TEntidadID>, ITransaccion
    {
        void Anular(TEntidadID entidadID);
    }
}
