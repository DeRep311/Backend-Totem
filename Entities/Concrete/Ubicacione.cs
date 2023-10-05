using System;
using System.Collections.Generic;
using Core.entities;

namespace DataAccess.Models;

public partial class Ubicacione: IEntity
{
    

    
    public string Codigo { get; set; }

    public string Nombre { get; set; }

    public string CodigoP { get; set; }
}
