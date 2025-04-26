public class Meteo
{
    public double Temperature { get; set; }
    public string? Humidite { get; set; }
    public double TauxPrécipitations { get; private set; } //mm
    public string TypeMeteo { get; set; }



    public Meteo(double temperature, string humidite, double tauxprecip, string typeMeteo)
    {
        Temperature = temperature;
        Humidite = humidite;
        TauxPrécipitations = tauxprecip;
        TypeMeteo = typeMeteo;
    }

    public bool EstIntemperie
    {
        get
        {
            return TypeMeteo == "temps orageux" || TypeMeteo == "forte tempête" || TypeMeteo == "pluies battantes";
        }
    }
}