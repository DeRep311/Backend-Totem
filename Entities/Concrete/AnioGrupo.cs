﻿using System;
using System.Collections.Generic;
using Core.entities;

namespace Base.Models;

public partial class AnioGrupo: IEntity
{
    public string NombreGrupo { get; set; }

    public int? Anio { get; set; }
}
