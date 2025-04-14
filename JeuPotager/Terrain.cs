using System.Dynamic;

public class Terrain{
    public string? NomTerrain{get; set; }
    public double SuperficieTerrain{get; set; }
    public string? TypeSol {get; set; }
    public string? Humidite {get; set; }
    public string? Ensoleillement{get; set; }
    public int CapaciteMaxPlante {get; set; }

    public Terrain( string nomTerrain, double superficieTerrain, string typeSol, string humidite, string ensoleillement, int capaciteMax)
    {
        NomTerrain = nomTerrain ; 
        SuperficieTerrain = superficieTerrain ; 
        TypeSol = typeSol ; 
        Humidite = humidite ; 
        Ensoleillement = ensoleillement ;
        CapaciteMaxPlante = capaciteMax ; 
    }

}