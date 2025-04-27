
string[] bienvenueENSC = {
            "  ____  _                                                         ______ _   _  _____                            _____   _ ",
            " |  _ \\(_)                                                       |  ____| \\ | |/ ____|                          / ____| | |",
            " | |_) |_  ___ _ ____   _____ _ __  _   _  ___   ___ _   _ _ __  | |__  |  \\| | (___   ___ _ __ ___   ___ _ __ | |      | |",
            " |  _ <| |/ _ \\ '_ \\ \\ / / _ \\ '_ \\| | | |/ _ \\ / __| | | | '__| |  __| | . ` |\\___ \\ / _ \\ '_ ` _ \\ / _ \\ '_ \\| |      | |",
            " | |_) | |  __/ | | \\ V /  __/ | | | |_| |  __/ \\__ \\ |_| | |    | |____| |\\  |____) |  __/ | | | | |  __/ | | | |____  |_|",
            " |____/|_|\\___|_| |_|\\_/ \\___|_| |_|\\__,_|\\___| |___/\\__,_|_|    |______|_| \\_|_____/ \\___|_| |_| |_|\\___|_| |_|\\_____| (_)"
        };
string appelationPays = "";
int tailleCartePays = 11;
int tailleCarteTerrain = 13;
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
            "|      semis : Langue de chat     |",
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
            "|        semis : Dragibus         |",
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

bool plantesMortes = false;
bool partiefinie = false;

int compteurMois = 0;

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
    appelationPays = "Haribo World";
    Console.WriteLine();
    Console.WriteLine($"Veuillez sélectionner un terrain de {appelationPays} pour votre potager :");
}
else if (touchePays.KeyChar == '2')
{
    appelationPays = "Autre pays";
    Console.WriteLine();
    Console.WriteLine($"Veuillez sélectionner un terrain de {appelationPays} pour votre potager :");
}


// Affichage et choix des pays disponibles

if (appelationPays == "Haribo World")
{
    for (int i = 0; i < tailleCarteTerrain; i++)
    {
        Console.Write(langueDeChat[i]);
        Console.Write("   ");
        Console.WriteLine(dragibus[i]);
    }
}

Console.WriteLine();
ConsoleKeyInfo toucheTerrain = Console.ReadKey();
while ((toucheTerrain.KeyChar != '1') && (toucheTerrain.KeyChar != '2'))
{
    Console.WriteLine();
    Console.WriteLine("Erreur. Réessayez.");
    toucheTerrain = Console.ReadKey();
}

if (toucheTerrain.KeyChar == '1')
{
    Console.WriteLine();
    Console.WriteLine("Vous avez choisi le terrain acidulé (semis : Langue de chat acidulée)");
}
if (toucheTerrain.KeyChar == '2')
{
    Console.WriteLine();
    Console.WriteLine("Vous avez choisi le terrain sucré (semis : Dragibus)");
}

// Début du jeu 
ConsoleKeyInfo touchePartie = Console.ReadKey();
while (!plantesMortes && !partiefinie)
{
    Console.WriteLine();

    //coder jeu
    if (touchePartie.Key == ConsoleKey.Enter)
    {
        plantesMortes = true;
    }
    else if (touchePartie.Key == ConsoleKey.Spacebar)
    {
        partiefinie = true;
    }

    compteurMois++;
}

//Fin de la partie
if (plantesMortes == true)
{
    Console.WriteLine("PERDU !");
}
else if (partiefinie == true)
{
    Console.WriteLine("Dommage vous étiez en bonne voie !");
}

