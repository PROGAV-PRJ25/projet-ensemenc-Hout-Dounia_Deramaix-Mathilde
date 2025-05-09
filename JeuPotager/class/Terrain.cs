public class Terrain
{
    public string? Nom { get; set; }
    public double? Superficie { get; set; }
    public int LongueurTerrain { get; set; }
    public int LargeurTerrain { get; set; }
    public string? TypeSol { get; set; }
    public string? HumiditeSol { get; set; }
    public int? CapaciteMaxPlantes { get; set; }
    public int TemperatureSol { get; set; }
    public double TemperatureConsigne { get; set; }
    public int NbPlantes { get; private set; }
    public Meteo meteo { get; set; }
    private Random randomPlacement = new Random();


    public List<List<Plante?>> Plantes { get; set; } // grille de plantes (null = vide)
    private int risquePresenceIntrus = 10;
    private Random Random { get; }

    public Plante? PlanteActuelle { get; set; }


    public Terrain(string nom, double superficie, int longueurTerrain, int largeurTerrain,
                   string typeSol, string humiditeSol, int temperatureSol, double temperatureConsigne, Meteo meteo)
    {
        Nom = nom;
        Superficie = superficie;
        LongueurTerrain = longueurTerrain;
        LargeurTerrain = largeurTerrain;
        TypeSol = typeSol;
        HumiditeSol = humiditeSol;
        CapaciteMaxPlantes = longueurTerrain * largeurTerrain;
        TemperatureSol = temperatureSol;
        TemperatureConsigne = temperatureConsigne;
        this.meteo = meteo;
        Random = new Random();
        InitialiserTerrain();
    }

    private void InitialiserTerrain()
    {
        Plantes = new List<List<Plante?>>();
        for (int i = 0; i < LongueurTerrain; i++)
        {
            var ligne = new List<Plante?>();
            for (int j = 0; j < LargeurTerrain; j++)
            {
                ligne.Add(null); // pas de plante au départ
            }
            Plantes.Add(ligne);
        }
    }

    public bool AddPlante(Plante plante)
    {
        for (int x = 0; x < LongueurTerrain; x++)
        {
            for (int y = 0; y < LargeurTerrain; y++)
            {
                if (Plantes[x][y] == null)
                {
                    Plantes[x][y] = plante;
                    NbPlantes++;
                    return true;
                }
            }
        }
        return false; // terrain plein
    }

    public bool RemovePlante(Plante plante)
    {
        for (int x = 0; x < LongueurTerrain; x++)
        {
            for (int y = 0; y < LargeurTerrain; y++)
            {
                if (Plantes[x][y] == plante)
                {
                    Plantes[x][y] = null;
                    NbPlantes--;
                    return true;
                }
            }
        }
        return false;
    }

    public void MiseAJourMeteo(Meteo nouvelleMeteo)
    {
        this.meteo = nouvelleMeteo;
    }


    public void AfficherParcelleSaine()
    {
        for (int i = 0; i < LongueurTerrain; i++)
        {

            for (int j = 0; j < LargeurTerrain; j++)
            {
                if (Plantes[i][j] != null)
                    Console.Write(" 🌱 ");
                //else
                //Console.Write(" 🟫 ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }

    public void AfficherParcelle()
    {
        for (int i = 0; i < LongueurTerrain; i++)
        {
            for (int j = 0; j < LargeurTerrain; j++)
            {
                if (Plantes[i][j] == null)
                {
                    Console.Write(" 🟫 ");
                }
                else if (Plantes[i][j] is MauvaiseHerbe)
                {
                    Console.Write(" 🌾 ");
                }
                else
                {
                    Console.Write(" 🌱 ");
                }
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }

    public string RecapitulerInformationsWebcam()
    {
        bool intrusDetecte = SignalerIntrus();
        bool intemperieDetectee = SignalerIntemperie();
        Console.ForegroundColor = ConsoleColor.DarkMagenta;

        string message = "";
        Console.ResetColor();

        if (intrusDetecte)
            message += " ❗ Intrus repéré dans le potager !\n";
        if (intemperieDetectee)
            message += " 🌧️ Intempéries détectées dans votre jardin.\n";
        if (!intrusDetecte && !intemperieDetectee)
            message += " ✅ Aucune urgence détectée par la webcam ce mois-ci.\n";

        return message;
    }

    private bool SignalerIntrus() => Random.Next(1, 101) <= risquePresenceIntrus;

    private bool SignalerIntemperie() =>
        meteo.Type == TypeMeteo.ForteTempete || meteo.Type == TypeMeteo.PluiesBattantes;

    public override string ToString()
    {
        return $"Terrain {Nom} ({Superficie} m²)\n" +
               $"Type de sol : {TypeSol}\n" +
               $"Capacité max : {CapaciteMaxPlantes} plantes\n" +
               $"Plantes présentes : {NbPlantes}\n\n";
        //"Informations météo :\n" + meteo.ToString();
    }


    public void Semer(Plante plante)
    {
        while (NbPlantes < CapaciteMaxPlantes)
        {
            AddPlante(plante);
            plante.Semer();
        }
        AfficherParcelle();
    }

    public void ApparaitreMauvaiseHerbe()
    {
        bool mauvaisesHerbesAjoutees = false;
        for (int i = 0; i < LongueurTerrain; i++)
        {
            for (int j = 0; j < LargeurTerrain; j++)
            {
                if (Plantes[i][j] != null && Random.Next(0, 101) <= 5)
                {
                    Plantes[i][j] = new MauvaiseHerbe();
                    mauvaisesHerbesAjoutees = true;
                }
            }
        }
        if (mauvaisesHerbesAjoutees)
        {
            Console.WriteLine("Attention, des mauvaises herbes envahissent votre terrain !");
        }
    }


    public void Desherber()
    {

        for (int i = 0; i < LongueurTerrain; i++)
        {
            for (int j = 0; j < LargeurTerrain; j++)
            {
                if (Plantes[i][j] is MauvaiseHerbe)
                {
                    Console.Write("");

                }
            }
        }
        Console.WriteLine("Vous avez desherber vos mauvaises herbe");
        AfficherParcelleSaine();
    }


}
