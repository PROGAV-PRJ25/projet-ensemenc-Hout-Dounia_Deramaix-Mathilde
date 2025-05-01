

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
int compteurMois = 0;
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
Console.WriteLine(" CONSIGNE : .................");
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

Meteo meteo = null!;

if (toucheTerrain.KeyChar == '1')
{
    terrainSelectionne = "Langue de chat";
    meteo = new Meteo(20, 5, 5, TypeMeteo.Pluie);
    Console.WriteLine();
    Console.WriteLine("Vous avez choisi le terrain acidulé (semis : Langue de chat acidulée)");

}
if (toucheTerrain.KeyChar == '2')
{
    meteo = new Meteo(30, 5, 5, TypeMeteo.Ensoleille);
    Console.WriteLine();
    Console.WriteLine("Vous avez choisi le terrain sucré (semis : Dragibus)");
}

Terrain terrain = new Terrain(terrainSelectionne, 20, 4, 5, "acidule", "humide", 10, meteo);
terrain.AddPlante(new Plante("langueDeChat", "anuelle", "", 1, 1, "", "", "", "", 2, 2, 2));
pays.AddTerrain(terrain);

// Début du jeu 
Console.WriteLine("Appuyez sur Entrée pour commencer la partie !");
ConsoleKeyInfo debutJeu = Console.ReadKey();

do
{
    Console.Clear();
    Console.WriteLine(" Premier mois ...");
    Console.WriteLine();
    Console.WriteLine(" Vos semis ont été plantés !");
    Console.WriteLine("Bon courage !");
    Console.WriteLine();
    // Affichage de la météo pour le terrain actuel
    Console.WriteLine("Information du terrain : ");
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine(terrain.ToString());
    compteurMois++;
}
while (compteurMois == 1);

while ((compteurMois > 1) && !plantesMortes && !partiefinie)
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
