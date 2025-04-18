public class TerrainLangueDeChat : Terrain
{
    
    public TerrainLangueDeChat()
    {
        NomTerrain = "Langue de Chat";
        TypeSol = "acidulé";
        Humidite = "élevée";
        Ensoleillement = "fort";
        CapaciteMaxPlante = 20;
        
        
    }

    public override string toString()

    {
        Console.WriteLine($"🌈 Terrain : {NomTerrain} , plante cultivée : {PlanteCultivee}");
    }
}
