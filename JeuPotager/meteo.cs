public class Meteo
{
    public double Temperature { get; set; }
    public string? Humidite { get; set; }
    public double TauxPrécipitations { get; private set; } //mm



    public Meteo(double temperature, string humidite, double tauxprecip)
    {
        Temperature = temperature;
        Humidite = humidite;
        TauxPrécipitations = tauxprecip;
    }
}