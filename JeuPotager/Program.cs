﻿string[] bienvenueENSC = {
            "  ____  _                                                         ______ _   _  _____                            _____   _ ",
            " |  _ \\(_)                                                       |  ____| \\ | |/ ____|                          / ____| | |",
            " | |_) |_  ___ _ ____   _____ _ __  _   _  ___   ___ _   _ _ __  | |__  |  \\| | (___   ___ _ __ ___   ___ _ __ | |      | |",
            " |  _ <| |/ _ \\ '_ \\ \\ / / _ \\ '_ \\| | | |/ _ \\ / __| | | | '__| |  __| | . ` |\\___ \\ / _ \\ '_ ` _ \\ / _ \\ '_ \\| |      | |",
            " | |_) | |  __/ | | \\ V /  __/ | | | |_| |  __/ \\__ \\ |_| | |    | |____| |\\  |____) |  __/ | | | | |  __/ | | | |____  |_|",
            " |____/|_|\\___|_| |_|\\_/ \\___|_| |_|\\__,_|\\___| |___/\\__,_|_|    |______|_| \\_|_____/ \\___|_| |_| |_|\\___|_| |_|\\_____| (_)"
        };

string[] hariboWorld = {
            " _________________________________",
            "|                                 |",
            "|     ___      .----.      ___    |",
            "|     \\  '-.  /      \\  .-'  /    |",
            "|      > -=.\\/        \\/.=- <     |",
            "|      > -='/\\        /\'=- <      |",
            "|     /__.-'  \\      /  '-.__\\    |",
            "|              '-..-'             |",
            "|                                 |",
            "|        1. Haribo World          |",
            "|_________________________________|",
        };

string[] autrePays = {
    " _________________________________",
    "|                                 |",
    "|              #####              |",
    "|             #     #             |",
    "|                  #              |",
    "|                #                |",
    "|                #                |",
    "|                                 |",
    "|                *                |",
    "|           2. Bientôt 🚧 🔨      |",
    "|_________________________________|",
};


string[] langueDeChat = {
            " _________________________________",
            "|                                 |",
            "|     ___      .----.      ___    |",
            "|     \\  '-.  /      \\  .-'  /    |",
            "|      > -=.\\/        \\/.=- <     |",
            "|      > -='/\\        /\'=- <      |",
            "|     /__.-'  \\      /  '-.__\\    |",
            "|              '-..-'             |",
            "|                                 |",
            "|        1. Terrain Acidulé       |",
            "|                                 |",
            "|      Semis : Langue de chat     |",
            "|_________________________________|",
        };

string[] dragibus = {
            " _________________________________",
            "|                                 |",
            "|     ___      .----.      ___    |",
            "|     \\  '-.  /      \\  .-'  /    |",
            "|      > -=.\\/        \\/.=- <     |",
            "|      > -='/\\        /\'=- <      |",
            "|     /__.-'  \\      /  '-.__\\    |",
            "|              '-..-'             |",
            "|                                 |",
            "|        2. Terrain Sucré         |",
            "|                                 |",
            "|        Semis : Dragibus         |",
            "|_________________________________|",
        };

string[] premierMois ={
       "_____                    _                             _ ",
     "|  __ \\                  (_)                           (_)",
     "| |__) | __ ___ _ __ ___  _  ___ _ __   _ __ ___   ___  _ ___",
     "|  ___/ '__/ _ \\ '_ ` _ \\| |/ _ \\ '__| | '_ ` _ \\ / _ \\| / __|",
     "| |   | | |  __/ | | | | | |  __/ |    | | | | | | (_) | \\__ \\  _   _   _",
     "|_|   |_|  \\___|_| |_| |_|_|\\___|_|    |_| |_| |_|\\___/|_|___/ (_) (_) (_)",
};

string[] moisSuivant = {
 " __  __       _                  _                  _               ",
 "|  \\/  |     (_)                (_)                | |              ",
 "| \\  / | ___  _ ___    ___ _   _ ___   ____ _ _ __ | |_             ",
 "| |\\/| |/ _ \\| / __|  / __| | | | \\ \\ / / _` | '_ \\| __|            ",
 "| |  | | (_) | \\__ \\  \\__ \\ |_| | |\\ V / (_| | | | | |_   _   _   _ ",
 "|_|  |_|\\___/|_|___/  |___/\\__,_|_| \\_/ \\__,_|_| |_|\\__| (_) (_) (_)",
};


//############################################################################################################

int tailleCartePays = 11;
int tailleCarteTerrain = 13;
bool partiefinie = false;
int compteurMois = 1;
string paysSelectionne = "";


