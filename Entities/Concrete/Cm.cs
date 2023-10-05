using System;
using System.Collections.Generic;
using Core.entities;

namespace DataAccess.Models;

public partial class Cm: IEntity
{
    public int IdC { get; set; }

    public int IdM { get; set; }
}
