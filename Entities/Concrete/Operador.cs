using System;
using System.Collections.Generic;
using Core.entities;

namespace DataAccess.Models;

public partial class Operador: IEntity
{
    public int Cedula { get; set; }
}
