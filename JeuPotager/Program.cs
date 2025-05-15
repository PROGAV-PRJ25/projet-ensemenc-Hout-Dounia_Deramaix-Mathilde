string[] bienvenueENSC = {
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
    "|           2. Bientôt            |",
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

void PasserAuMoisSuivant()
{
    Console.WriteLine("Appuyez sur Entrée pour aller au mois suivant ! (ou Espace pour arreter)");
    ConsoleKeyInfo suiteJeu = Console.ReadKey(true); // true pour pas afficher la touche

    while ((suiteJeu.Key != ConsoleKey.Enter) && (suiteJeu.Key != ConsoleKey.Spacebar))
    {
        Console.WriteLine("Erreur. Réessayez.");
        suiteJeu = Console.ReadKey(true);
    }
    if (suiteJeu.Key == ConsoleKey.Spacebar)
    {
        partiefinie = true;
    }
    compteurMois++;
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
Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine(" CONSIGNE : ");
Console.ResetColor();
Console.WriteLine("🌱 Tu prends les commandes d’un potager dans un pays de ton choix ! À toi de semer, arroser, désherber, récolter, protéger... Mais aussi de faire face à la météo capricieuse et aux visiteurs indésirables !\n");
Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine("🎮 Objectifs :\n");
Console.ResetColor();

Console.WriteLine("- Planter une grande variété de semis et assurer leur bon développement 🌾; Tout en te faisant un max d'argent 🤑💰");
Console.WriteLine("- Surveiller leur état de santé : si plus de 50% des conditions idéales ne sont pas réunies… elles risquent de mourir 😢");
Console.WriteLine("- Attention : certaines plantes peuvent tomber malades de manière imprévisible 🦠");
Console.WriteLine("- Protéger ton potager : des intrus rôdent et des événements inattendus peuvent tout bouleverser 🌪️🐰\n");
Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine("⏱️ Deux modes de jeu :\n");
Console.ResetColor();
Console.WriteLine("Appuyez sur i pour plus d'informations sinon appuyez sur entrée");
ConsoleKeyInfo informations = Console.ReadKey();
while ((informations.KeyChar != 'i') && (informations.Key != ConsoleKey.Enter))
{
    Console.WriteLine();
    Console.WriteLine("Erreur. Réessayez.");
    informations = Console.ReadKey();
}
if (informations.KeyChar == 'i')
{
    Console.WriteLine("1️⃣  Mode Classique (smois après mois) :");
    Console.WriteLine("   🌤️ Planifie calmement : sème, arrose, protège, récolte...");
    Console.WriteLine("   🐛 Gère les maladies, les nuisibles, le climat et les températures");
    Console.WriteLine("   🌻 Optimise chaque action pour faire pousser un jardin florissant\n");
    Console.WriteLine("2️⃣  Mode Urgence (réactions en temps réel) :");
    Console.WriteLine("   ⚡ Réagis au quart de tour face aux tempêtes ou à l’apparition d’animaux !");
    Console.WriteLine("   🧯 Déclenche des actions rapides pour sauver tes cultures");
    Console.WriteLine("   ❗ Petit rappel : les animaux sont sacrés, interdiction de leur faire du mal \n");
}

Console.WriteLine("Prêt à cultiver ton jardin de rêve et devenir le roi ou la reine des potagers ? À toi de jouer !\n");
Console.WriteLine();
Console.WriteLine("Veuillez sélectionner un pays pour votre potager à de son numéro parmi les pays suivants :");
Console.WriteLine();

for (int i = 0; i < tailleCartePays; i++)// Affichage et choix des pays disponibles
{
    Console.Write(hariboWorld[i]);
    Console.Write("   ");
    Console.WriteLine(autrePays[i]);
}

Console.WriteLine();
ConsoleKeyInfo touchePays = Console.ReadKey();
while (touchePays.KeyChar != '1')
{
    Console.WriteLine();
    Console.WriteLine("Erreur. Réessayez.");
    touchePays = Console.ReadKey();
}

if (touchePays.KeyChar == '1')
{
    paysSelectionne = "Haribo World";
    Console.WriteLine();
    Console.WriteLine($"Veuillez sélectionner un terrain de Haribo World pour votre potager :");
    Console.WriteLine();

    for (int i = 0; i < tailleCarteTerrain; i++) // Affichage et choix des terrains disponibles
    {
        Console.Write(langueDeChat[i]);
        Console.Write("   ");
        Console.WriteLine(dragibus[i]);
    }
    Console.WriteLine();
}

Pays pays = new Pays(paysSelectionne);

ConsoleKeyInfo toucheTerrain = Console.ReadKey();
while ((toucheTerrain.KeyChar != '1') && (toucheTerrain.KeyChar != '2'))
{
    Console.WriteLine();
    Console.WriteLine("Erreur. Réessayez.");
    toucheTerrain = Console.ReadKey();
}

Terrain? terrain = null!;
Plante? planteUtilisee = null!;
Meteo meteo = new Meteo();

if (toucheTerrain.KeyChar == '1')
{
    terrain = TerrainFactory.CreerTerrainAcidule("langueDeChat", meteo);
    meteo = new Meteo(compteurMois, terrain);
    terrain.meteo = meteo;
    pays.AddTerrain(terrain);
    planteUtilisee = PlanteFactory.CreerPlanteAcidulee("langueDeChat");
    Console.WriteLine($"Vous avez choisi le terrain acidulé! \n");
}
if (toucheTerrain.KeyChar == '2')
{
    terrain = TerrainFactory.CreerTerrainSucre("Dragibus", meteo);
    meteo = new Meteo(compteurMois, terrain);
    terrain.meteo = meteo;
    pays.AddTerrain(terrain);
    planteUtilisee = PlanteFactory.CreerPlanteSucree("Dragibus");
    Console.WriteLine($"Vous avez choisi le terrain acidulé! \n");
}

Console.WriteLine("Appuyez sur Entrée pour commencer la partie !");
ConsoleKeyInfo debutJeu = Console.ReadKey();
while (debutJeu.Key != ConsoleKey.Enter)
{
    Console.WriteLine();
    Console.WriteLine("Erreur. Réessayez.");
    debutJeu = Console.ReadKey();
}

do
{
    Console.Clear();
    for (int i = 0; i < premierMois.Length; i++)
    {
        Console.Write(premierMois[i]);
        Console.WriteLine();
    }
    Console.WriteLine();
    terrain.AfficherLeSolde();
    meteo.AfficherConditions();
    terrain.Semer(planteUtilisee);
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("🧑‍🌾 Informations du terrain : \n");
    Console.ResetColor();
    Console.WriteLine(terrain.ToString());
    terrain.AfficherParcelle();
    PasserAuMoisSuivant();
}
while (compteurMois == 1);
while ((!terrain.EstRecouvertDePlantesMortes) && (!partiefinie))
{
    Console.Clear();
    for (int i = 0; i < moisSuivant.Length; i++)
    {
        Console.Write(moisSuivant[i]);
        Console.WriteLine();
    }
    Console.WriteLine();
    Console.WriteLine($"                   Mois numéro : {compteurMois} ! ");
    Console.WriteLine();

    terrain.AfficherLeSolde();

    Meteo nouvelleMeteo = new Meteo(compteurMois, terrain!);
    terrain!.MiseAJourMeteo(nouvelleMeteo);
    nouvelleMeteo.AfficherConditions();
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("🧑‍🌾 Informations du terrain : \n");
    Console.ResetColor();
    Console.WriteLine(terrain.ToString());

    Console.ForegroundColor = ConsoleColor.DarkMagenta;
    Console.WriteLine("📷 Informations Webcam");
    terrain.RecapitulerInformationsWebcam();
    terrain.ActiverModeUrgence();
    Console.ResetColor();
    terrain.UtiliserFonctionnalitesAleatoire(meteo);


    terrain.EtreMort();

    bool choix;
    for (int i = 1; i <= 3; i++)
    {
        choix = false; // Réinitialise la validité à chaque nouvelle action

        Console.WriteLine($"\nQue souhaitez-vous faire ce mois-ci ? (Vous pouvez faire 3 choix) Action : {i}");
        Console.WriteLine("1. Arroser");
        Console.WriteLine("2. Récolter de nouvelles plantes");
        Console.WriteLine("3. Désherber");
        Console.WriteLine("4. Semer");
        Console.WriteLine("5. Soigner");
        Console.WriteLine("6. Déraciner les plantes fanées");
        Console.WriteLine("7. Vendre des semis");
        Console.WriteLine("8. Ne rien faire");

        while (!choix) // On boucle jusqu'à ce que l'utilisateur fasse un choix valide
        {
            ConsoleKeyInfo actionPlante = Console.ReadKey(intercept: true);
            Console.WriteLine();

            switch (actionPlante.KeyChar)
            {
                case '1':
                    terrain!.Arroser();
                    choix = true;
                    break;
                case '2':
                    terrain!.RecolterPlantes();
                    choix = true;
                    break;
                case '3':
                    terrain!.Desherber();
                    choix = true;
                    break;
                case '4':
                    terrain!.Semer(planteUtilisee);
                    choix = true;
                    break;
                case '5':
                    terrain!.SoignerPlantesMalades();
                    choix = true;
                    break;
                case '6':
                    terrain!.DeracinerPlantesMortes();
                    choix = true;
                    break;
                case '7':
                    terrain!.VendreSemis(planteUtilisee);
                    choix = true;
                    break;
                case '8':
                    choix = true;
                    break;
                default:
                    Console.WriteLine("\nChoix invalide, appuyez sur une touche de 1 à 8.\n");
                    break;
            }
            terrain.AfficherParcelle();
        }
    }
    Console.WriteLine(terrain.AfficherResumeTerrain());
    terrain.CroissancePlantes(terrain.TypeSol, terrain.HumiditeSol, meteo.Temperature, meteo);
    PasserAuMoisSuivant();
}
if (terrain.EstRecouvertDePlantesMortes == true)
{
    Console.WriteLine();
    Console.WriteLine("PERDU ! Toutes vos plantes sont mortes !");
}
else if (partiefinie == true)
{
    Console.WriteLine();
    Console.WriteLine("Dommage vous étiez en bonne voie !");
}
