public class PlanteAcidulee : Plante
{
    public PlanteAcidulee(string nom) : base(
        nom,
        nature: "acidulée",
        solPref: "acide",
        besoinEau: "humide",
        temperaturePreferemin: 35,
        temperaturePreferemax: 50,
        production: 3,
        nbrMoisAvantFloraison: 6,
        prixUnitaireDeLaPlante: 10)
    {
        Nom = nom;
    }
    public override Plante Cloner()
    {
        return new PlanteAcidulee(Nom!);
    }

    public override void ApparaitreMauvaiseHerbe()
    {
        Random random = new Random();
        double probabiliteMauvaisesHerbes = random.Next(0, 100);  // génère une valeur aléatoire entre 0 et 99

        if (probabiliteMauvaisesHerbes < 20)  // Si la proba est inférieure à 20% 
                                              // ce type de plante attire peu les mauvaises herbes
            EstEntoureeParMauvaisesHerbes = true;

        if (EstEntoureeParMauvaisesHerbes)
            NbrMoisAvecMauvaisesHerbesConsecutif++;

        if (NbrMoisAvecMauvaisesHerbesConsecutif > 2)
            // si compteur est à plus de mois avec des mauvaises herbes alors la plante meurt
            // ce type de plante est peu résistant face aux mauvaises herbes
            EstMorte = true;
    }

    public override void EtreMalade(Random random)
    {
        double proba = random.Next(0, 100);
        if (proba < 10) // Type de plante très résistant face aux maladies
            EstMalade = true;

        if (EstMalade)
            NbrMoisMaladeConsecutif++;

        if (NbrMoisMaladeConsecutif > 5) // Type de plante très résistant face aux maladies
            EstMorte = true;
    }

    public override void Pourrir(Plante plante)
    {
        if (plante.EstRecoltable)
        {
            if (plante.NbrMoisDeCroissance <= plante.NbrMoisAvantFloraison)
            {
                plante.EstRecoltable = false;
            }
            else
            {
                plante.NbrMoisRecoltableMaisPasRecoltee++;
            }

            if (plante.NbrMoisRecoltableMaisPasRecoltee > 5) // Le produit ne se conserve plus
            {
                plante.EstMorte = true;
                Console.WriteLine("Oh non, une plante est morte car elle n'a pas été récoltée à temps !");
            }
        }

        Console.WriteLine($"Mois sans récolte : {plante.NbrMoisRecoltableMaisPasRecoltee}");
    }
}

