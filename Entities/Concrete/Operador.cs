using System;
using System.Collections.Generic;
using Core.entities;

namespace Base.Models;

public partial class Operador : IEntity
{
    public int? Cedula { get; set; }

    public virtual Usuario CedulaNavigation { get; set; }
}
