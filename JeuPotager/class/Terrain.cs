public class Terrain
{
    public string? Nom { get; set; }
    public double Superficie { get; set; }
    public int LongueurTerrain { get; set; }
    public int LargeurTerrain { get; set; }
    public string? TypeSol { get; set; }
    public string? HumiditeSol { get; set; }
    public double NiveauHumiditeSol { get; set; }
    public double TemperatureConsigne { get; set; } //Température consigne du terrain pour la météo
    public List<List<Plante?>> Plantes { get; set; } = new(); // grille de plantes (null = vide) ; utile pour ne pas gérer les coordonées des plantes (x,y)
    public int? CapaciteMaxPlantes { get; set; } //Valeur calculée à partir de la longueur et de la largueur
    public int NbPlantes { get; private set; } = 0; //Nombre de plantes présentes et en vie sur le terrain
    public double PiecesOrEnChocolat { get; private set; } = 0; //Solde bancaire du joueur
    public int? StockTotalDeSemis { get; private set; } = 0;//Stock de semis disponible pour le terrain
    public Meteo Meteo { get; set; }
    private int RisquePresenceIntrus { get; set; } //Pourcentage de présence qu'un intrus attaque le terrain 
    private Random Random { get; }



    //-------------  ETAT DU TERRAIN (BOOLEEN)
    public bool EstRecouvertDePlantesMortes { get; set; } = false;
    private bool IntrusDetecte { get; set; } = false;
    private bool IntemperieDetectee { get; set; } = false;
    public bool EstVide { get; set; } = false;


    public Terrain(string nom, double superficie, int longueurTerrain, int largeurTerrain,
                   string typeSol, string humiditeSol, double niveauHumiditeSol, double temperatureConsigne, Meteo meteo, int risquePresenceIntrus)
    {
        Nom = nom;
        Superficie = superficie;
        LongueurTerrain = longueurTerrain;
        LargeurTerrain = largeurTerrain;
        TypeSol = typeSol;
        HumiditeSol = humiditeSol;
        NiveauHumiditeSol = niveauHumiditeSol;
        TemperatureConsigne = temperatureConsigne;
        Meteo = meteo;
        RisquePresenceIntrus = risquePresenceIntrus;

        CapaciteMaxPlantes = longueurTerrain * largeurTerrain;
        StockTotalDeSemis = CapaciteMaxPlantes;

        Random = new Random();
        InitialiserTerrain();
    }

    public Terrain(string nom, Meteo meteo)
    {
        Nom = nom;
        Meteo = meteo;
        Random = new Random();
        InitialiserTerrain();
    }

    ///////------------------------------- Affichage du terrain

    private void InitialiserTerrain()
    {
        Plantes = new List<List<Plante?>>();

        // Parcours de toute la grille de plantes
        for (int i = 0; i < LongueurTerrain; i++)
        {
            var ligne = new List<Plante?>();
            for (int j = 0; j < LargeurTerrain; j++)
            {
                ligne.Add(null); // pas de plante au départ donc les cases sont initialisées à null
            }
            Plantes.Add(ligne); //
        }
    }

    public void AfficherParcelle()
    {
        // Parcours de toute la grille de plantes
        for (int i = 0; i < LongueurTerrain; i++)
        {
            for (int j = 0; j < LargeurTerrain; j++)
            {
                var plante = Plantes[i][j];
                // Les plantes peuvent avoir plusieurs état à la fois mais
                // l'affichage se fait par ordre d'importance de l'état
                // ex: une plante peut etre malade ET avec des mauvaises herbes
                //mais une fois soignée, elle sera affichée avec des mauvaises herbes... (sauf si déherber avant) 

                if (plante == null)
                {
                    Console.Write(" 🟫 "); //Case vide sans plante
                }
                else if (plante.EstMorte)
                {
                    Console.Write(" 🥀 ");//Plante morte
                }
                else if (plante.EstMalade)
                {
                    Console.Write(" 🦠 ");//Plante malade
                }
                else if (plante.EstEntoureeParMauvaisesHerbes)
                {
                    Console.Write(" 🍀 ");//Plante avec des mauvaises herbes
                }
                else if (plante.EstRecoltable)
                {
                    Console.Write(" 🍬 ");//Plante fleurit et donc récoltable
                }
                else if (plante.AGrandi)
                {
                    Console.Write(" 🌿 ");//Plante grandie (en croissance)
                }
                else if (plante.EstSemee)
                {
                    Console.Write(" 🌱 ");//Plante en semis
                }
                else
                {
                    Console.Write(" 🟩 ");//Par défaut
                }
            }
            Console.WriteLine("\n");
        }
    }

    ///////-------------------------------------------- Etat du terrain et des plantes

    public void VerifierTerrainMorts()
    {
        int nbPlantesReelles = 0;         // Plantes réellement présentes (non null), on recalcule pour etre sur que ce soit à jour
        int compteurPlantesMortes = 0;    // Plantes présentes et mortes

        for (int i = 0; i < LongueurTerrain; i++)
        {
            for (int j = 0; j < LargeurTerrain; j++)
            {
                var plante = Plantes[i][j];

                if (plante != null && plante.EstSemee)
                {
                    nbPlantesReelles++;

                    if (plante.EstMorte)
                    {
                        compteurPlantesMortes++;
                    }
                }
            }
        }

        // Vérifie si toutes les plantes réelles sont mortes
        if (nbPlantesReelles > 0 && compteurPlantesMortes == nbPlantesReelles && StockTotalDeSemis <= 0)
        {
            EstRecouvertDePlantesMortes = true;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" Toutes les plantes du terrain sont mortes ... 😢");
            Console.ResetColor();
        }
    }




    public void EtreVide() //Méthode qui vérifie si le terrain est vide
    {
        if (NbPlantes <= 0)
            EstVide = true;
    }

    public bool VerifierFinDePartie()
    {
        EtreVide(); // Met à jour l’état du terrain (vide ou non)

        if (EstVide && (StockTotalDeSemis <= 0))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" Votre terrain est vide et vous n'avez plus de semis... 😢");
            Console.ResetColor();
            // La partie est terminée si le terrain est vide et qu’il n’y a plus de semis
            return true;
        }
        else
            return false;
    }

    public void CroissancePlantes(string typeSol, string humiditeTerrain, double temperatureActuelle, TypeMeteo meteoActuelle)
    {
        bool messageAffiche = false; // Permet de n'afficher le message d'alerte qu'une seule fois, même si plusieurs plantes sont affectées

        for (int x = 0; x < LongueurTerrain; x++)
        {
            for (int y = 0; y < LargeurTerrain; y++)
            {
                var plante = Plantes[x][y];

                // Si la case contient une plante ET qui est vivante ET semée
                if (plante != null && !plante.EstMorte && plante.EstSemee)
                {
                    bool conditionsDefavorables = plante.Croissance(typeSol, humiditeTerrain, temperatureActuelle, Meteo, meteoActuelle); // Appelle la méthode de croissance de Plante.cs
                    if (conditionsDefavorables && !messageAffiche)// Si les conditions sont défavorables
                    {
                        Console.WriteLine(" Vos plantes vont mourir à cause de conditions défavorables... 😔");
                        messageAffiche = true;
                        EstRecouvertDePlantesMortes = true; // Le terrain est maintenant recouvert de plantes mortes
                    }
                }
            }
        }
    }

    public void MiseAJourMeteo(Meteo nouvelleMeteo)
    {
        Meteo = nouvelleMeteo;
    }

    ///////------------------------------- Méthode liées aux actions du joueur

    public bool Semer(Plante plante)// Semer les plantes sur le terrain
                                    // Retourne true si au moins une plante a été semée, false sinon
    {
        bool auMoinsUneSemee = false;
        if (StockTotalDeSemis > 0) // Vérifie s'il y a encore des semis en stock
        {
            // Continue tant qu’il reste de la place et des semis
            while (NbPlantes < CapaciteMaxPlantes && StockTotalDeSemis > 0)
            {
                for (int x = 0; x < LongueurTerrain; x++)
                {
                    for (int y = 0; y < LargeurTerrain; y++)
                    {
                        // Si la case est vide, on sème une nouvelle plante clonée
                        if (Plantes[x][y] == null && StockTotalDeSemis > 0)
                        {
                            Plantes[x][y] = plante.Cloner();
                            Plantes[x][y]!.Semer(); //Utilisation de la méthode issue de Plante.cs pour l'état de la plante
                            // Ajustement du nombre de plantes présentes sur le terrain et du stock
                            NbPlantes++;
                            StockTotalDeSemis--;
                            auMoinsUneSemee = true; // Au moins une plante a été semée
                        }
                    }
                }
            }
        }

        // Gestion des messages d'erreurs
        if (!auMoinsUneSemee)
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
        else
        {
            Console.WriteLine("  🧑‍🌾 Vous avez semé votre terrain !\n");
        }

        return true; // Retourne false, le terrain est plein
    }

    public bool Arroser() // Arrose toutes les plantes si elles sont semées sur le terrain.
                          // Retourne true si au moins une plante a été arrosée, false sinon.
    {
        bool auMoinsUneArrosee = false;

        for (int i = 0; i < LongueurTerrain; i++)
        {
            for (int j = 0; j < LargeurTerrain; j++)
            {
                var plante = Plantes[i][j];

                // Vérifie que la case contient une plante ET qui a été semée
                if (plante != null && plante.EstSemee)
                {
                    plante.Arroser();           // Appelle la méthode d’arrosage de la plante de Plante.cs
                    auMoinsUneArrosee = true;   // Au moins une plante a été arrosée
                }
            }
        }

        if (auMoinsUneArrosee)
        {
            Console.WriteLine("\n   🚿 Vous avez arrosé vos plantes !\n");
            NiveauHumiditeSol++; // On augmente l’humidité du sol si au moins une plante a été arrosée
            return true;         // Retourne true si au moins une plante a été arrosée
        }
        else
        {
            //si aucune plante n'a été arrosée
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(" Aucune plante n'est prête à être arrosée.");
            Console.ResetColor();
            return false;        // Aucune plante n’a été arrosée
        }
    }

    public bool SoignerPlantesMalades()// Soigne toutes les plantes malades et semées sur le terrain.
                                       // Retourne true si au moins une plante a été soignée, false sinon.
    {
        bool auMoinsUneSoignee = false;
        for (int x = 0; x < LongueurTerrain; x++)
        {
            for (int y = 0; y < LargeurTerrain; y++)
            {
                var plante = Plantes[x][y];

                // Vérifie que la case contient une plante ET qu'elle soit malade ET qu'elle soit déjà semée
                if (plante != null && plante.EstMalade && plante.EstSemee)
                {
                    plante.EstMalade = false; // Soigne la plante
                    plante.NbrMoisMaladeConsecutif = 0; // Réinitialise le compteur de mois malade
                    auMoinsUneSoignee = true; // Au moins une plante a été soignée
                }
            }
        }

        if (auMoinsUneSoignee)
        {
            // Affiche un message de réussite si des plantes ont été soignées
            Console.WriteLine("\n   💉 Vous avez soigné vos plantes d'une terrible maladie !\n");
            return true;
        }
        else
        {
            // Aucune plante malade trouvée
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(" Aucune plante n'est prête à être soignée.");
            Console.ResetColor();
            return false;
        }
    }

    public bool Desherber()// Méthode permettant de désherber les plantes entourées de mauvaises herbes
                           // Retourne true si au moins une plante a été désherbée, false sinon
    {
        bool auMoinsUneDesherbee = false;
        for (int i = 0; i < LongueurTerrain; i++)
        {
            for (int j = 0; j < LargeurTerrain; j++)
            {
                var plante = Plantes[i][j];

                // Vérifie si une plante est présente ET qu'elle est semée ET entourée de mauvaises herbes
                if (plante != null && plante.EstSemee && plante.EstEntoureeParMauvaisesHerbes)
                {
                    plante.Desherber();        // Appel de la méthode de désherbage de la plante de Plante.cs
                    auMoinsUneDesherbee = true;
                }
            }
        }

        // Message de validation de l'action
        if (auMoinsUneDesherbee)
        {
            Console.WriteLine(" 🍀 Vous avez retiré les mauvaises herbes de vos plantes");
            return true; //les plantes ont été désherbées
        }
        else
        {
            // Aucun désherbage possible
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(" Aucune mauvaise herbe n’est prête à être enlevée.");
            Console.ResetColor();
            return false;
        }
    }

    public bool DeracinerPlantesMortes()    // Méthode permettant de retirer toutes les plantes mortes du terrain.
                                            // Retourne true si au moins une plante morte a été déracinée, false sinon.
    {
        bool auMoinsUneDeracinee = false; // Sert à savoir si au moins une plante a été retirée

        for (int x = 0; x < LongueurTerrain; x++)
        {
            for (int y = 0; y < LargeurTerrain; y++)
            {
                var plante = Plantes[x][y];

                // Si la case contient une plante ET qu'elle est semée ET morte
                if (plante != null && plante.EstMorte && plante.EstSemee)
                {
                    plante.RetirerPlanteMorte(); // Méthode de la classe Plante.cs
                    Plantes[x][y] = null;        // Case vide
                    NbPlantes--;                 // Met à jour le compteur de plantes vivantes sur le terrain
                    auMoinsUneDeracinee = true;  // Au moins une plante a été déracinée
                }
            }
        }
        EstRecouvertDePlantesMortes = false;//Pour etre sur que le terrain ne soit pas mis comme recouvert de plantes mortes

        if (auMoinsUneDeracinee)
        {
            // Message de validation de l'action
            Console.WriteLine("\n   🥀 Vous avez retiré toutes les plantes mortes de votre terrain !\n");
            return true;
        }
        else
        {
            // Message d'erreur si aucune plante morte n’a été trouvée
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(" Aucune plante n'est prête à être déracinée.");
            Console.ResetColor();
            return false;
        }
    }

    public bool RecolterPlantes()
    {
        bool auMoinsUneRecoltee = false;
        int totalRecolte = 0; // Compteur des semis récoltés

        for (int i = 0; i < LongueurTerrain; i++)
        {
            for (int j = 0; j < LargeurTerrain; j++)
            {
                var plante = Plantes[i][j];

                // Vérifie si la plante existe, est semée et prête à être récoltée
                if (plante != null && plante.EstRecoltable && plante.EstSemee && !plante.EstMorte
                && !plante.EstMalade && !plante.EstEntoureeParMauvaisesHerbes)
                {
                    int quantite = plante.RecolterPlante();  // Récupère la quantité poduite par cette plante
                    totalRecolte += quantite;                // L'ajoute au total récolté
                    StockTotalDeSemis += quantite;           // Met à jour le stock total de semis disponibles
                    Plantes[i][j] = null;                    // Libère la case, terrain redevient vide
                    NbPlantes--;
                    auMoinsUneRecoltee = true;               // Signale qu'une récolte a eu lieu
                }
            }
        }

        if (auMoinsUneRecoltee)
        {
            Console.WriteLine("\n   🧺 Vous avez récolté vos plantes !\n");
            if (totalRecolte > 0)
                Console.WriteLine($"    Stock total après récolte : {StockTotalDeSemis}\n"); // Affiche le stock mis à jour
            return true; // Indique succès de la récolte
        }
        else
        {
            // Aucun plante prête à récolter
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(" Aucune plante n'était prête à être récoltée.");
            Console.ResetColor();
            return false; // Indique qu'aucune récolte n'a été faite
        }
    }

    public bool VendreSemis(Plante plante)// Méthode permettant de vendre des semis d'une plante spécifique
                                          // Retourne true si la vente est effectuée, false sinon
    {
        // Demande à l'utilisateur la quantité de semis à vendre
        Console.Write($"    Quantité de semis à vendre (prix unitaire = {plante.PrixUnitaireDeLaPlante}): \n");

        // Lit la saisie utilisateur
        string saisie = Console.ReadLine()!;

        // Tente de convertir la saisie en entier, vérifie aussi que la quantité est positive ou nulle
        if (!int.TryParse(saisie, out int quantiteAVendre) || quantiteAVendre <= 0)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(" Quantité invalide."); // Affiche un message d'erreur si la saisie est incorrecte
            Console.ResetColor();
            return false;
        }

        // Vérifie si le joueur a suffisamment de semis en stock pour cette vente
        if (quantiteAVendre > StockTotalDeSemis)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(" Vous n'avez pas assez de semis en stock pour cette vente."); // Message d'erreur
            Console.ResetColor();
            return false;
        }

        // Calcule le gain total de la vente
        double prixUnitaire = plante.PrixUnitaireDeLaPlante;
        double gain = quantiteAVendre * prixUnitaire;

        // Mise à jour du stock et du solde de pièces d'or en chocolat du joueur
        StockTotalDeSemis -= quantiteAVendre;
        PiecesOrEnChocolat += gain;

        // Message de confirmation de la vente
        Console.WriteLine($"✅ Vous avez vendu {quantiteAVendre} semis de {plante.Nom} pour {gain} pièces d’or en chocolat !");
        Console.WriteLine($"💰 Nouveau solde : {PiecesOrEnChocolat} pièces.");

        return true; // Vente réussie
    }

    ///////------------------------------------------------ Méthode liées à la webcam

    public string RecapitulerInformationsWebcam() //Affichage des informations de la webcam
    {
        MettreAJourUrgence();//Préparation du déclenchement du mode urgence

        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        string message = "";
        Console.ResetColor();

        if (IntrusDetecte)
            message += " ❗ Intrus détecté dans le potager !\n";
        if (IntemperieDetectee)
            message += " 🌧️  Conditions météorologiques défavorables détectées !\n";
        if (!IntrusDetecte && !IntemperieDetectee)
            message += " ✅  Aucune urgence détectée par la webcam ce mois-ci.\n";

        return message; //Informations de la webcam donnée au joueur
    }

    private void MettreAJourUrgence() //Initialisation des booléens
    {
        IntrusDetecte = SignalerIntrus();
        IntemperieDetectee = SignalerIntemperie();
    }

    private bool SignalerIntrus()
    {
        return Random.Next(1, 101) <= RisquePresenceIntrus; //Détection ou non d'intrus, cette probabilité est différente en fonction du type de terrain
    }

    private bool SignalerIntemperie()
    {
        return Meteo.Type == TypeMeteo.ForteTempete || Meteo.Type == TypeMeteo.PluiesBattantes; //Détection ou non d'une mauvaise météo
    }

    public void ActiverModeUrgence()
    {
        if (IntrusDetecte || IntemperieDetectee) //Si intrus détecté et/ou mauvaise météo, on active le mode urgence
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("⚠️  Mode Urgence activé :\n");
            Console.ResetColor();

            var (bruitFait, pareVentMis) = GererActionUrgence(); //Choix du joueur suite à l'activation du mode urgence
            GérerConséquencesUrgence(bruitFait, pareVentMis); //Conséquences du choix du joueur
        }
        //Réinitialisation des booléens
        IntrusDetecte = false;
        IntemperieDetectee = false;
        AfficherParcelle(); //Affichage du terrain et des plantes
    }

    private static (bool bruitFait, bool pareVentMis) GererActionUrgence()
    {
        //Outils disponibles pour le mode urgence
        bool bruitFait = false;
        bool pareVentMis = false;

        while (true)
        {
            //Actions possibles à réaliser pour le mode d'urgence (pour complexifier le jeu au joueur, il n'a qu'une action disponible)
            Console.WriteLine("\n⚠️⚠️⚠️  Que voulez-vous faire ?");
            Console.WriteLine("1. Faire du bruit 🗣️");          // Permet d’éloigner les intrus
            Console.WriteLine("2. Déployer un pare-vent 🪟");     // Protège les plantes du vent
            Console.WriteLine("3. Ne rien faire");                // Le joueur choisit de ne rien faire (comportement par défaut)

            // Lecture de la touche saisie par l'utilisateur (sans l'afficher à l'écran)
            ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
            switch (keyInfo.KeyChar)
            {
                // Gestion du choix de l'utilisateur
                case '1':
                    Console.WriteLine("\n   Vous faites du bruit pour éloigner les intrus.\n");
                    bruitFait = true;
                    return (bruitFait, pareVentMis);
                case '2':
                    Console.WriteLine("\n   Vous déployez un pare-vent pour protéger vos récoltes.\n");
                    pareVentMis = true;
                    return (bruitFait, pareVentMis);
                case '3':
                    Console.WriteLine("\n   Vous ne faites rien.\n");
                    bruitFait = false;
                    pareVentMis = false;
                    return (bruitFait, pareVentMis);
                default: //Si erreur de saisie
                    Console.WriteLine("\n   Option invalide. Veuillez réessayer.\n");
                    break;
            }
        }
    }

    private void GérerConséquencesUrgence(bool bruitFait, bool pareVentMis)
    {
        bool auMoinsUneplanteAttaquee = false;

        // Méthode locale qui vérifie s’il existe au moins une plante semée et vivante sur le terrain
        bool ExistePlanteValide()
        {
            for (int i = 0; i < LongueurTerrain; i++)
            {
                for (int j = 0; j < LargeurTerrain; j++)
                {
                    var plante = Plantes[i][j];
                    if (plante != null && plante.EstSemee && !plante.EstMorte)
                        return true;
                }
            }
            return false; // Aucune plante valide trouvée
        }

        // ---------- Cas d'intrus détecté ----------
        if (!bruitFait && IntrusDetecte) // Si le joueur n’a pas fait de bruit et qu’il y a des intrus
        {
            if (!ExistePlanteValide()) // Si aucune plante n’est présente, inutile de tenter une attaque
            {
                Console.WriteLine("\n Aucune plante n'est présente sur le terrain.\n");
            }
            else
            {
                int tentatives = 0;
                bool planteAttaquee = false;

                // Tentatives aléatoires pour trouver une plante à attaquer
                while (!planteAttaquee && tentatives < 1000)
                {
                    int x = Random.Next(0, LongueurTerrain);
                    int y = Random.Next(0, LargeurTerrain);

                    var plante = Plantes[x][y];

                    // Si la plante est présente, semée, et vivante → elle peut être attaquée
                    if (plante != null && plante.EstSemee && !plante.EstMorte)
                    {
                        plante.EstMorte = true; // L'intrus tue la plante
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n   Une plante est morte dans votre jardin à cause des intrus...\n");
                        Console.ResetColor();

                        planteAttaquee = true;
                        auMoinsUneplanteAttaquee = true;
                    }

                    tentatives++;
                }
            }
        }

        // ---------- Cas d’intempérie détectée ----------
        if (!pareVentMis && IntemperieDetectee) // Si le joueur n’a pas mis de pare-vent et qu’il y a du vent
        {
            if (!ExistePlanteValide()) // Aucun effet possible s’il n’y a aucune plante
            {
                Console.WriteLine("\n Aucune plante n'est présente sur le terrain.\n");
            }
            else
            {
                int tentatives = 0;
                bool planteAttaquee = false;

                // Tentatives aléatoires pour trouver une plante à déraciner
                while (!planteAttaquee && tentatives < 1000)
                {
                    int x = Random.Next(0, LongueurTerrain);
                    int y = Random.Next(0, LargeurTerrain);

                    var plante = Plantes[x][y];

                    // Si la plante est semée, présente et vivante → elle peut être déracinée
                    if (plante != null && plante.EstSemee && !plante.EstMorte)
                    {
                        Plantes[x][y] = null; // Elle est retirée du terrain
                        NbPlantes--;         // Décrémentation du nombre de plantes présentes

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n   Une plante a été déracinée dans votre jardin à cause du vent...");
                        Console.ResetColor();

                        planteAttaquee = true;
                        auMoinsUneplanteAttaquee = true;
                    }

                    tentatives++;
                }
            }
        }

        // ---------- Si aucune attaque n'a été faite, avertir le joueur ----------
        if (!auMoinsUneplanteAttaquee)
            Console.WriteLine("\n Aucune plante n'est présente sur le terrain.");
    }



    ///////------------------------------- Méthode liées à des évènements aléatoires

    public void UtiliserFonctionnalitesAleatoire(Meteo Meteo) //Méthode centralisant les méthodes récurrentes de gestion de terrain
    {
        CalculerHumiditeSol(Meteo);
        ApparaitreMauvaiseHerbe();
        TomberMalade();
    }

    public void ApparaitreMauvaiseHerbe()// Parcourt tout le terrain et fait apparaître des mauvaises herbes sur les plantes semées
                                         // Cela simule la pousse aléatoire de mauvaises herbes entre les tours ou au fil du temps
    {
        for (int i = 0; i < LongueurTerrain; i++)
        {
            for (int j = 0; j < LargeurTerrain; j++)
            {
                var plante = Plantes[i][j];

                //Vérifie que la case contient une plante ET qu'elle est semée
                if (plante != null && plante.EstSemee)
                    plante.ApparaitreMauvaiseHerbe(); //Utilisation d'une méthode de Plante.cs
            }
        }
    }

    public void Pourrir()
    {
        bool plantesOntPourri = false;

        for (int i = 0; i < LongueurTerrain; i++)
        {
            for (int j = 0; j < LargeurTerrain; j++)
            {
                var plante = Plantes[i][j];

                if (plante != null && plante.EstSemee && plante.EstRecoltable)
                {
                    if (plante.Pourrir()) //Vérifie que la plante a pourrie
                    {
                        plantesOntPourri = true;
                    }
                }
            }
        }

        if (plantesOntPourri)
            Console.WriteLine("Oh non, vous n'avez pas récolter vos plantes à temps, certaines ont pourris ! 😔");
    }

    public void TomberMalade()// Simule le risque aléatoire de contamination par une maladie pour chaque plante semée
    {
        for (int i = 0; i < LongueurTerrain; i++)
        {
            for (int j = 0; j < LargeurTerrain; j++)
            {
                var plante = Plantes[i][j];

                //Vérifie que la case contient une plante ET qu'elle est semée
                if (plante != null && plante.EstSemee)
                    plante!.EtreMalade(Random); //Utilisation d'une méthode de Plante.cs 
            }
        }
    }

    public void CalculerHumiditeSol(Meteo meteo)
    {
        switch (meteo.Type) //Ajustement du niveau d'humidité du sol en fonction de la météo
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

        if (NiveauHumiditeSol < 8)
        {
            HumiditeSol = "stress hydrique";
        }
        else if (NiveauHumiditeSol < 24)
        {
            HumiditeSol = "humide";
        }
        else if (NiveauHumiditeSol < 40)
            HumiditeSol = "tresHumide";
        else
        {
            HumiditeSol = "extremementHumide";
        }
    }

    ///////------------------------------- Méthode liées à l'affichage d'informations
    public string AfficherResumeTerrain()//Résumé de l'état des plantes
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

    public void AfficherLeSolde() //Résumé des informations du solde bancaire du joueur
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"        💰  Solde actuel du compte : {PiecesOrEnChocolat} pièces d'or en chocolat\n");
        Console.ResetColor();
    }

    public override string ToString()//Résumé des informations du terrain
    {
        return $"       Terrain {Nom} ({Superficie} m²)\n" +
               $"       Type de sol : {TypeSol}\n" +
               $"       Humidité du terrain : {HumiditeSol}\n" +
               $"       Niveau humidité du terrain : {NiveauHumiditeSol}\n" +
               $"       Capacité max : {CapaciteMaxPlantes} plantes\n" +
               $"       Plantes présentes : {NbPlantes}\n" +
               $"       Stock de semis : {StockTotalDeSemis}\n";
    }
}
