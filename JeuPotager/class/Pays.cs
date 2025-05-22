public class Pays
{
    public string? Nom { get; set; }
    public List<Terrain> Terrains { get; set; } = new List<Terrain>(); //Un pays peut avoir plusieurs terrain

    public Pays(string nom)
    {
        Nom = nom;
    }

    public void AjouterTerrain(Terrain terrain) //Ajout un terrain à la liste Terrains de Pays.cs
    {
        Terrains.Add(terrain);
    }

}