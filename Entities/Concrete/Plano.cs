using System;
using System.Collections.Generic;
using Core.entities;

namespace DataAccess.Models;

public partial class Plano: IEntity
{
    public string CodigoP { get; set; }

    public int? PlanoImg { get; set; }
}
