public abstract class Plante
{
    public string? NomPlante { get; set; }
    public string? Nature { get; set; } 
    public string? SolPrefere { get; set; } 
    public double Espacement { get; set; } 
    public double SurfaceNecessaire { get; set; } 
    public string? VitesseCroissance { get; set; } 
    public string? BesoinEau { get; set; }
    public string? BesoinLumiere { get; set; }
    public string? BesoinNutriment {get ; set ; }
    public int TemperaturePreferee {get ; set; }
    public string? Maladie {get ; set; }
    public int EsperanceDeVie { get; set; } 
    public int ProductionMax { get; set; }

    public Plante ( string nomPlante , string nature , string solPref , double espacement , double surfanceNecessaire, string vitesseCroissance , string besoinEau, string besoinLum, string besoinNutriment , int temperaturePref , string maladie, int esperanceVie, int productionmax)
    {
        NomPlante = nomPlante ; 
        Nature = nature; 
        SolPrefere = solPref ; 
        Espacement = espacement ; 
        SurfaceNecessaire = surfanceNecessaire ; 
        VitesseCroissance = vitesseCroissance; 
        BesoinEau = besoinEau ; 
        BesoinLumiere = besoinLum; 
        BesoinNutriment = besoinNutriment; 
        TemperaturePreferee = temperaturePref ; 
        Maladie= maladie ; 
        EsperanceDeVie = esperanceVie ; 
        ProductionMax = productionmax ; 
    }
}
