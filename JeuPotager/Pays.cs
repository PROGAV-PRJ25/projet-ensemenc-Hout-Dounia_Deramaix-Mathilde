public class Pays
{
    public string? NomPays { get; set; }
    public string? Capitale { get; set; }
    public Terrain Terrain { get; set; }

    public Pays(string nom, string capitale, Terrain terrain)
    {
        NomPays = nom;
        Capitale = capitale;
        this.Terrain = terrain;
    }
    public Pays(string nom, string capitale)
    {
        NomPays = nom;
        Capitale = capitale;
        this.Terrain = new Terrain(nomTerrain, superficieTerrain, typeSol, humidite, ensoleillement, capaciteMax);
    }

    public void addTerrain(Terrain terrain)
    {
        this.Terrain = terrain;
    }
}