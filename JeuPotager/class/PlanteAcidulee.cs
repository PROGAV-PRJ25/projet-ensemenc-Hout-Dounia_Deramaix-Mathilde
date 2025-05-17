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

    public override bool Pourrir()
    {
        if (!EstRecoltable || EstMorte)
            return false; // Pas concernée par la pourriture (pas encore récoltable ou déjà morte)

        NbrMoisRecoltableMaisPasRecoltee++;

        if (NbrMoisRecoltableMaisPasRecoltee > 2)//Au delà de 2 mois en étant récoltable, le produit de la plante pourri
        //Ce type de plante a un produit qui se gache vite
        {
            EstMorte = true;
            EstRecoltable = false; //Réinitialisation de certains état
            return true;
        }
        return false;
    }
}

