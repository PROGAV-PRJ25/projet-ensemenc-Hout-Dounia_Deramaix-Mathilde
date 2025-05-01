public enum TypeMeteo
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
