using System;
using System.Collections.Generic;
using Core.entities;

namespace Base.Models;

public partial class Plano : IEntity
{
    public string CodigoP { get; set; }

    public string PlanoImg { get; set; }
}
