/*public enum TypeMeteo
{
    Ensoleille, //soleil +
    Nuageux,    // soleil -
    PetitePluie,    // pluie +
    Pluie,  // pluie ++
    PluiesBattantes,    // pluie +++
    ForteTempete, //vent +++
}

public class Meteo
{
    public double Temperature { get; set; }
    public double TauxPrecipitations { get; private set; } // mm
    public double PourcentageChancePluie { get; set; }
    public TypeMeteo Type { get; private set; }


    public Meteo(double temperature, double tauxPrecipitations, double pourcentageChancePluie, TypeMeteo type)
    {
        Temperature = temperature;
        TauxPrecipitations = tauxPrecipitations;
        PourcentageChancePluie = pourcentageChancePluie;
        Type = type;
    }

    public override string ToString()
    {
        return $"Température : {Temperature}°C\n" +
               $"Précipitations : {TauxPrecipitations} mm\n" +
               $"Type de météo : {Type}\n" +
               $"Chance de pluie le mois prochain : {PourcentageChancePluie}%";
    }
}
*/ 


public enum TypeMeteo
{
    Ensoleille,        // ☀️ soleil +
    Nuageux,           // ☁️ soleil -
    PetitePluie,       // 🌦️ pluie +
    Pluie,             // 🌧️ pluie ++
    PluiesBattantes,   // 🌧️🌧️ pluie +++
    ForteTempete       // 🌪️ vent +++
}

public class Meteo
{
    public double Temperature { get; private set; }
    public double TauxPrecipitations { get; private set; } // mm
    public double PourcentageChancePluie { get; private set; }
    public TypeMeteo Type { get; private set; }

    private Random random = new Random();

    public Meteo()
    {
        GenererMeteo();
    }

    public void GenererMeteo()
    {
        Temperature = random.Next(0, 35); // 0 à 35°C
        TauxPrecipitations = Math.Round(random.NextDouble() * 100, 1); // 0 à 100 mm
        PourcentageChancePluie = random.Next(0, 101); // 0 à 100 %
        Type = (TypeMeteo)random.Next(Enum.GetValues(typeof(TypeMeteo)).Length);
    }

    public void AfficherConditions()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(); 
        Console.WriteLine("🌦️  Informations Météo Actuelles");
        Console.WriteLine(); 
        Console.ResetColor();

        Console.WriteLine($"🌡️  Température : {Temperature}°C");
        Console.WriteLine($"💧 Précipitations : {TauxPrecipitations} mm");
        Console.WriteLine($"☔ Chance de pluie : {PourcentageChancePluie}%");
        Console.WriteLine($"📡 Type de météo : {Type}\n");
    }

    /*public override string ToString()
    {
        return $"Température : {Temperature}°C\n" +
               $"Précipitations : {TauxPrecipitations} mm\n" +
               $"Type de météo : {Type}\n" +
               $"Chance de pluie le mois prochain : {PourcentageChancePluie}%";
    }*/
}
