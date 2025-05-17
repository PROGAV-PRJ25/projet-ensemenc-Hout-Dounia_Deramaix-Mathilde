public enum TypeMeteo  //Définition d'une liste prédéfinie de type de météo
{
    Ensoleille,        // lumière ++   pluie = 0;
    Nuageux,           // lumière +    pluie = 0; 
    PetitePluie,       // pluie +
    Pluie,             // pluie ++
    PluiesBattantes,   // pluie +++ avec vent
    ForteTempete       // pluie +++ avec vent
}

public class Meteo
{
    public double Temperature { get; private set; }
    public double TauxPrecipitations { get; private set; }
    public TypeMeteo Type { get; private set; }

    private Random Random = new Random(); //Pour le choix du type de météo

    public Meteo() //Pour créer une météo par défaut 
    {
        Temperature = 0;
        TauxPrecipitations = 0;
        Type = TypeMeteo.Ensoleille;
    }

    public Meteo(int numeroMois, Terrain terrain)
    {
        GenererMeteo();
        GenererTemperature(terrain.TemperatureConsigne, numeroMois);
    }

    public void GenererMeteo()
    {
        Type = (TypeMeteo)Random.Next(Enum.GetValues(typeof(TypeMeteo)).Length);

        switch (Type)
        {
            case TypeMeteo.Ensoleille:
            case TypeMeteo.Nuageux:
                TauxPrecipitations = 0;
                break;

            case TypeMeteo.PetitePluie:
                TauxPrecipitations = Random.Next(1, 5);
                break;

            case TypeMeteo.Pluie:
                TauxPrecipitations = Random.Next(5, 20);
                break;

            case TypeMeteo.PluiesBattantes:
                TauxPrecipitations = Random.Next(20, 50);
                break;

            case TypeMeteo.ForteTempete:
                TauxPrecipitations = Random.Next(50, 100);
                break;

            default:
                TauxPrecipitations = 0;
                break;
        }
    }

    public double GenererTemperature(double temperatureConsigneTerrain, int numeroMois)
    //écart de température qui va être ajouté à la température consigne du terrain et cela en fonction du mois de l'année 
    {
        int moisIndice = (numeroMois - 1 + 12) % 12; // pour que le mois soit entre janvier et décembre
        List<double> ecartsMensuels = new List<double>
        {
            -5,  // Janvier
            -3,  // Février
            2,   // Mars
            5,   // Avril
            8,   // Mai
            10,  // Juin
            11,  // Juillet
            10,  // Août
            7,   // Septembre
            3,   // Octobre
            -1,  // Novembre
            -4   // Décembre
        };

        Temperature = temperatureConsigneTerrain + ecartsMensuels[moisIndice];
        return Temperature;
    }


    public override string ToString() //Résumé de la météo
    {
        return $"        Température : {Temperature}°C\n" +
               $"        Précipitations : {TauxPrecipitations} mm\n" +
               $"        Type de météo : {Type}\n";
    }
}
