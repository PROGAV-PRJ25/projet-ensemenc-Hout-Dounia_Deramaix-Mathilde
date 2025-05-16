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
    public Meteo Meteo { get; set; }
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
        Meteo = meteo;
        Random = new Random();
        StockTotalDeSemis = CapaciteMaxPlantes;
        InitialiserTerrain();
    }

    public Terrain(string nom, Meteo meteo)
    {
        Nom = nom;
        Meteo = meteo;
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
            Console.WriteLine("Toutes les plantes du terrain sont mortes ... 😢");
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

    public bool Arroser()
    {
        bool auMoinsUneArrosee = false;
        for (int i = 0; i < LongueurTerrain; i++)
        {
            for (int j = 0; j < LargeurTerrain; j++)
            {
                var plante = Plantes[i][j];
                if (plante != null && plante.EstSemee)
                {
                    plante.Arroser();
                    auMoinsUneArrosee = true;
                }
            }
        }
        if (auMoinsUneArrosee)
        {
            Console.WriteLine("\n   🚿 Vous avez arrosé vos plantes !\n");
            NiveauHumiditeSol++; // Humidité ajoutée uniquement si une plante a été arrosée
            return true;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Aucune plante n'est prête à être arrosée.");
            Console.ResetColor();
            return false;
        }
    }
    public bool Semer(Plante plante)
    {
        bool auMoinsUneSemee = false;
        if (StockTotalDeSemis > 0)
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
        }
        else
        {
            if (NbPlantes >= CapaciteMaxPlantes)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("  Vous n'avez plus de place disponible pour semer vos plantes...\n");
                Console.ResetColor();
            }
            else if (StockTotalDeSemis <= 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("  Vous n'avez plus assez de semis disponible ...\n");
                Console.ResetColor();
            }
        }
        if (auMoinsUneSemee)
            Console.WriteLine("  🧑‍🌾 Vous avez semé votre terrain ...\n");

        return false;
        // terrain plein
    }

    public void MiseAJourMeteo(Meteo nouvelleMeteo)
    {
        Meteo = nouvelleMeteo;
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

    public bool SoignerPlantesMalades()
    {
        bool auMoinsUneSoignee = false;
        for (int x = 0; x < LongueurTerrain; x++)
        {
            for (int y = 0; y < LargeurTerrain; y++)
            {
                var plante = Plantes[x][y];
                if (plante != null && plante.EstMalade && plante.EstSemee)
                {
                    plante.EstMalade = false;
                    plante.NbrMoisMaladeConsecutif = 0;
                    auMoinsUneSoignee = true;
                }
            }
        }
        if (auMoinsUneSoignee)
        {
            Console.WriteLine("\n   💉 Vous avez soigné vos plantes d'une terrible maladie !\n");
            return true;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Aucune plante n'est prête à être soignée.");
            Console.ResetColor();
            return false;
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
        return Meteo.Type == TypeMeteo.ForteTempete || Meteo.Type == TypeMeteo.PluiesBattantes;
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
            var (bruitFait, pareVentMis) = GererActionUrgence();
            GérerConséquencesUrgence(bruitFait, pareVentMis);
        }
        intrusDetecte = false;
        intemperieDetectee = false;
        AfficherParcelle();
    }

    private (bool bruitFait, bool pareVentMis) GererActionUrgence()
    {
        bool bruitFait = false;
        bool pareVentMis = false;

        while (true)
        {
            Console.WriteLine("\nMenu d'Urgence : Que voulez-vous faire ?");
            Console.WriteLine("1. Faire du bruit 🗣️");
            Console.WriteLine("2. Déployer un pare-vent 🪟");
            Console.WriteLine("3. Ne rien faire");

            ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
            switch (keyInfo.KeyChar)
            {
                case '1':
                    Console.WriteLine("\nVous faites du bruit pour éloigner les intrus.\n");
                    bruitFait = true;
                    return (bruitFait, pareVentMis);
                case '2':
                    Console.WriteLine("\nVous déployez un pare-vent pour protéger vos récoltes.\n");
                    pareVentMis = true;
                    return (bruitFait, pareVentMis);
                case '3':
                    Console.WriteLine("\nVous ne faites rien.\n");
                    return (false, false);
                default:
                    Console.WriteLine("\nOption invalide. Veuillez réessayer.\n");
                    break;
            }
        }
    }

    private void GérerConséquencesUrgence(bool bruitFait, bool pareVentMis)
    {
        // === Cas des intrus ===
        if (!bruitFait && intrusDetecte)
        {
            bool planteTrouvee = false;

            for (int tentative = 0; tentative < 100; tentative++)
            {
                int x = Random.Next(0, LongueurTerrain);
                int y = Random.Next(0, LargeurTerrain);

                if (Plantes[x][y] != null && Plantes[x][y]!.EstSemee && !Plantes[x][y]!.EstMorte)
                {
                    Plantes[x][y]!.EstMorte = true;
                    planteTrouvee = true;

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nUne plante est morte dans votre jardin à cause des intrus...\n");
                    Console.ResetColor();
                    break;
                }
            }

            if (!planteTrouvee)
            {
                Console.WriteLine("\n Aucune plante n'est présente sur le terrain.\n");
            }
        }

        // === Cas de l’intempérie ===
        if (!pareVentMis && intemperieDetectee)
        {
            bool planteTrouvee = false;

            for (int tentative = 0; tentative < 100; tentative++)
            {
                int x = Random.Next(0, LongueurTerrain);
                int y = Random.Next(0, LargeurTerrain);

                if (Plantes[x][y] != null && Plantes[x][y]!.EstSemee && !Plantes[x][y]!.EstMorte)
                {
                    Plantes[x][y] = null;
                    NbPlantes--;
                    planteTrouvee = true;

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nUne plante a été déracinée dans votre jardin à cause du vent...");
                    Console.ResetColor();
                    break;
                }
            }

            if (!planteTrouvee)
            {
                Console.WriteLine("\n Aucune plante n'est présente sur le terrain.");
            }
        }
    }

    public override string ToString()
    {
        return $"       Terrain {Nom} ({Superficie} m²)\n" +
               $"       Type de sol : {TypeSol}\n" +
               $"       Humidité du terrain : {HumiditeSol}\n" +
               $"       Niveau humidité du terrain : {NiveauHumiditeSol}\n" + // pour tester méthode calculhumidité
               $"       Capacité max : {CapaciteMaxPlantes} plantes\n" +
               $"       Plantes présentes : {NbPlantes}\n" +
               $"       Stock de semis : {StockTotalDeSemis}\n";
    }

    public void AfficherLeSolde()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"   💰  Solde actuel du compte : {PiecesOrEnChocolat} pièces d'or en chocolat");
        Console.ResetColor();
    }

    public bool DeracinerPlantesMortes()
    {
        bool auMoinsUneDeracinee = false;
        for (int x = 0; x < LongueurTerrain; x++)
        {
            for (int y = 0; y < LargeurTerrain; y++)
            {
                var plante = Plantes[x][y];
                if (plante != null && plante.EstMorte && plante.EstSemee)
                {
                    plante.RetirerPlanteMorte();
                    Plantes[x][y] = null;
                    NbPlantes--;
                    auMoinsUneDeracinee = true;
                }
            }
        }
        EstRecouvertDePlantesMortes = false;
        if (auMoinsUneDeracinee)
        {
            Console.WriteLine("\n   🥀 Vous avez retiré toutes les plantes mortes de votre terrain !\n");
            return true;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Aucune plante n'est prête à être déracinée.");
            Console.ResetColor();
            return false;
        }
    }

    public string AfficherResumeTerrain()
    {
        int nbrMalades = 0;
        int nbrMauvaisesHerbes = 0;
        int nbrMortes = 0;
        int nbrGrandes = 0;
        int nbrrecoltable = 0;
        int placeDisponible = 0;

        for (int i = 0; i < LongueurTerrain; i++)
        {
            for (int j = 0; j < LargeurTerrain; j++)
            {
                var plante = Plantes[i][j];
                if (plante == null)
                    placeDisponible++;
                else if (plante != null && plante.EstSemee)
                {
                    if (plante.EstMorte)
                        nbrMortes++;
                    else if (plante.EstMalade)
                        nbrMalades++;
                    else if (plante.EstEntoureeParMauvaisesHerbes)
                        nbrMauvaisesHerbes++;
                    else if (plante.EstRecoltable)
                        nbrrecoltable++;
                    else if (plante.AGrandi)
                        nbrGrandes++;
                }
            }
        }
        string resume = $"   📋 Résumé du terrain pour le mois :\n" +
                        $"       🥀 {nbrMortes} plante(s) morte(s).\n" +
                        $"       🦠 {nbrMalades} plante(s) malade(s).\n" +
                        $"       🍀 {nbrMauvaisesHerbes} plante(s) entourée(s) de mauvaises herbes.\n" +
                        $"       🍬 {nbrrecoltable} plante(s) récoltable(s).\n" +
                        $"       🌿 {nbrGrandes} plante(s) en croissance avancée.\n" +
                        $"       🌱 {NbPlantes} plante(s) présente(s).\n" +
                        $"       🟫 {placeDisponible} place(s) disponicle(s).\n";
        return resume;
    }

    public void ApparaitreMauvaiseHerbe()
    {
        for (int i = 0; i < LongueurTerrain; i++)
        {
            for (int j = 0; j < LargeurTerrain; j++)
            {
                var plante = Plantes[i][j];
                if (plante != null && plante.EstSemee)
                    plante.ApparaitreMauvaiseHerbe();
            }
        }
    }

    public bool Desherber()
    {
        bool auMoinsUneDesherbee = false;
        for (int i = 0; i < LongueurTerrain; i++)
        {
            for (int j = 0; j < LargeurTerrain; j++)
            {
                var plante = Plantes[i][j];
                if (plante != null && plante.EstSemee && plante.EstEntoureeParMauvaisesHerbes)
                {
                    plante.Desherber();
                    auMoinsUneDesherbee = true;
                }
            }
        }
        if (auMoinsUneDesherbee)
        {
            Console.WriteLine(" 🍀 Vous avez retiré les mauvaises herbes de vos plantes");
            return true;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Aucune mauvaise herbe n'est prête à être désherbé.");
            Console.ResetColor();
            return false;
        }
    }

    public void TomberMalade()
    {

        for (int i = 0; i < LongueurTerrain; i++)
        {
            for (int j = 0; j < LargeurTerrain; j++)
            {
                Random rnd = new Random();
                var plante = Plantes[i][j];
                if (plante != null && plante.EstSemee)
                    plante!.EtreMalade(rnd);
            }
        }
    }
    public void UtiliserFonctionnalitesAleatoire(Meteo meteo)
    {
        ApparaitreMauvaiseHerbe();
        TomberMalade();
        CalculerHumiditeSol(Meteo);
        AfficherParcelle();
    }

    public void CalculerHumiditeSol(Meteo meteo)
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
            HumiditeSol = "tres humide";
        else
        {
            HumiditeSol = "extremement humide";
        }
    }

    public void CroissancePlantes(string typeSol, string humiditeTerrain, double temperatureActuelle, Meteo meteo)
    {
        bool messageAffiche = false;

        for (int x = 0; x < LongueurTerrain; x++)
        {
            for (int y = 0; y < LargeurTerrain; y++)
            {
                var plante = Plantes[x][y];
                if (plante != null && !plante.EstMorte && plante.EstSemee)
                {
                    bool conditionsDefavorables = plante.Croissance(typeSol, humiditeTerrain, temperatureActuelle, meteo);
                    if (!conditionsDefavorables && !messageAffiche)
                    {
                        Console.WriteLine("Vos plantes vont mourir dues à des conditions défavorables ... 😔");
                        messageAffiche = true;
                        EstRecouvertDePlantesMortes = true;
                    }
                }
            }
        }
    }




    public bool RecolterPlantes()
    {
        bool auMoinsUneRecoltee = false;
        int totalRecolte = 0;

        for (int i = 0; i < LongueurTerrain; i++)
        {
            for (int j = 0; j < LargeurTerrain; j++)
            {
                var plante = Plantes[i][j];
                if (plante != null && plante.EstRecoltable && plante.EstSemee)
                {
                    int quantite = plante.RecolterPlante();
                    totalRecolte += quantite;
                    StockTotalDeSemis += quantite;
                    Plantes[i][j] = null; //pour revenir à un terrain vierge
                    auMoinsUneRecoltee = true;
                }
            }
        }
        if (auMoinsUneRecoltee)
        {
            Console.WriteLine("\n   🧺 Vous avez récolté vos plantes !\n");
            if (totalRecolte > 0)
                Console.WriteLine($"Stock total après récolte : {StockTotalDeSemis}\n");
            return true;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Aucune plante n'était prête à être récoltée.");
            Console.ResetColor();
            return false;
        }

    }

    public bool VendreSemis(Plante plante)
    {
        Console.Write($"Quantité de semis à vendre (prix unitaire = {plante.PrixUnitaireDeLaPlante}): \n");
        string saisie = Console.ReadLine()!;

        if (!int.TryParse(saisie, out int quantiteAVendre) || quantiteAVendre <= 0)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Quantité invalide.");
            Console.ResetColor();
            return false;
        }

        if (quantiteAVendre > StockTotalDeSemis)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Vous n'avez pas assez de semis en stock pour cette vente.");
            Console.ResetColor();
            return false;
        }

        double prixUnitaire = plante.PrixUnitaireDeLaPlante;
        double gain = quantiteAVendre * prixUnitaire;

        StockTotalDeSemis -= quantiteAVendre;
        PiecesOrEnChocolat += gain;

        Console.WriteLine($"✅ Vous avez vendu {quantiteAVendre} semis de {plante.Nom} pour {gain} pièces d’or en chocolat !");
        Console.WriteLine($"💰 Nouveau solde : {PiecesOrEnChocolat} pièces.");
        return true;
    }

}
