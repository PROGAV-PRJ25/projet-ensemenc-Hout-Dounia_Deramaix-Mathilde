public class Plante
{
    public string? Nom { get; set; }
    public string? Nature { get; set; }
    public string? SolPrefere { get; set; }
    public double Espacement { get; set; }
    public double SurfaceNecessaire { get; set; }
    public string? VitesseCroissance { get; set; }
    public string? BesoinEau { get; set; } //conditions préf
    public string? BesoinLumiere { get; set; } //conditions préf
    public string? BesoinNutriment { get; set; } //conditions préf
    public int TemperaturePreferee { get; set; } //conditions préf
    public bool EstMalade { get; set; }
    public int EsperanceDeVie { get; set; }
    public int ProductionMax { get; set; }
    public bool EstSemee { get; private set; } = false;
    public bool EstArrosee { get; private set; } = false;
    public int JoursCroissance { get; private set; } = 0;
    /* public List<string> SaisonsDeSemis { get; set; } */
    public int SemisDisponibles { get; private set; }
    public bool EstMorte { get; private set; }


    public bool EstRecoltable
    {
        get
        {
            // Vérifie si la plante a eu une croissance suffisante et que les conditions sont respectées
            return JoursCroissance >= 7;  // on peut modifier pazr ex : 7 jours de croissance pour être récoltable
        }
    }


    public Plante(string nom, string nature, string solPref, double espacement, double surfaceNecessaire, string vitesseCroissance, string besoinEau, string besoinLum, string besoinNutriment, int temperaturePref, int esperanceVie, int productionmax /* List<string> saisonsDeSemis */)
    {
        Nom = nom;
        Nature = nature;
        SolPrefere = solPref;
        Espacement = espacement;
        SurfaceNecessaire = surfaceNecessaire;
        VitesseCroissance = vitesseCroissance;
        BesoinEau = besoinEau;
        BesoinLumiere = besoinLum;
        BesoinNutriment = besoinNutriment;
        TemperaturePreferee = temperaturePref;
        EsperanceDeVie = esperanceVie;
        ProductionMax = productionmax;
        /* SaisonsDeSemis = saisonsDeSemis; */
        SemisDisponibles = 0;
        EstMorte = false;
        EstMalade = false;

    }
    // methode semer juste pr mettre à jour les booleens car dans terrain.cs la methode semer ne change pas
    // l'etat des booleens 
    public void Semer()
    {
        EstSemee = true;
        EstArrosee = false;
        //Console.WriteLine($"{Nom} a été semée !");
    }




    public void Arroser()
    {
        if (EstSemee)
        {
            EstArrosee = true;
            Console.WriteLine($"\n{Nom} a été arrosée ! 🚿 \n");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($" Impossible d’arroser {Nom} car elle n’est pas encore semée.");
            Console.ResetColor();
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

    public void Croissance(string humiditeTerrain, string ensoleillement, string richesseSol, int temperatureActuelle, Meteo meteo)
    {
        if (EstSemee && EstArrosee)
        {
            // Ajuste les cdt selon la météo
            if (meteo.Type == TypeMeteo.ForteTempete || meteo.Type == TypeMeteo.PluiesBattantes)
            {
                // Réduit croissance sous conditions extrêmes
                Console.WriteLine($"{Nom} subit un ralentissement à cause de la tempête !");
                JoursCroissance = Math.Max(0, JoursCroissance - 1); // réduire un jour de croissance
            }
            if (ConditionsRespectees(humiditeTerrain, ensoleillement, richesseSol, temperatureActuelle))
            {
                JoursCroissance++;
                Console.WriteLine($"{Nom} a grandi. Jours de croissance : {JoursCroissance}");
                double probabilitéContamination = ProbabiliteContamination();
                //verif contamination
                if (probabilitéContamination < 0.2)  // Si la proba est inférieure à 20%
                {
                    EstMalade = true;
                    Console.WriteLine($"{Nom} a été contaminée et est malade ! ");
                }
            }
            else
            {
                Console.WriteLine($"{Nom} ne peut pas croître, les conditions ne sont pas respectées.");
            }
        }
        else if (EstSemee)
        {
            Console.WriteLine($"{Nom} a besoin d’eau pour pousser.");
        }
    }

    // Méthode pour récolter la plante
    public void Recolter()
    {
        if (EstRecoltable)
        {
            Console.WriteLine($" Récolte de {ProductionMax} {Nom}(s) !");
            SemisDisponibles += 2;  // Ajoute 2 semis à chaque récolte
            Console.WriteLine($"{SemisDisponibles} semis supplémentaires sont disponibles");

            EstSemee = false;
            JoursCroissance = 0;

        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($" {Nom} n’est pas encore prête à être récoltée");
            Console.ResetColor();
        }
    }
    public double ProbabiliteContamination()
    {
        Random random = new Random();
        return random.NextDouble();  // génère une valeur entre 0 et 1
    }

    public override string ToString()
    {
        return "";
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
