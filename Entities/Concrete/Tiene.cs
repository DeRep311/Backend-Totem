using System;
using System.Collections.Generic;
using Core.entities;

namespace DataAccess.Models;

public partial class Tiene: IEntity
{
    public string Codigo { get; set; }

    public int Id { get; set; }
}
