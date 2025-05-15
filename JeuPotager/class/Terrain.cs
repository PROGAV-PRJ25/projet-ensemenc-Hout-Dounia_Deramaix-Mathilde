public class Terrain
{
    public string? Nom { get; set; }
    public double? Superficie { get; set; }
    public int LongueurTerrain { get; set; }
    public int LargeurTerrain { get; set; }
    public string? TypeSol { get; set; }
    public string? HumiditeSol { get; set; }
    public double NiveauHumiditeSol { get; set; }
    public int? CapaciteMaxPlantes { get; set; }
    public double TemperatureConsigne { get; set; }
    public int NbPlantes { get; private set; } = 0;
    public double PiecesOrEnChocolat { get; private set; } = 0;
    public Meteo meteo { get; set; }
    private Random randomPlacement = new Random();
    public List<List<Plante?>> Plantes { get; set; } // grille de plantes (null = vide)
    private int risquePresenceIntrus = 10;
    private Random Random { get; }
    public int? StockTotalDeSemis { get; private set; }
    public bool EstRecouvertDePlantesMortes { get; set; } = false;


    public Terrain(string nom, double superficie, int longueurTerrain, int largeurTerrain,
                   string typeSol, string humiditeSol, double niveauHumiditeSol, double temperatureConsigne, Meteo meteo)
    {
        Nom = nom;
        Superficie = superficie;
        LongueurTerrain = longueurTerrain;
        LargeurTerrain = largeurTerrain;
        TypeSol = typeSol;
        HumiditeSol = humiditeSol;
        NiveauHumiditeSol = niveauHumiditeSol;
        CapaciteMaxPlantes = longueurTerrain * largeurTerrain;
        TemperatureConsigne = temperatureConsigne;
        this.meteo = meteo;
        Random = new Random();
        StockTotalDeSemis = CapaciteMaxPlantes;
        InitialiserTerrain();
    }

    public Terrain(string nom, Meteo meteo)
    {
        Nom = nom;
        this.meteo = meteo;
        Random = new Random();
        InitialiserTerrain();
    }

    public void EtreMort()
    {
        int compteurPlantesMortes = 0;
        for (int i = 0; i < LongueurTerrain; i++)
        {
            for (int j = 0; j < LargeurTerrain; j++)
            {
                var plante = Plantes[i][j];
                if (plante != null && plante!.EstMorte == true)
                    compteurPlantesMortes++;
            }
        }
        if (compteurPlantesMortes == NbPlantes)
        {
            EstRecouvertDePlantesMortes = true;
            Console.WriteLine("Les plantes sont mortes");
        }
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

    public void Arroser()
    {
        for (int i = 0; i < LongueurTerrain; i++)
        {
            for (int j = 0; j < LargeurTerrain; j++)
            {
                var plante = Plantes[i][j];
                if (plante != null && plante.EstSemee)
                    plante!.Arroser();
            }
        }
        NiveauHumiditeSol++;    // Humidité ajouté avec l'arrosage
        Console.WriteLine("Les plantes ont été arrosées");
    }

    public bool Semer(Plante plante)
    {
        while (NbPlantes < CapaciteMaxPlantes && StockTotalDeSemis > 0)
        {
            for (int x = 0; x < LongueurTerrain; x++)
            {
                for (int y = 0; y < LargeurTerrain; y++)
                {
                    if (Plantes[x][y] == null)
                    {
                        Plantes[x][y] = plante.Cloner();
                        Plantes[x][y]!.Semer();
                        NbPlantes++;
                        StockTotalDeSemis--;
                    }
                }
            }
        }
        AfficherParcelle();
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
                    //Plantes[x][y] = null;
                    plante.EstMorte = true;
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

    public void AfficherParcelle()
    {
        for (int i = 0; i < LongueurTerrain; i++)
        {
            for (int j = 0; j < LargeurTerrain; j++)
            {
                var plante = Plantes[i][j];

                if (plante == null)
                {
                    Console.Write(" 🟫 ");
                }
                else if (plante.EstMorte)
                {
                    Console.Write(" 🥀 ");
                }
                else if (plante.EstMalade)
                {
                    Console.Write(" 🦠 ");
                }
                else if (plante.EstEntoureeParMauvaisesHerbes)
                {
                    Console.Write(" 🍀 ");
                }
                else if (plante.EstRecoltable)
                {
                    Console.Write(" 🍬 ");
                }
                else if (plante.AGrandi)
                {
                    Console.Write(" 🌿 ");
                }
                else if (plante.EstSemee)
                {
                    Console.Write(" 🌱 ");
                }
                else
                {
                    Console.Write(" 🟩 ");
                }
            }
            Console.WriteLine("\n");
        }
    }


    private bool intrusDetecte;
    private bool intemperieDetectee;

    public void SoignerPlantesMalades()
    {
        for (int x = 0; x < LongueurTerrain; x++)
        {
            for (int y = 0; y < LargeurTerrain; y++)
            {
                var plante = Plantes[x][y];
                if (plante != null && plante.EstMalade)
                {
                    plante.EstMalade = false;
                }
            }
        }
    }


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



    private bool SignalerIntrus()
    {
        return Random.Next(1, 101) <= risquePresenceIntrus;
    }

    private bool SignalerIntemperie()
    {
        return meteo.Type == TypeMeteo.ForteTempete || meteo.Type == TypeMeteo.PluiesBattantes;
    }

    public void ActiverModeUrgence()

    {

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
            //GererActionUrgence();
            bool bruitFait = GererActionUrgence();
            GérerConséquencesUrgence(bruitFait);

        }

    }

    private void AfficherMenuUrgence()
    {
        Console.WriteLine("\nMenu d'Urgence : Que voulez-vous faire ?\n");
        Console.WriteLine("1. Faire du bruit \n");
        Console.WriteLine("2. Déployer un pare-vent \n");

    }

    private bool GererActionUrgence()
    {
        bool actionValide = false;
        bool bruitFait = false;
        while (!actionValide)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
            char key = keyInfo.KeyChar;

            switch (key)
            {
                case '1':
                    Console.WriteLine("\nVous faites du bruit pour éloigner les intrus");
                    bruitFait = true;
                    actionValide = true;
                    break;
                case '2':
                    Console.WriteLine("\nVous déployez une bâche pour protéger vos récoltes");
                    actionValide = true;
                    break;
                default:
                    Console.WriteLine("\nOption invalide.");
                    break;
            }
        }
        return bruitFait;
    }

    private void GérerConséquencesUrgence(bool bruitFait)
    {
        if (!bruitFait && intrusDetecte)
        {

            int x = Random.Next(0, LargeurTerrain);
            int y = Random.Next(0, LongueurTerrain);

            if ((Plantes[x][y] != null) && !Plantes[x][y]!.EstMorte)

                Plantes[x][y]!.EstMorte = true;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nUne plante est morte dans votre jardin...");
            Console.ResetColor();

            Console.WriteLine("\nÉtat actuel du terrain :\n");
            AfficherParcelle();
        }
    }



    public override string ToString()
    {
        return
               $"       Terrain {Nom} ({Superficie} m²)\n" +
               $"       Type de sol : {TypeSol}\n" +
               $"       Capacité max : {CapaciteMaxPlantes} plantes\n" +
               $"       Plantes présentes : {NbPlantes}\n\n";
    }




    public void ApparaitreMauvaiseHerbe()
    {
        for (int i = 0; i < LongueurTerrain; i++)
        {
            for (int j = 0; j < LargeurTerrain; j++)
            {
                var plante = Plantes[i][j];
                if (plante != null)
                    plante.ApparaitreMauvaiseHerbe();
            }
        }
    }

    public void Desherber()
    {
        for (int i = 0; i < LongueurTerrain; i++)
        {
            for (int j = 0; j < LargeurTerrain; j++)
            {
                var plante = Plantes[i][j];
                if (plante != null)
                    plante.Desherber();
            }
        }
        Console.WriteLine("Vous avez desherber vos mauvaises herbes ! ");
        AfficherParcelle();
    }

    public void TomberMalade()
    {
        Random rnd = new Random();
        for (int i = 0; i < LongueurTerrain; i++)
        {
            for (int j = 0; j < LargeurTerrain; j++)
            {
                if (Plantes[i][j] != null)
                    Plantes[i][j]!.EtreMalade(rnd);  // partage la même instance !
            }
        }
    }
    public void UtiliserFonctionnalitesAleatoire()
    {
        ApparaitreMauvaiseHerbe();
        TomberMalade();
        AfficherParcelle();
    }

    public void CalculerHumiditeSol(Meteo meteo) // A TESTER
    {
        switch (meteo.Type)
        {
            //Pluie
            case TypeMeteo.PetitePluie:
                NiveauHumiditeSol += 0.5;
                break;

            case TypeMeteo.Pluie:
                NiveauHumiditeSol += 1;
                break;

            case TypeMeteo.PluiesBattantes:
                NiveauHumiditeSol += 1.5;
                break;

            case TypeMeteo.ForteTempete:
                NiveauHumiditeSol += 2;
                break;

            // Pas de pluie
            case TypeMeteo.Ensoleille:
                NiveauHumiditeSol -= 2;
                break;
            case TypeMeteo.Nuageux:
                NiveauHumiditeSol -= 1;
                break;
        }

        // Actualisation du statut d'humidité du sol pour l'utiliser pour les plantes
        if (NiveauHumiditeSol < 0) NiveauHumiditeSol = 0;

        if (NiveauHumiditeSol < 4)
        {
            HumiditeSol = "stress hydrique";
        }
        else if (NiveauHumiditeSol < 6)
        {
            HumiditeSol = "humide";
        }
        else if (NiveauHumiditeSol < 9)
        {
            HumiditeSol = "très humide";
        }
        else
        {
            HumiditeSol = "inonde";
        }
    }

    public void RecolterPlantes()
    {
        int totalRecolte = 0;

        for (int i = 0; i < LongueurTerrain; i++)
        {
            for (int j = 0; j < LargeurTerrain; j++)
            {
                var plante = Plantes[i][j];
                if (plante != null && plante.EstRecoltable)
                {
                    int quantite = plante.RecolterPlante();
                    totalRecolte += quantite;
                    StockTotalDeSemis += quantite;
                }
            }
        }

        if (totalRecolte > 0)
        {
            Console.WriteLine($"Stock total après récolte : {StockTotalDeSemis}");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Aucune plante n'était prête à être récoltée.");
            Console.ResetColor();
        }

        Console.WriteLine("Vous avez désherbé vos mauvaises herbes.");
        AfficherParcelle();
    }

    public void VendreSemis(Plante plante)
    {
        Console.Write("Quantité de semis à vendre : ");
        string saisie = Console.ReadLine()!;

        if (!int.TryParse(saisie, out int quantite) || quantite <= 0)
        {
            Console.WriteLine("Quantité invalide.");
            return;
        }

        double prixUnitaire = plante.PrixUnitaireDeLaPlante;
        double gain = quantite * prixUnitaire;

        StockTotalDeSemis -= quantite;
        PiecesOrEnChocolat += gain;

        Console.WriteLine($"✅ Vous avez vendu {quantite} semis de {plante.Nom} pour {gain} pièces d’or en chocolat !");
        Console.WriteLine($"💰 Nouveau solde : {PiecesOrEnChocolat} pièces.");
    }
}
