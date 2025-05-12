public class Terrain
{
    public string? Nom { get; set; }
    public double? Superficie { get; set; }
    public int LongueurTerrain { get; set; }
    public int LargeurTerrain { get; set; }
    public string? TypeSol { get; set; }
    public string? HumiditeSol { get; set; }

    // humidité en mettre en int  Pluie=1 unité et bruine=0.5
    // FAIRE UNE FONCTION

    // La pluie est considérée comme  1 unité,  (pluie violente = 2 unité, pluie bruine = 0.5)
    // stress hydrique de 0 ≤ niveau < 4; (sol imperméable)
    //humide de  4 ≤ niveau < 6
    // très humide de  6 ≤ niveau < 9
    // humide de  9 ≤ niveau

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
    private bool intrusDetecte;
    private bool intemperieDetectee;


    private void MettreAJourUrgence()
    {
        intrusDetecte = SignalerIntrus();
        intemperieDetectee = SignalerIntemperie();
    }

    public string RecapitulerInformationsWebcam()
    {
        MettreAJourUrgence();

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


    public void ActiverModeUrgence()

    {
        MettreAJourUrgence();


        if (intrusDetecte || intemperieDetectee)
        {

            Console.ForegroundColor = ConsoleColor.Red;

            // Informer l'utilisateur
            if (intrusDetecte)
            {
                Console.WriteLine("⚠️ Mode Urgence activé : Intrus détecté dans le potager !");
            }

            if (intemperieDetectee)
            {
                Console.WriteLine("⚠️ Mode Urgence activé : Conditions météorologiques défavorables détectées !");
            }

            Console.ResetColor();

            AfficherMenuUrgence();
            string actionChoisie = Console.ReadLine()!;
            GererActionUrgence();
        }

    }

    private void AfficherMenuUrgence()
    {
        Console.WriteLine("\nMenu d'Urgence : Que voulez-vous faire ?\n");
        Console.WriteLine("1. Faire du bruit \n");
        Console.WriteLine("2. Déployer une bâche \n");
        Console.WriteLine("3. Rebouchez les trous \n");
        Console.WriteLine("4. Creuser une tranchée \n");

    }

    private void GererActionUrgence()
    {
        bool actionValide = false;
        AfficherMenuUrgence();
        while (!actionValide)
        {
            

            ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
            char key = keyInfo.KeyChar;

            switch (key)
            {
                case '1':
                    Console.WriteLine("\nVous faites du bruit pour éloigner les intrus");
                    actionValide = true;
                    break;
                case '2':
                    Console.WriteLine("\nVous déployez une bâche pour protéger vos récoltes");
                    actionValide = true;
                    break;
                case '3':
                    Console.WriteLine("\nVous rebouchez les trous dans le terrain.");
                    actionValide = true;
                    break;
                case '4':
                    Console.WriteLine("\nVous creusez une tranchée pour éviter les inondations.");
                    actionValide = true;
                    break;
                default:
                    Console.WriteLine("\nOption invalide. Appuyez sur une touche de 1 à 4.");
                    break;
            }
        }
    }



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
