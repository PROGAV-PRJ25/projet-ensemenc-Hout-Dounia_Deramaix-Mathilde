public class Plante
{
    //-------------  PROPRIETES DE LA PLANTE
    public string? Nom { get; set; }
    public string? Nature { get; set; }
    public string? SolPrefere { get; set; }
    public double Espacement { get; set; }
    public double SurfaceNecessaire { get; set; }
    public int VitesseCroissance { get; set; }
    public string? BesoinEau { get; set; }
    public string? BesoinLumiere { get; set; }
    public int NbrDeMoisSansLumConsecutif { get; set; } = 0;
    public double TemperaturePrefereeMin { get; set; }
    public double TemperaturePrefereeMax { get; set; }
    public int EsperanceDeVie { get; set; } // nbr de mois de vie max peu importe les conditions
    public int Production { get; set; }
    public int NbrMoisDeCroissance { get; private set; } = 0;
    public int NbrMoisAvantRecolte { get; private set; }
    public int StockSemisDisponible { get; private set; } = 0;
    public int NbrMoisMaladeConsecutif { get; private set; } = 0;


    //-------------  ETAT DE LA PLANTE
    public bool EstMalade { get; set; } = false;
    public bool EstMorte { get; private set; } = false;
    public bool EstSemee { get; private set; } = false;
    public bool EstArrosee { get; private set; } = false;
    public bool EstDesherbee { get; private set; } = false;
    public bool EstRecoltable
    {
        get
        {
            return NbrMoisDeCroissance >= NbrMoisAvantRecolte;
        }
    }

    public Plante(string nom, string nature, string solPref, double espacement, double surfaceNecessaire,
    int vitesseCroissance, string besoinEau, int nbrDeMoisSansLumConsecutif, double temperaturePreferemin, double temperaturePreferemax,
    int esperanceVie, int production, int nbrMoisAvantRecolte)
    {
        Nom = nom;
        Nature = nature;
        SolPrefere = solPref;
        Espacement = espacement;
        SurfaceNecessaire = surfaceNecessaire;
        VitesseCroissance = vitesseCroissance;
        BesoinEau = besoinEau;
        NbrDeMoisSansLumConsecutif = nbrDeMoisSansLumConsecutif;
        TemperaturePrefereeMin = temperaturePreferemin;
        TemperaturePrefereeMax = temperaturePreferemax;
        EsperanceDeVie = esperanceVie;
        Production = production;
        NbrMoisAvantRecolte = nbrMoisAvantRecolte;
    }


    public void Semer() //utilisée dans Terrain.cs
    {
        EstSemee = true;
    }



    public void Arroser()
    {
        if (EstSemee)
        {
            EstArrosee = true;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($" Impossible d’arroser {Nom} car elle n’est pas encore semée.");
            Console.ResetColor();
        }
    }

    // Méthode pour vérifier si les conditions sont respectées
    private bool ConditionsRespectees(string typeSol, string humiditeTerrain, string ensoleillement, int temperatureActuelle)
    {
        int totalConditions = 4;
        int conditionsOk = 0;

        if (SolPrefere == typeSol) conditionsOk++;
        if (BesoinEau == humiditeTerrain) conditionsOk++;
        if (BesoinLumiere == ensoleillement) conditionsOk++;
        if (temperatureActuelle >= TemperaturePrefereeMin && temperatureActuelle <= TemperaturePrefereeMax) conditionsOk++;

        bool respectees = conditionsOk > totalConditions / 2;
        EstMorte = !respectees;

        return respectees;
    }


    public void Croissance(string typeSol, string humiditeTerrain, string ensoleillement, string richesseSol, int temperatureActuelle, Meteo meteo)
    {
        if (EstSemee && EstArrosee)
        {
            // Ajuste les cdt selon la météo
            if (meteo.Type == TypeMeteo.ForteTempete || meteo.Type == TypeMeteo.PluiesBattantes)
            {
                // Réduit croissance sous conditions extrêmes
                NbrMoisDeCroissance = Math.Max(0, NbrMoisDeCroissance - 1); // réduire un mois de croissance
            }
            if (ConditionsRespectees(typeSol, humiditeTerrain, ensoleillement, temperatureActuelle))
            {
                NbrMoisDeCroissance++;
                VitesseCroissance++;
            }
        }
        else if (EstSemee)
        {
            Console.WriteLine($"Besoin d’eau pour pousser. (classe Plante.cs)");
        }
    }


    public void Recolter()
    {
        if (EstRecoltable)
        {
            Console.WriteLine($" Récolte de {Production} {Nom}(s) !");
            StockSemisDisponible += Production;
            Console.WriteLine($"{StockSemisDisponible} semis supplémentaires sont disponibles (classe Plante.cs)");
            EstSemee = false;
            NbrMoisDeCroissance = 0;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"N’est pas encore prête à être récoltée (classe Plante.cs)");
            Console.ResetColor();
        }
    }
    public double ProbabiliteContamination()
    {
        Random random = new Random();
        return random.Next(0, 100);  // génère une valeur entre 0 et 99
    }


    public void EtreMalade()
    {
        double probabilitéContamination = ProbabiliteContamination();
        //verif contamination
        if (probabilitéContamination < 20)  // Si la proba est inférieure à 20%
        {
            EstMalade = true;
        }

        // CONTAMINATATION
        // NBR DE JOUR MAX AVANT MORT

    }

    //DESHERBER 



    public override string ToString()
    {
        return "";
    }
}
