public class Plante
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

    public string CroissanceVerticale { get; private set; } = "";
    public string CroissanceHorizontale { get; private set; } = "";
    public List<string> SaisonsDeSemis { get; set; }


    public bool EstRecoltable
    {
        get
        {
            // Vérifie si la plante a eu une croissance suffisante et que les conditions sont respectées
            return JoursCroissance >= 7;  // on peut modifier pazr ex : 7 jours de croissance pour être récoltable
        }
    }


    public Plante(string nomPlante, string nature, string solPref, double espacement, double surfanceNecessaire, string vitesseCroissance, string besoinEau, string besoinLum, string besoinNutriment, int temperaturePref, string maladie, int esperanceVie, int productionmax, List<string> saisonsDeSemis)
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
        SaisonsDeSemis = saisonsDeSemis;
    }

    public void Semer()
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

    public void Arroser()
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

    // Méthode pour vérifier si les conditions sont respectées
    private bool ConditionsRespectees(string humiditeTerrain, string ensoleillement, string richesseSol, int temperatureActuelle)
    {
        int conditionsOk = 0;

        if (BesoinEau == humiditeTerrain) conditionsOk++;
        if (BesoinLumiere == ensoleillement) conditionsOk++;
        if (BesoinNutriment == richesseSol) conditionsOk++;
        if (TemperaturePreferee == temperatureActuelle) conditionsOk++;

        // Retourne vrai si 50% des conditions sont respectées
        return conditionsOk >= 2;
    }

    public void Croissance(string humiditeTerrain, string ensoleillement, string richesseSol, int temperatureActuelle)
    {
        if (EstSemee && EstArrosee)
        {
            if (ConditionsRespectees(humiditeTerrain, ensoleillement, richesseSol, temperatureActuelle))
            {
                JoursCroissance++;
                Console.WriteLine($"{NomPlante} a grandi. Jours de croissance : {JoursCroissance}");
            }
            else
            {
                Console.WriteLine($"{NomPlante} ne peut pas croître, les conditions ne sont pas respectées.");
            }
        }
        else if (EstSemee)
        {
            Console.WriteLine($"{NomPlante} a besoin d’eau pour pousser.");
        }
    }

    // Méthode pour récolter la plante
    public void Recolter()
    {
        if (EstRecoltable)
        {
            Console.WriteLine($"Récolte de {ProductionMax} {NomPlante}(s) !");
            EstSemee = false;
            JoursCroissance = 0;
            CroissanceVerticale = "";
            CroissanceHorizontale = "";
        }
        else
        {
            Console.WriteLine($"{NomPlante} n’est pas encore prête à être récoltée.");
        }
    }
    public double ProbabiliteContamination()
    {
        Random random = new Random();
        return random.NextDouble();  // génère une valeur entre 0 et 1
    }

}


// a ajouter au prgrm principal pour test
// double probabilité = ProbabiliteContamination();
//if (probabilité < 0.5)  // Si la probabilité est inférieure à 0.5
//{
//Console.WriteLine("La plante a été contaminée !");
//}
//else
//{
//   Console.WriteLine("La plante n'a pas été contaminée.");
//}
