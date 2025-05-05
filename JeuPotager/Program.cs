

using System.Diagnostics.Metrics;

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
    "|         2. Autres pays          |",
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

string[] terrainVide = {
    " _________________________________",
    "|                                 |",
    "|              #####              |",
    "|             #     #             |",
    "|                  #              |",
    "|                #                |",
    "|                #                |",
    "|                                 |",
    "|                *                |",
    "|         X. Terrain vide         |",
    "|                                 |",
    "|        semis : Rien             |",
    "|_________________________________|",
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
bool plantesMortes = false;
bool partiefinie = false;
int compteurMois = 1;
string paysSelectionne = "";
string terrainSelectionne = "";

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
}


// Affichage de bienvenue
Console.WriteLine();

for (int i = 0; i < bienvenueENSC.Length; i++)
{
    Console.Write(bienvenueENSC[i]);
    Console.WriteLine();
}

Console.WriteLine();
Console.WriteLine();
Console.WriteLine(" CONSIGNE : ");
Console.WriteLine("🌱 Tu prends les commandes d’un potager dans un pays de ton choix ! À toi de semer, arroser, désherber, récolter, protéger... Mais aussi de faire face à la météo capricieuse et aux visiteurs indésirables !\n");

Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine("🎮 Objectifs :\n");
Console.ResetColor();

Console.WriteLine("- Planter une grande variété de semis et assurer leur bon développement 🌾");
Console.WriteLine("- Surveiller leur état de santé : si plus de 50% des conditions idéales ne sont pas réunies… elles risquent de mourir 😢");
Console.WriteLine("- Attention : certaines plantes peuvent tomber malades de manière imprévisible 🦠");
Console.WriteLine("- Protéger ton potager : des intrus rôdent et des événements inattendus peuvent tout bouleverser 🌪️🐰\n");

Console.WriteLine("⏱️ Deux modes de jeu :\n");

Console.WriteLine("1️⃣  Mode Classique (smois après mois) :");
Console.WriteLine("   🌤️ Planifie calmement : sème, arrose, protège, récolte...");
Console.WriteLine("   🐛 Gère les maladies, les nuisibles, le climat et les températures");
Console.WriteLine("   🌻 Optimise chaque action pour faire pousser un jardin florissant\n");

Console.WriteLine("2️⃣  Mode Urgence (réactions en temps réel) :");
Console.WriteLine("   ⚡ Réagis au quart de tour face aux tempêtes ou à l’apparition d’animaux !");
Console.WriteLine("   🧯 Déclenche des actions rapides pour sauver tes cultures");
Console.WriteLine("   ❗ Petit rappel : les animaux sont sacrés, interdiction de leur faire du mal \n");

Console.WriteLine("Prêt à cultiver ton jardin de rêve et devenir le roi ou la reine des potagers ? À toi de jouer ! 🌿\n");
Console.WriteLine();
Console.WriteLine("Veuillez sélectionner un pays pour votre potager à de son numéro parmi les pays suivants :");
Console.WriteLine();

// Affichage et choix des pays disponibles
for (int i = 0; i < tailleCartePays; i++)
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

    for (int i = 0; i < tailleCarteTerrain; i++) // Affichage et choix des pays disponibles
    {
        Console.Write(langueDeChat[i]);
        Console.Write("   ");
        Console.WriteLine(dragibus[i]);
    }
}

/* else if (touchePays.KeyChar == '2')
{
    Pays Autrespays = new Pays("Pas de pays", "Rien city");
    Console.WriteLine();
    Console.WriteLine($"Veuillez sélectionner un terrain de XXX pour votre potager :");
    Console.WriteLine();
} */

Pays pays = new Pays(paysSelectionne);

ConsoleKeyInfo toucheTerrain = Console.ReadKey();
while ((toucheTerrain.KeyChar != '1') && (toucheTerrain.KeyChar != '2'))
{
    Console.WriteLine();
    Console.WriteLine("Erreur. Réessayez.");
    toucheTerrain = Console.ReadKey();
}

//Meteo meteo = null!;
Terrain? terrain = null!;

if (toucheTerrain.KeyChar == '1')
{
    terrainSelectionne = "Langue de chat";

    Meteo meteo = new Meteo();
    terrain = new Terrain("Langue de chat", 20, 4, 5, "acidulé", "humide", 10, 20.5, meteo);
    meteo = new Meteo(compteurMois, terrain);
    terrain.meteo = meteo;
    meteo.AfficherConditions();
    Console.WriteLine();
    Plante planteLangueChat = new Plante("langueDeChat", "anuelle", "", 1, 1, "", "", "", "", 2, 2, 2);
    pays.AddTerrain(terrain);
    terrain.Semer(planteLangueChat);
    Console.WriteLine($"Vous avez choisi le terrain acidulé : {terrainSelectionne}");
}
if (toucheTerrain.KeyChar == '2')
{
    terrainSelectionne = "Dragibus";
    Meteo meteo2 = new Meteo(compteurMois, terrain); // témpérature consigne terrain Langue de chat = 20°C
    meteo2.AfficherConditions();
    terrain = new Terrain("Dragibus", 20, 4, 5, "sucré", "modéré", 20, 40, meteo2);
    terrain.Semer(new Plante("Dragibus", "sucrée", "", 2.5, 10, "", "", "", "", 20, 5, 15));
    pays.AddTerrain(terrain);
    Console.WriteLine();
    Console.WriteLine($"Vous avez choisi le terrain sucré {terrainSelectionne}");
}




// Début du jeu 
Console.WriteLine("Appuyez sur Entrée pour commencer la partie !");
ConsoleKeyInfo debutJeu = Console.ReadKey();

do
{
    Console.Clear();
    Console.WriteLine(" Premier mois ...");
    Console.WriteLine();

    compteurMois++;
}
while (compteurMois > 2);

while ((compteurMois > 2) && !plantesMortes && !partiefinie)
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
    Meteo nouvelleMeteo = new Meteo(compteurMois, terrain);
    terrain.MiseAJourMeteo(nouvelleMeteo);
    nouvelleMeteo.AfficherConditions();
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("🌿 Informations Terrain");
    Console.ResetColor();
    Console.WriteLine(terrain.ToString());
    Console.WriteLine(terrain.RecapitulerInformationsWebcam());
    terrain.AfficherParcelle();


    compteurMois++;
    PasserAuMoisSuivant();




    //coder jeu
    /* if (touchePartie.Key == ConsoleKey.Enter)
    {
        plantesMortes = true;
    }
    else if (touchePartie.Key == ConsoleKey.Spacebar)
    {
        partiefinie = true;
    }
    */



    //Fin de la partie
    if (plantesMortes == true)
    {
        Console.WriteLine();
        Console.WriteLine("PERDU !");
    }
    else if (partiefinie == true)
    {
        Console.WriteLine();
        Console.WriteLine("Dommage vous étiez en bonne voie !");
    }
}
//action à ajouter pour chaque mois 
/* Console.WriteLine("Choisissez une plante à semer (entrez le nom de la plante) :");
string nomPlante = Console.ReadLine();
Plante plante = // Créer ou récupérer la plante selon le nom
plante.Semer();
*/