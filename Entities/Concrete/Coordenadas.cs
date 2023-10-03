using System;
using System.Collections.Generic;
using Core.entities;

public class Coordenadas : IEntity {


    public Coordenadas() {

        Coordenada = new double[Coo_x.Length][];
       for (int i = 0; i <= Coo_x.Length; i++)
       {
            Coordenada[i]= new double[2];
            Coordenada[i][0] = Coo_x[i];
            Coordenada[i][1] = Coo_y[i];
       }
        
    }

    public String Id {get; set;}

    public double [] Coo_x {get; set;}
    public double [] Coo_y {get; set;}
    public double [][] Coordenada;

    public Byte [] Foto {get; set;}

}