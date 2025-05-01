public class Pays
{
    public string? Nom { get; set; }
    public List<Terrain> Terrains { get; set; } = new List<Terrain>();


    public Pays(string nom)
    {
        Nom = nom;
    }

    public void AddTerrain(Terrain terrain)
    {
        Terrains.Add(terrain);
    }
    public void RemoveTerrain(Terrain terrain)
    {
        Terrains.Remove(terrain);
    }

    public override string ToString()
    {
        return $"Pays {Nom}\n";
    }
}