// Fonction qui attend une touche valide parmi un ensemble de char (KeyChar)
// Permet la gestion des erreurs de saisie
ConsoleKeyInfo AttendreToucheValide(string messageErreur, params char[] touchesValides)
{
    ConsoleKeyInfo touche;
    do
    {
        touche = Console.ReadKey(true);
        if (!touchesValides.Contains(touche.KeyChar))
            Console.WriteLine(messageErreur);
    } while (!touchesValides.Contains(touche.KeyChar));

    return touche;
}

//Procédure pour passer au mois suivant
void PasserAuMoisSuivant()
{
    Console.WriteLine("Appuyez sur Entrée pour aller au mois suivant ! (ou Espace pour arrêter)");

    // Appel de la fonction qui retourne ConsoleKeyInfo
    ConsoleKeyInfo touche = AttendreToucheValide("\nErreur. Réessayez.", '\r', ' '); // touche Entrée -> '\r' et Espace -> ' ' 

    // On vérifie la touche via la propriété Key, pas KeyChar
    if (touche.Key == ConsoleKey.Spacebar)
    {
        partiefinie = true;
    }

    compteurMois++;
}

//Affiche les informations que du solde bancaire et la météo
void AfficherInformationsMeteoSolde(Terrain terrain, Meteo meteo)
{
    terrain.AfficherLeSolde();
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("🌦️  Informations de la météo actuelle\n");
    Console.ResetColor();
    Console.WriteLine(meteo.ToString());
}

//Affiche que les informations du terrain et des plantes
void AfficherInformationsTerrainPlantes(Terrain terrain, Plante planteUtilisee)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("🚜 Informations du terrain : \n");
    Console.ResetColor();
    Console.WriteLine(terrain.ToString());
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine($"🌱 Les conditions favorites de vos semis :\n");
    Console.ResetColor();
    Console.WriteLine(planteUtilisee.ToString());
}

//Affiche les informations de la webcam
void AfficherInformationsWebcam(Terrain terrain)
{
    Console.ForegroundColor = ConsoleColor.DarkMagenta;
    Console.WriteLine("📷 Informations Webcam\n");
    Console.WriteLine(terrain.RecapitulerInformationsWebcam());
    terrain.ActiverModeUrgence();
    Console.ResetColor();
}

//--------------------------------------------------
//--------------------------------------------------   Début du Code principal
//--------------------------------------------------


// Affichage de bienvenue
Console.WriteLine();
Console.ForegroundColor = ConsoleColor.Blue;
for (int i = 0; i < bienvenueENSC.Length; i++)
{
    Console.Write(bienvenueENSC[i]);
    Console.WriteLine();
}
Console.ResetColor();
Console.WriteLine();
Console.WriteLine();

//Affichage des consignes
Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine(" CONSIGNE : ");
Console.ResetColor();
Console.WriteLine();
Console.WriteLine("🌱 Tu prends les commandes d’un potager dans un pays de ton choix ! À toi de semer, arroser, désherber, récolter, protéger... Mais aussi de faire face à la météo capricieuse et aux visiteurs indésirables !\n");
Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine("🎮 Objectifs :\n");
Console.ResetColor();

Console.WriteLine("     - Planter une grande variété de semis et assurer leur bon développement 🌾; Tout en te faisant un max d'argent 🤑💰");
Console.WriteLine("     - Surveiller leur état de santé : si plus de 50% des conditions idéales ne sont pas réunies… elles risquent de mourir 😢");
Console.WriteLine("     - Attention : certaines plantes peuvent tomber malades de manière imprévisible 🦠");
Console.WriteLine("     - Protéger ton potager : des intrus rôdent et des événements inattendus peuvent tout bouleverser 🌪️🐰\n");
Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine("⏱️  Deux modes de jeu :\n");
Console.ResetColor();

Console.WriteLine("Appuyez sur i pour plus d'informations sinon appuyez sur Entrée pour passez à la suite\n");
ConsoleKeyInfo informations = AttendreToucheValide("Erreur. Réessayez.", 'i', '\r');
if (informations.KeyChar == 'i')
{
    Console.WriteLine("     1️⃣  Mode Classique (mois après mois) :");
    Console.WriteLine("                 Planifie calmement : sème, arrose, protège, récolte...");
    Console.WriteLine("                 Gère les maladies, les nuisibles et les températures");
    Console.WriteLine("                 Optimise chaque action pour faire pousser un jardin florissant\n");
    Console.WriteLine("     2️⃣  Mode Urgence (réactions en temps réel) :");
    Console.WriteLine("                 Réagis au quart de tour face aux tempêtes ou à l’apparition d’animaux !");
    Console.WriteLine("                 Déclenche des actions rapides pour sauver tes cultures\n");
}

//Début du jeu par le choix du pays
Console.WriteLine("\nPrêt à cultiver ton jardin de rêve et devenir le roi ou la reine des potagers ? À toi de jouer !\n");
Console.WriteLine();
Console.WriteLine("     Veuillez sélectionner un pays pour votre potager à l'aide de son numéro parmi les pays suivants :\n");
Console.WriteLine();

