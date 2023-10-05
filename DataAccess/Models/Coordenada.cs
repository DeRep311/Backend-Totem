using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Coordenada
{
    public int Id { get; set; }

    public float CooX { get; set; }

    public float CooY { get; set; }

    public int Foto { get; set; }
}
