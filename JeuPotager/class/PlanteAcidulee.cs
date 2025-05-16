public class PlanteAcidulee : Plante
{
    public PlanteAcidulee(string nom) : base(
        nom,
        nature: "acidulée",
        solPref: "acide",
        besoinEau: "humide",
        temperaturePreferemin: 40,
        temperaturePreferemax: 45,
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

    public override void Pourrir()
    {
        if (EstRecoltable)
            NbrMoisRecoltableMaisPasRecoltee++;

        if (NbrMoisRecoltableMaisPasRecoltee > 2) // Le produit de ce type de plante se gâche vite
            EstMorte = true;
    }
}

