using System;
using System.Collections.Generic;
using Core.entities;

namespace DataAccess.Models;

public partial class Privado: IEntity
{
    public string Codigo { get; set; }
}
