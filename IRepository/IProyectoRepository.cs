﻿using DbConsultoriaModel.dbConsultoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository
{
    public interface IProyectoRepository : ICRUDRepository<Proyecto>
    {
        public List<Proyecto> ObtenerProyecto(int idProyecto);

    }
    
}
