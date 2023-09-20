﻿using DbConsultoriaModel.dbConsultoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository
{
    public interface IEmpleadoRepository : ICRUDRepository<Empleado>
    {
        public List<Usuario> ObtenerEmpleado(int idEmpleado); 
    }
}
