
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

string[] moisSuivant = {
 " __  __       _                  _                  _               ",
 "|  \\/  |     (_)                (_)                | |              ",
 "| \\  / | ___  _ ___    ___ _   _ ___   ____ _ _ __ | |_             ",
 "| |\\/| |/ _ \\| / __|  / __| | | | \\ \\ / / _` | '_ \\| __|            ",
 "| |  | | (_) | \\__ \\  \\__ \\ |_| | |\\ V / (_| | | | | |_   _   _   _ ",
 "|_|  |_|\\___/|_|___/  |___/\\__,_|_| \\_/ \\__,_|_| |_|\\__| (_) (_) (_)",
};

//############################################################################################################

Webcam webcam = new Webcam();
string appelationPays = "";
string appelationTerrain = "";
int tailleCartePays = 11;
int tailleCarteTerrain = 13;
bool plantesMortes = false;
bool partiefinie = false;
int compteurMois = 0;

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

// definition de la meteo pour chaque terrain 
Meteo meteoLangueDeChat = new Meteo(20, "Humide", 5, "temps orageux");
Meteo meteoDragibus = new Meteo(22, "Modéré", 2, "ensoleillé");
Meteo? meteoTerrainActuel = null;

if (toucheTerrain.KeyChar == '1')
{
    Console.WriteLine();
    Console.WriteLine("Vous avez choisi le terrain acidulé (semis : Langue de chat acidulée)");
    appelationTerrain = "Terrain de langue de chat";
    meteoTerrainActuel = meteoLangueDeChat;

}
if (toucheTerrain.KeyChar == '2')
{
    Console.WriteLine();
    Console.WriteLine("Vous avez choisi le terrain sucré (semis : Dragibus)");
    meteoTerrainActuel = meteoDragibus;
}

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
    Console.WriteLine($"Météo actuelle pour {appelationTerrain} :");
    if (meteoTerrainActuel != null)
    {
        Console.WriteLine($"Température: {meteoTerrainActuel.Temperature}°C");
        Console.WriteLine($"Humidité: {meteoTerrainActuel.Humidite}");
        Console.WriteLine($"Précipitations: {meteoTerrainActuel.TauxPrécipitations} mm");
        Console.WriteLine($"Type de météo: {meteoTerrainActuel.TypeMeteo}");
        webcam.SurveillerMeteo(meteoTerrainActuel);
    }



    webcam.SurveillerIntrus();
    webcam.AfficherInfoWebcam();

    // suite du jeu
    PasserAuMoisSuivant();
    compteurMois++;

}
while (compteurMois == 1);

while ((compteurMois > 1) && (appelationTerrain == "Terrain de langue de chat") && !plantesMortes && !partiefinie)
//cas terrain de langue de chat 
// réfléchir à comment faire pour toutes les combinaisons sans que ce soit trop long en code ( pas 2 ou 4 fois le même code)
{
    Console.Clear();
    for (int i = 0; i < moisSuivant.Length; i++)
    {
        Console.Write(moisSuivant[i]);
        Console.WriteLine();
    }
    Console.WriteLine();
    Console.WriteLine($"                   Mois numéro : {compteurMois} ! ");
    //Affichage meteo : 
    Console.WriteLine($"Météo actuelle pour {appelationTerrain} :");
    if (meteoTerrainActuel != null)
    {
        Console.WriteLine($"Température: {meteoTerrainActuel.Temperature}°C");
        Console.WriteLine($"Humidité: {meteoTerrainActuel.Humidite}");
        Console.WriteLine($"Précipitations: {meteoTerrainActuel.TauxPrécipitations} mm");
        Console.WriteLine($"Type de météo: {meteoTerrainActuel.TypeMeteo}");
        webcam.SurveillerMeteo(meteoTerrainActuel);
    }


    webcam.SurveillerIntrus();
    webcam.AfficherInfoWebcam();



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

