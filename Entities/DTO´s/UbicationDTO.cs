using System;
using System.Collections.Generic;
using Base.Models;

public class UbicationDTO {
    public string CodigoUbicaciones { get; set; }
    public string Nombre { get; set; }
    public bool Publico { get; set; }
    public bool Privado { get; set; }
    public List<Coordenada> IdCs { get; set; }

    public String CodigoP { get; set; }

    public UbicacionesDependiente? ubicacionesDependiente { get; set; }
}