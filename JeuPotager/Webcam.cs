public class Webcam
{
    private Random random;
    public bool IntrusDetecte { get; private set; }
    public bool IntemperieDetectee { get; private set; }

    public Webcam()
    {
        random = new Random();
        IntrusDetecte = false;
        IntemperieDetectee = false;
    }

    // Vérification meteo
    public void SurveillerMeteo(Meteo meteo)
    {
        IntemperieDetectee = meteo.EstIntemperie;

        if (IntemperieDetectee)
        {
            Console.WriteLine("intempéries détectées dans votre jardin");
        }
    }

    // Génère aléatoirement la présence d'un intrus
    public void SurveillerIntrus()
    {
        int chance = 10; // 10% de chance
        IntrusDetecte = random.Next(1, 101) <= chance;

        if (IntrusDetecte)
        {
            Console.WriteLine("intrus repéré dans le potager !");
        }
    }

    public void AfficherInfoWebcam()
    {
        Console.WriteLine();
        Console.WriteLine("Information transmise par la webcam pendant le mois :");
        Console.WriteLine();
    }

}
