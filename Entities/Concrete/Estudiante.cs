using System;
using System.Collections.Generic;
using Core.entities;
namespace DataAccess.Models;

public partial class Estudiante:IEntity
{
    public int Cedula { get; set; }

    public virtual Usuario CedulaNavigation { get; set; }
}