for (int i = 0; i < tailleCartePays; i++)// Affichage et choix des pays disponibles
{
    Console.Write(hariboWorld[i]);
    Console.Write("   ");
    Console.WriteLine(autrePays[i]);
}

Console.WriteLine();
ConsoleKeyInfo touchePays = AttendreToucheValide("Erreur. Réessayez.", '1');
if (touchePays.KeyChar == '1')
{
    paysSelectionne = "Haribo World";
    Console.WriteLine();
    Console.WriteLine($"🚜 Vous avez choisi le pays {paysSelectionne} pour votre potager\n");
    Console.WriteLine($"        Veuillez sélectionner un terrain de Haribo World pour votre potager :");
    Console.WriteLine();

    for (int i = 0; i < tailleCarteTerrain; i++) // Affichage et choix des terrains disponibles
    {
        Console.Write(langueDeChat[i]);
        Console.Write("   ");
        Console.WriteLine(dragibus[i]);
    }
    Console.WriteLine();
}

//Création du pays
Pays pays = new Pays(paysSelectionne);

ConsoleKeyInfo toucheTerrain = AttendreToucheValide("Erreur. Réessayez.", '1', '2');

//Initialisation de terrain, plante et meteo (pour pas avoir de probleme de varaible locale)
Terrain? terrain = null!;
Plante? planteUtilisee = null!;
Meteo meteo = new Meteo(); //météo par défaut

//Choix du terrain
if (toucheTerrain.KeyChar == '1')
{
    terrain = TerrainFactory.CreerTerrainAcidule("langueDeChat", meteo);//Création de Terrain Acidulé
    meteo = new Meteo(compteurMois, terrain); //Création de météo
    terrain.Meteo = meteo; //Mise à jour de la météo pour terrain acidulé
    pays.AjouterTerrain(terrain);
    planteUtilisee = PlanteFactory.CreerPlanteAcidulee("langueDeChat");//Création de Plante Acidulée
    Console.WriteLine($"🚜 Vous avez choisi le terrain acidulé! \n");
}
else if (toucheTerrain.KeyChar == '2')
{
    terrain = TerrainFactory.CreerTerrainSucre("dragibus", meteo);//Création de Terrain Sucré
    meteo = new Meteo(compteurMois, terrain); //Création de météo
    terrain.Meteo = meteo;//Mise à jour de la météo pour terrain sucré
    pays.AjouterTerrain(terrain);
    planteUtilisee = PlanteFactory.CreerPlanteSucree("dragibus");//Création de Plante sucrée
    Console.WriteLine($"🚜 Vous avez choisi le terrain sucré! \n");
}
Console.WriteLine("     Appuyez sur Entrée pour commencer la partie !");
ConsoleKeyInfo debutJeu = AttendreToucheValide("Erreur. Réessayez.", '\r');

//Début de partie => mois numéro 1
do
{
    Console.Clear();
    for (int i = 0; i < premierMois.Length; i++)
    {
        Console.Write(premierMois[i]);
        Console.WriteLine();
    }
    AfficherInformationsMeteoSolde(terrain, meteo);
    AfficherInformationsTerrainPlantes(terrain, planteUtilisee);
    terrain.Semer(planteUtilisee);
    terrain.AfficherParcelle();
    terrain.UtiliserFonctionnalitesAleatoire(meteo);
    PasserAuMoisSuivant();
}
while (compteurMois == 1);

bool terrainVideEtPlusDeSemis = false;

