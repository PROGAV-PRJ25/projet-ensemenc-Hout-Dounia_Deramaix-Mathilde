using System.Dynamic;

public class Terrain
{
    public string? NomTerrain { get; set; }
    public double SuperficieTerrain { get; set; }
    public string? TypeSol { get; set; }
    public string? Humidite { get; set; }
    public string? Ensoleillement { get; set; }
    public int CapaciteMaxPlante { get; set; }
    public List<Plante> PlantesCultivees { get; set; } = new List<Plante>();


    public Terrain(string nomTerrain, double superficieTerrain, string typeSol, string humidite, string ensoleillement, int capaciteMax)
    {
        NomTerrain = nomTerrain;
        SuperficieTerrain = superficieTerrain;
        TypeSol = typeSol;
        Humidite = humidite;
        Ensoleillement = ensoleillement;
        CapaciteMaxPlante = capaciteMax;
    }
    public bool AjouterPlante(Plante plante)
    {
        if (PlantesCultivees.Count < CapaciteMaxPlante)
        {
            PlantesCultivees.Add(plante);
            return true;
        }
        return false;
    }
    public override string ToString()
    {
        return $"Terrain {NomTerrain} ({SuperficieTerrain} m²)\n" +
               $"Type de sol : {TypeSol}, Humidité : {Humidite}, Ensoleillement : {Ensoleillement}\n" +
               $"Capacité max : {CapaciteMaxPlante} plantes\n" +
               $"Plantes présentes : {PlantesCultivees.Count}";
    }




}