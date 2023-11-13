﻿using System;
using System.Collections.Generic;
using Core.entities;

namespace Base.Models;

public partial class CursoHorarioUbicacion: IEntity
{
    public int id_h { get; set; }

    public string nombre_grupo { get; set; }

    public string nombre_materia { get; set; }

    public int id_c { get; set; }

    public string codigo_ubicaciones { get; set; }

   
}
