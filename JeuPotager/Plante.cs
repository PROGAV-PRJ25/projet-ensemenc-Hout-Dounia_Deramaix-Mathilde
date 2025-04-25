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
    public string? BesoinNutriment { get; set; }
    public int TemperaturePreferee { get; set; }
    public string? Maladie { get; set; }
    public int EsperanceDeVie { get; set; }
    public int ProductionMax { get; set; }

    public bool EstSemee { get; private set; } = false;
    public bool EstArrosee { get; private set; } = false;
    public int JoursCroissance { get; private set; } = 0;
    public bool EstRecoltable => JoursCroissance >= EsperanceDeVie / 2;

    public Plante(string nomPlante, string nature, string solPref, double espacement, double surfanceNecessaire, string vitesseCroissance, string besoinEau, string besoinLum, string besoinNutriment, int temperaturePref, string maladie, int esperanceVie, int productionmax)
    {
        NomPlante = nomPlante;
        Nature = nature;
        SolPrefere = solPref;
        Espacement = espacement;
        SurfaceNecessaire = surfanceNecessaire;
        VitesseCroissance = vitesseCroissance;
        BesoinEau = besoinEau;
        BesoinLumiere = besoinLum;
        BesoinNutriment = besoinNutriment;
        TemperaturePreferee = temperaturePref;
        Maladie = maladie;
        EsperanceDeVie = esperanceVie;
        ProductionMax = productionmax;
    }
    public virtual void Semer()
    {
        if (!EstSemee)
        {
            EstSemee = true;
            Console.WriteLine($"{NomPlante} a été semée !");
        }
        else
        {
            Console.WriteLine($"{NomPlante} est déjà semée.");
        }
    }

    public virtual void Arroser()
    {
        if (EstSemee)
        {
            EstArrosee = true;
            Console.WriteLine($"{NomPlante} a été arrosée !");
        }
        else
        {
            Console.WriteLine($"Impossible d’arroser {NomPlante} car elle n’est pas encore semée.");
        }
    }

    public virtual void Croissance()
    {
        if (EstSemee && EstArrosee)
        {
            JoursCroissance++;
            EstArrosee = false; // On considère qu’il faut arroser chaque jour
            Console.WriteLine($"{NomPlante} a grandi. Jours de croissance : {JoursDeCroissance}.");
        }
        else if (EstSemee)
        {
            Console.WriteLine($"{NomPlante} a besoin d’eau pour pousser.");
        }
    }

    public virtual void Recolter()
    {
        if (EstRecoltable)
        {
            Console.WriteLine($"Récolte de {ProductionMax} {NomPlante}(s) !");
            EstSemee = false;
            JoursCroissance = 0;
        }
        else
        {
            Console.WriteLine($"{NomPlante} n’est pas encore prête à être récoltée.");
        }
    }


}