//Mois suivant
while ((!terrain.EstRecouvertDePlantesMortes) && (!partiefinie) && (!terrainVideEtPlusDeSemis))
{
    //Mise à jour d'une nouvelle météo pour ce nouveau mois
    Meteo nouvelleMeteo = new Meteo(compteurMois, terrain!); //Mise à 
    terrain!.MiseAJourMeteo(nouvelleMeteo);
    terrainVideEtPlusDeSemis = terrain.VerifierFinDePartie();//On verifie que le terrain n'est pas vide et sans stock de semis

    Console.Clear();
    for (int i = 0; i < moisSuivant.Length; i++)
    {
        Console.Write(moisSuivant[i]);
        Console.WriteLine();
    }
    Console.WriteLine();
    Console.WriteLine($"                   Mois numéro : {compteurMois} ! ");
    Console.WriteLine();
    AfficherInformationsMeteoSolde(terrain, nouvelleMeteo);
    terrain.UtiliserFonctionnalitesAleatoire(nouvelleMeteo);
    Console.WriteLine("Appuyez sur i pour avoir les informations sur votre terrain et vos plantes sinon appuyez sur Entrée pour continuer");
    ConsoleKeyInfo informationsJeu = AttendreToucheValide("Erreur. Réessayez.", 'i', '\r');
    if (informationsJeu.KeyChar == 'i')
        AfficherInformationsTerrainPlantes(terrain, planteUtilisee);

    AfficherInformationsWebcam(terrain);

    //Choix du joueur pour les actions à réaliser
    bool choix;
    for (int i = 1; i <= 3; i++)
    {
        choix = false; // Réinitialise la validité à chaque nouvelle action
        Console.WriteLine($"\nQue souhaitez-vous faire ce mois-ci ? (Vous pouvez faire 3 choix) Action : {i}");
        Console.WriteLine("1. Semer");
        Console.WriteLine("2. Arroser");
        Console.WriteLine("3. Désherber");
        Console.WriteLine("4. Soigner");
        Console.WriteLine("5. Récolter de nouvelles plantes");
        Console.WriteLine("6. Déraciner les plantes fanées");
        Console.WriteLine("7. Vendre des semis");
        Console.WriteLine("8. Ne rien faire");

        //Continue tant que le choix n'est pas bon (erreur de saisie)
        while (!choix && (!terrain.EstRecouvertDePlantesMortes) && (!terrainVideEtPlusDeSemis))
        {
            terrainVideEtPlusDeSemis = terrain.VerifierFinDePartie();//On verifie que le terrain n'est pas vide et sans stock de semis
            terrain.VerifierTerrainMorts(); //On verifie que le terrain n'est pas recouvert de plantes mortes
                                            // Lecture d'une touche pressée par l'utilisateur sans l'afficher à l'écran (intercept: true),
            ConsoleKeyInfo actionPlante = Console.ReadKey(intercept: true);
            Console.WriteLine();
            // Traitement de l'action choisie par l'utilisateur en fonction de la touche appuyée (de '1' à '8').
            switch (actionPlante.KeyChar)
            {
                case '1':
                    // Tente de semer une plante sur le terrain. Si réussi, l'action est validée.
                    if (terrain!.Semer(planteUtilisee))
                        choix = true;
                    break;
                case '2':
                    // Tente d’arroser le terrain. Si réussi, l’action est validée.
                    if (terrain!.Arroser())
                        choix = true;
                    break;
                case '3':
                    // Tente de désherber le terrain. Si réussi, l’action est validée.
                    if (terrain!.Desherber())
                        choix = true;
                    break;
                case '4':
                    // Tente de soigner les plantes malades. Si réussi, l’action est validée.
                    if (terrain!.SoignerPlantesMalades())
                        choix = true;
                    break;
                case '5':
                    // Tente de récolter les plantes mûres. Si réussi, l’action est validée.
                    if (terrain!.RecolterPlantes())
                        choix = true;
                    break;
                case '6':
                    // Tente d’arracher les plantes mortes. Si réussi, l’action est validée.
                    if (terrain!.DeracinerPlantesMortes())
                        choix = true;
                    break;
                case '7':
                    // Tente de vendre des semis (plants non cultivés). Si réussi, l’action est validée.
                    if (terrain!.VendreSemis(planteUtilisee))
                        choix = true;
                    break;
                case '8':
                    // Choix de ne rien faire : moment de repos.
                    choix = true;
                    Console.WriteLine("\n 💤 Moment détente, vous vous reposez et ne faites rien !\n");
                    break;
                default:
                    // Touche invalide : l'utilisateur est invité à réessayer avec une touche de 1 à 8.
                    Console.WriteLine("\nChoix invalide, appuyez sur une touche de 1 à 8.\n");
                    break;
            }

        }
        if (!choix) //si erreur de saisie
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n Action impossible. Réessayez.\n");
            Console.ResetColor();
        }
        terrain.AfficherParcelle();
    }

    Console.WriteLine(terrain.AfficherResumeTerrain()); //Résumé de l'état des plantes
    terrain.Pourrir();
    terrain.CroissancePlantes(terrain.TypeSol!, terrain.HumiditeSol!, meteo.Temperature, meteo.Type);
    PasserAuMoisSuivant();

    //Gestion des fins de partie
    if (terrain.EstRecouvertDePlantesMortes == true) //Si terrain remplit de plantes mortes
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\n   PERDU ! Toutes vos plantes sont mortes !");
        Console.ResetColor();
    }
    else if (partiefinie == true) //Si arret de la partie pas le joueur
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\n   Dommage vous étiez en bonne voie !");
        Console.ResetColor();
    }
    else if (terrainVideEtPlusDeSemis == true) //Si le terrain et vide que qu'il n'y a plus de semis en stock
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\n   PERDU ! Votre terrain est vide et vous n'avez plus de semis en stock !");
        Console.ResetColor();
    }
}
