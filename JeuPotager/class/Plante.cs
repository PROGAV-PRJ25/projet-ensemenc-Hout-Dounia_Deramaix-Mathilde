public abstract class Plante
{
    public string? Nom { get; set; }
    public string? Nature { get; set; }
    public string? SolPrefere { get; set; }
    public string? BesoinEau { get; set; }
    public double TemperaturePrefereeMin { get; set; }
    public double TemperaturePrefereeMax { get; set; }
    public int Production { get; set; } //Nombre de semis récoltés après la récolte d'une plante
    public int NbrMoisDeCroissance { get; set; } = 0;
    public int NbrMoisAvantFloraison { get; private set; } //Nombre de mois nécessaires jusqu’à ce que la plante fleurisse
    public int NbrMoisMaladeConsecutif { get; set; } = 0; //Nombre de mois écoulés depuis la contamination de la plante
    public int NbrMoisAvecMauvaisesHerbesConsecutif { get; set; } = 0;
    public int NbrMoisRecoltableMaisPasRecoltee { get; set; } = 0;
    public double PrixUnitaireDeLaPlante { get; private set; } //Pour la fonctionnalité bonus de vente, c'est le prix unitaire de la plante


    //-------------  ETAT DE LA PLANTE (BOOLEEN)
    public bool EstMalade { get; set; } = false;
    public bool EstMorte { get; set; } = false;
    public bool EstSemee { get; set; } = false;
    public bool EstArrosee { get; set; } = false;
    public bool EstDesherbee { get; set; } = false; //Retrait des mauvaises herbes
    public bool EstEntoureeParMauvaisesHerbes { get; set; } = false;
    public bool AGrandi { get; set; } = false;
    public bool EstRecoltable
    //La plante est récoltable que le temps de croissance (un certain nombre de mois) est supérieur ou égale
    //au nombre de mois nécessaires jusqu’à ce que la plante fleurisse 
    {
        get
        {
            return NbrMoisDeCroissance >= NbrMoisAvantFloraison;
        }
        set { }

    }

    public Plante(string nom, string nature, string solPref, string besoinEau, double temperaturePreferemin,
    double temperaturePreferemax, int production, int nbrMoisAvantFloraison, double prixUnitaireDeLaPlante)
    {
        Nom = nom;
        Nature = nature;
        SolPrefere = solPref;
        BesoinEau = besoinEau;
        TemperaturePrefereeMin = temperaturePreferemin;
        TemperaturePrefereeMax = temperaturePreferemax;
        Production = production;
        NbrMoisAvantFloraison = nbrMoisAvantFloraison;
        PrixUnitaireDeLaPlante = prixUnitaireDeLaPlante;
    }

    public abstract Plante Cloner(); // Méthode abstraite pour créer une copie indépendante d’une plante.
                                     // Sinon toutes les plantes agissent de manière identique



    /////------------------------------- Méthodes liées aux actions du joueurs

    public void Grandir() //Remplacer 🌱 par 🌿 lorsque le temps de croissance de la plante à atteint 
                          // la moitié du nombre de mois nécessaire à la floraison
    {
        Console.WriteLine(NbrMoisDeCroissance);
        if (NbrMoisDeCroissance >= (NbrMoisAvantFloraison / 2))
            AGrandi = true;
        else if (NbrMoisDeCroissance < (NbrMoisAvantFloraison / 2))
            AGrandi = false;
    }

    public void Semer() // Marque la plante comme semée
    {
        EstSemee = true;
    }

    public void Desherber() // Retire les mauvaises herbes autour de la plante
                            // réintialise le compteur de mois en présence de mauvaises herbes
    {
        EstEntoureeParMauvaisesHerbes = false;
        NbrMoisAvecMauvaisesHerbesConsecutif = 0;
    }

    public void RetirerPlanteMorte() //Réinitialise tous les états de la plante après sa mort avant de la retirer
    {
        EstSemee = false;
        EstMalade = false;
        AGrandi = false;
        EstEntoureeParMauvaisesHerbes = false;
    }

    public void Arroser() //Marque comme arrosée une plante que si elle est semée sinon message d'erreur
    {
        if (EstSemee)
            EstArrosee = true;
    }

    public int RecolterPlante()
    //Récolte la plante si elle est prête.
    // Réinitialise son état
    // Retourne le nombre de semis récoltés (Production ou 0 si la plante n'est pas récoltable)
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
            return 0;
    }


    /////----------------- Méthodes liées à la croissance et aux événements aléatoires affectant les plantes

    private bool ConditionsRespectees(string typeSol, string humiditeTerrain, double temperatureActuelle, TypeMeteo meteoActuelle)
    // Méthode pour vérifier si les conditions sont respectées à l'aide d'un booléen
    // Si au moins 50% des conditions sont défavorables, les plantes meurent
    {
        int totalConditions = 4;
        int nbrConditionsFavorablesValidees = 0; //Compteur de conditions favorables qui sont validées

        if (SolPrefere == typeSol)
            nbrConditionsFavorablesValidees++;

        if (BesoinEau == humiditeTerrain)
            nbrConditionsFavorablesValidees++;

        if (meteoActuelle == TypeMeteo.Ensoleille || meteoActuelle == TypeMeteo.Pluie
        || meteoActuelle == TypeMeteo.PetitePluie || meteoActuelle == TypeMeteo.Nuageux)
            //Ceux sont les besoin en lumière de la plante (ensoleillé, Pluie, Nuagueux et petitePluie)
            nbrConditionsFavorablesValidees++;

        if ((temperatureActuelle >= TemperaturePrefereeMin) && (temperatureActuelle <= TemperaturePrefereeMax))
            nbrConditionsFavorablesValidees++;

        bool conditionsRespectees = nbrConditionsFavorablesValidees >= (totalConditions / 2.0); //Au moins 50% des conditions favorables respactées
        EstMorte = !conditionsRespectees;
        return conditionsRespectees;
    }

    public bool Croissance(string typeSol, string humiditeTerrain, double temperatureActuelle, Meteo meteo, TypeMeteo meteoActuelle)
    // Méthode qui gère la croissance de la plante
    {
        if (EstSemee)//Pour croitre une plante doit être semée
        {
            if (meteo.Type == TypeMeteo.ForteTempete || meteo.Type == TypeMeteo.PluiesBattantes)
            {
                NbrMoisDeCroissance = Math.Max(0, NbrMoisDeCroissance - 2);
                //Si mauvaise météo, le temps de croissance de la plante va se rallonger 
                //On simule cela en diminuant le nombre de mois déjà passés en croissance
                // utilisation de Math.Max pour que le nombre de mois ne soit pas négatif
            }
            if (ConditionsRespectees(typeSol, humiditeTerrain, temperatureActuelle, meteoActuelle))
            // si la méthode ConditionsRespectees renvoie true, la plante ...
            {
                Grandir(); //... grandit
                NbrMoisDeCroissance++;

                //les return servent à récupérer si oui ou non les conditions sont défavorables pour la plante
                return false; // Conditions pas défavorables;
            }
            else
                return true; // Conditions défavorables;

        }
        return false; // Conditions pas défavorables;
    }

    public abstract void ApparaitreMauvaiseHerbe(); //Attitudes différentes selon le type de plantes
    public abstract void EtreMalade(Random random); //Attitudes différentes selon le type de plantes
    public abstract void Pourrir(Plante plante);//Attitudes différentes selon le type de plantes



    public override string ToString()//Résumé des conditions préférées des plantes
    {
        return $"        Sol préféré : {SolPrefere}\n" +
               $"        Température préféré : de {TemperaturePrefereeMin} à {TemperaturePrefereeMax}\n" +
               $"        Humidité préférée du sol : {BesoinEau}\n";
    }
}
