public class Pays {
    public string? NomPays{get; set; }
    public string? Capitale{get; set; }
    public string? ClimatPays{get; set; }
    
    public Pays (string nom, string capitale, string climat)
    {
        NomPays = nom ; 
        Capitale = capitale ; 
        ClimatPays = climat ; 
    }
    
}