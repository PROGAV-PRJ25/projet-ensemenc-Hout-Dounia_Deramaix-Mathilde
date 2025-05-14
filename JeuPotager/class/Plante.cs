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
    public double TemperaturePrefereeMin { get; set; }
    public double TemperaturePrefereeMax { get; set; }
    public int EsperanceDeVie { get; set; } // nbr de mois de vie max peu importe les conditions
    public int Production { get; set; }
    public int NbrMoisDeCroissance { get;  set; } = 0;
    public int NbrMoisAvantRecolte { get; private set; } // A expiquer l'appelation
    public int NbrMoisMaladeConsecutif { get; private set; } = 0;
    public int NbrMoisAvecMauvaisesHerbesConsecutif { get; private set; } = 0;
    public double PrixUnitaireDeLaPlante { get; private set; }


    //-------------  ETAT DE LA PLANTE
    public bool EstMalade { get; set; } = false;
    public bool EstMorte { get; set; } = false;
    public bool EstSemee { get;  set; } = false;
    public bool EstArrosee { get;  set; } = false;
    public bool EstDesherbee { get;  set; } = false;
    public bool EstEntoureeParMauvaisesHerbes { get;  set; } = false;
    public bool AGrandi { get;  set; } = false;
    public bool EstRecoltable
    {
        get
        {
            return NbrMoisDeCroissance >= NbrMoisAvantRecolte;
        }
    }

    public Plante(string nom, string nature, string solPref, double espacement, double surfaceNecessaire,
    int vitesseCroissance, string besoinEau, double temperaturePreferemin, double temperaturePreferemax,
    int esperanceVie, int production, int nbrMoisAvantRecolte, double prixUnitaireDeLaPlante)
    {
        Nom = nom;
        Nature = nature;
        SolPrefere = solPref;
        Espacement = espacement;
        SurfaceNecessaire = surfaceNecessaire;
        VitesseCroissance = vitesseCroissance;
        BesoinEau = besoinEau;
        TemperaturePrefereeMin = temperaturePreferemin;
        TemperaturePrefereeMax = temperaturePreferemax;
        EsperanceDeVie = esperanceVie;
        Production = production;
        NbrMoisAvantRecolte = nbrMoisAvantRecolte;
        PrixUnitaireDeLaPlante = prixUnitaireDeLaPlante;
    }

    public void Grandir()
    {
        if (NbrMoisDeCroissance >= (NbrMoisAvantRecolte / 2))
        {
            AGrandi = true;
        }
    }

    public void Semer() //utilisée dans Terrain.cs
    {
        EstSemee = true;
    }

    public void Desherber() //utilisée dans Terrain.cs
    {
        EstEntoureeParMauvaisesHerbes = false;
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
        int nbrConditionsOK = 0;

        if (SolPrefere == typeSol) nbrConditionsOK++;
        if (BesoinEau == humiditeTerrain) nbrConditionsOK++;
        if (BesoinLumiere == ensoleillement) nbrConditionsOK++;
        if (temperatureActuelle >= TemperaturePrefereeMin && temperatureActuelle <= TemperaturePrefereeMax) nbrConditionsOK++;

        bool respectees = nbrConditionsOK >= totalConditions / 2;
        EstMorte = !respectees;
        return respectees;
    }


    public void Croissance(string typeSol, string humiditeTerrain, string ensoleillement, int temperatureActuelle, Meteo meteo)
    {
        if (EstSemee && EstArrosee)
        {
            // Ajuste les cdt selon la météo
            if (meteo.Type == TypeMeteo.ForteTempete || meteo.Type == TypeMeteo.PluiesBattantes)
            {
                // Réduit croissance sous conditions extrêmes
                NbrMoisDeCroissance = Math.Abs(NbrMoisDeCroissance - 2); // réduire un mois de croissance
            }
            if (ConditionsRespectees(typeSol, humiditeTerrain, ensoleillement, temperatureActuelle))
            {
                NbrMoisDeCroissance++;
                VitesseCroissance++;
            }
        }
    }

    public int RecolterPlante()
    {
        if (EstRecoltable)
        {
            EstSemee = false;
            EstArrosee = false;
            NbrMoisDeCroissance = 0;
            NbrMoisAvecMauvaisesHerbesConsecutif = 0;
            NbrMoisMaladeConsecutif = 0;
            return Production;
        }
        else
        {
            return 0;
        }
    }

    public void ApparaitreMauvaiseHerbe()
    {
        Random random = new Random();
        double probabiliteMauvaisesHerbes = random.Next(0, 100);  // génère une valeur entre 0 et 99

        if (probabiliteMauvaisesHerbes < 30)  // Si la proba est inférieure à 30%
        {
            EstEntoureeParMauvaisesHerbes = true;
        }

        if (EstEntoureeParMauvaisesHerbes == true)
        {
            NbrMoisAvecMauvaisesHerbesConsecutif++;
        }

        if (NbrMoisAvecMauvaisesHerbesConsecutif > 3)
        {
            EstMorte = true;
        }
    }

    public void EtreMalade()
    {
        Random random = new Random();
        double probabilitéContamination = random.Next(0, 100);  // génère une valeur entre 0 et 99
        //verif contamination
        if (probabilitéContamination < 10)  // Si la proba est inférieure à 20%
        {
            EstMalade = true;
        }
        if (EstMalade == true)
        {
            NbrMoisMaladeConsecutif++;
        }
        if (NbrMoisMaladeConsecutif > 2)
        {
            EstMorte = true;
        }

    }

    public override string ToString()
    {
        return "";
    }
}
