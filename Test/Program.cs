using System;

public class Coordenadas
{
    public Coordenadas(string Id, double[] Coo_x, double[] Coo_y)
    {
        this.Id = Id;
        this.Coo_x = Coo_x;
        this.Coo_y = Coo_y;

        // Inicializa la matriz Coordenada
        Coordenada = new double[Coo_x.Length][];
        for (int i = 0; i < Coo_x.Length; i++)
        {
            Coordenada[i] = new double[2];
            Coordenada[i][0] = Coo_x[i];
            Coordenada[i][1] = Coo_y[i];
        }
    }

    public String Id { get; set; }
    public double[] Coo_x { get; set; }
    public double[] Coo_y { get; set; }
    public double[][] Coordenada { get; set; }
    public Byte[] Foto { get; set; }
}

public class Program
{
    static void Main()
    {
        Coordenadas coordenadas = new Coordenadas("1", new double[] { 1, 2, 3, 4, 5 }, new double[] { 4, 7, 9, 20, 30 });

        Console.WriteLine(coordenadas.Id);
        Console.WriteLine("Coo_x:");
        foreach (var x in coordenadas.Coo_x)
        {
            Console.WriteLine(x);
        }
        Console.WriteLine("Coo_y:");
        foreach (var y in coordenadas.Coo_y)
        {
            Console.WriteLine(y);
        }
        Console.WriteLine("Coordenada:");
        foreach (var punto in coordenadas.Coordenada)
        {
            Console.WriteLine($"X ({punto[0]}, Y {punto[1]})");
        }
    }
}




