public class Meteo
{
    public double Temperature {get ; set; }
    public string? Humidite {get; set; }
    public double VitesseVent{get; set; }
    
    public Meteo ( double temperature , string humidite , double vitesseVent )
    {
        Temperature = temperature ; 
        Humidite = humidite ; 
        VitesseVent = vitesseVent ; 
    }
}