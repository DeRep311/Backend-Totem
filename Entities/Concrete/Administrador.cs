using System;
using System.Collections.Generic;
using Core.entities;

namespace DataAccess.Models;

public partial class Administrador: IEntity
{
    public int Cedula { get; set; }
}
