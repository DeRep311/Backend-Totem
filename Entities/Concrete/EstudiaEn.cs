using System;
using System.Collections.Generic;
using Core.entities;

namespace DataAccess.Models;

public partial class EstudiaEn: IEntity
{
    public int Cedula { get; set; }
}
