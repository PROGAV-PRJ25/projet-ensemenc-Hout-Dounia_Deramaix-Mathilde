
string[] bienvenueENSC = {
            "  ____  _                                                         ______ _   _  _____                            _____   _ ",
            " |  _ \\(_)                                                       |  ____| \\ | |/ ____|                          / ____| | |",
            " | |_) |_  ___ _ ____   _____ _ __  _   _  ___   ___ _   _ _ __  | |__  |  \\| | (___   ___ _ __ ___   ___ _ __ | |      | |",
            " |  _ <| |/ _ \\ '_ \\ \\ / / _ \\ '_ \\| | | |/ _ \\ / __| | | | '__| |  __| | . ` |\\___ \\ / _ \\ '_ ` _ \\ / _ \\ '_ \\| |      | |",
            " | |_) | |  __/ | | \\ V /  __/ | | | |_| |  __/ \\__ \\ |_| | |    | |____| |\\  |____) |  __/ | | | | |  __/ | | | |____  |_|",
            " |____/|_|\\___|_| |_|\\_/ \\___|_| |_|\\__,_|\\___| |___/\\__,_|_|    |______|_| \\_|_____/ \\___|_| |_| |_|\\___|_| |_|\\_____| (_)"
        };

string[] hariboWorld = {
            "                                                           _________________________________",
            "                                                          |                                 |",
            "                                                          |     ___      .----.      ___    |",
            "                                                          |     \\  '-.  /      \\  .-'  /    |",
            "                                                          |      > -=.\\/        \\/.=- <     |",
            "                                                          |      > -='/\\        /\'=- <      |",
            "                                                          |     /__.-'  \\      /  '-.__\\    |",
            "                                                          |              '-..-'             |",
            "                                                          |                                 |",
            "                                                          |        a. Haribo World          |",
            "                                                          |_________________________________|",
        };

string[] LangueDeChat = {
            "                                                           _________________________________",
            "                                                          |                                 |",
            "                                                          |     ___      .----.      ___    |",
            "                                                          |     \\  '-.  /      \\  .-'  /    |",
            "                                                          |      > -=.\\/        \\/.=- <     |",
            "                                                          |      > -='/\\        /\'=- <      |",
            "                                                          |     /__.-'  \\      /  '-.__\\    |",
            "                                                          |              '-..-'             |",
            "                                                          |                                 |",
            "                                                          |        a. Terrain Acidulé       |",
            "                                                          |                                 |",
            "                                                          |      semis : Langue de chat     |",
            "                                                          |_________________________________|",
        };

string[] Dragibus = {
            "                                                           _________________________________",
            "                                                          |                                 |",
            "                                                          |     ___      .----.      ___    |",
            "                                                          |     \\  '-.  /      \\  .-'  /    |",
            "                                                          |      > -=.\\/        \\/.=- <     |",
            "                                                          |      > -='/\\        /\'=- <      |",
            "                                                          |     /__.-'  \\      /  '-.__\\    |",
            "                                                          |              '-..-'             |",
            "                                                          |                                 |",
            "                                                          |        b. Terrain Sucré         |",
            "                                                          |                                 |",
            "                                                          |        semis : Dragibus         |",
            "                                                          |_________________________________|",
        };

bool plantesMortes = false;
bool partiefinie = false;

int compteurMois = 0;
string appelationPays;
string appelationTerrain;

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

for (int i = 0; i < hariboWorld.Length; i++)
{
    Console.Write(hariboWorld[i]);
    Console.WriteLine();
}

ConsoleKeyInfo touchePays = Console.ReadKey();
while (touchePays.KeyChar != 'a')
{
    Console.WriteLine();
    Console.WriteLine("Erreur. Réessayez.");
    touchePays = Console.ReadKey();
}

if (touchePays.KeyChar == 'a')
{
    Console.WriteLine();
    Console.WriteLine("Veuillez sélectionner un terrain du pays choisi pour votre potager parmi les terrains disponibles :");
}

for (int i = 0; i < LangueDeChat.Length; i++)
{
    Console.Write(LangueDeChat[i]);
    Console.WriteLine();
}

for (int i = 0; i < Dragibus.Length; i++)
{
    Console.Write(Dragibus[i]);
    Console.WriteLine();
}

ConsoleKeyInfo toucheTerrain = Console.ReadKey();
while ((toucheTerrain.KeyChar != 'a') && (toucheTerrain.KeyChar != 'b'))
{
    Console.WriteLine();
    Console.WriteLine("Erreur. Réessayez.");
    toucheTerrain = Console.ReadKey();
}

if (toucheTerrain.KeyChar == 'a')
{
    Console.WriteLine();
    Console.WriteLine("Vous avez choisi le terrain acidulé (semis : Langue de chat acidulée)");
}
if (toucheTerrain.KeyChar == 'b')
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

