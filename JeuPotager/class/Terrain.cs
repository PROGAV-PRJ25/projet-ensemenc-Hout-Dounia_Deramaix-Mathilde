using System.Dynamic;

public class Terrain
{
    public string? Nom { get; set; }
    public double Superficie { get; set; }
    public string? TypeSol { get; set; }
    public string? HumiditeSol { get; set; }
    public int CapaciteMaxPlantes { get; set; }
    public int TemperatureSol { get; set; }
    public Meteo meteo { get; set; }
    public List<Plante> Plantes { get; set; } = new List<Plante>();
    private int risquePresenceIntrus = 10; //10%
    private Random Random { get; }


    public Terrain(string nom, double superficie, string typeSol, string humiditeSol, int capaciteMaxPlantes, int temperatureSol, Meteo meteo)
    {
        Nom = nom;
        Superficie = superficie;
        TypeSol = typeSol;
        HumiditeSol = humiditeSol;
        CapaciteMaxPlantes = capaciteMaxPlantes;
        TemperatureSol = temperatureSol;
        this.meteo = meteo;
        Random = new Random();
    }

    public bool AddPlante(Plante plante)
    {
        if (Plantes.Count < CapaciteMaxPlantes)
        {
            Plantes.Add(plante);
            return true;
        }
        return false;
    }

    public bool RemovePlante(Plante plante)
    {
        return Plantes.Remove(plante);
    }

    public string RecapitulerInformationsWebcam()
    {
        bool intrusDetecte = SignalerIntrus();
        bool intemperieDetectee = SignalerIntemperie();
        string message = "\n" +
                        "Information transmise par la webcam pendant le mois : \n";

        if (intrusDetecte)
            message += "intrus repéré dans le potager !";
        if (intemperieDetectee)
            message += "intempéries détectées dans votre jardin : ";

        if (!intrusDetecte && !intemperieDetectee)
            message += " Aucune urgence détectée par la webcam ce mois-ci";

        return message;
    }

    private bool SignalerIntrus()
    {
        return Random.Next(1, 101) <= risquePresenceIntrus;
    }

    private bool SignalerIntemperie()
    {
        if (meteo.Type == TypeMeteo.ForteTempete || meteo.Type == TypeMeteo.PluiesBattantes)
        {
            return true;
        }
        return false;
    }

    public override string ToString()
    {
        return $"Terrain {Nom} ({Superficie} m²)\n" +
               $"Type de sol : {TypeSol} \n" +
               $"Capacité max : {CapaciteMaxPlantes} plantes\n" +
               $"Plantes présentes : {Plantes.Count}\n\n" +
               "Informations météo :\n" +
               this.meteo.ToString();
    }
}