using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Core.entities;

namespace Base.Models;

public partial class Horarios:IEntity
{
    [NotMapped]
    public int id_h { get; set; }

    public string hora_inicio { get; set; }

    public string hora_final { get; set; }

    public string nombre_del_dia { get; set; }
}
