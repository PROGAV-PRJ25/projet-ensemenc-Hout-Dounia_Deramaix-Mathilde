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

    private Random random = new Random();

    public Meteo() //météo par défaut
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

    public double GenererTemperature(double temperatureConsigneTerrain, int numeroMois)
    {
        int moisIndice = (numeroMois - 1 + 12) % 12;
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

    public void GenererMeteo()
    {
        Type = (TypeMeteo)random.Next(Enum.GetValues(typeof(TypeMeteo)).Length);

        switch (Type)
        {
            case TypeMeteo.Ensoleille:
            case TypeMeteo.Nuageux:
                TauxPrecipitations = 0;
                break;

            case TypeMeteo.PetitePluie:
                TauxPrecipitations = random.Next(1, 5);
                break;

            case TypeMeteo.Pluie:
                TauxPrecipitations = random.Next(5, 20);
                break;

            case TypeMeteo.PluiesBattantes:
                TauxPrecipitations = random.Next(20, 50);
                break;

            case TypeMeteo.ForteTempete:
                TauxPrecipitations = random.Next(50, 100);
                break;

            default:
                TauxPrecipitations = 0;
                break;
        }
    }

    public void AfficherConditions()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine();
        Console.WriteLine("🌦️  Informations Météo Actuelles");
        Console.WriteLine();
        Console.ResetColor();
        Console.WriteLine($"🌡️  Température : {Temperature}°C");
        Console.WriteLine($"💧  Précipitations : {TauxPrecipitations} mm");
        Console.WriteLine($"📡  Type de météo : {Type}\n");
    }
}
