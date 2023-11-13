using System;
using System.Collections.Generic;
using Core.entities;

namespace Base.Models;

public partial class Plano:IEntity
{
    public string codigo_p { get; set; }

    public string plano_img { get; set; }
}
