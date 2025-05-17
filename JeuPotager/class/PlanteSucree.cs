public class PlanteSucree : Plante
{
    public PlanteSucree(string nom) : base(
        nom,
        nature: "Sucrée",
        solPref: "sucre",
        besoinEau: "tresHumide",
        temperaturePreferemin: 14,
        temperaturePreferemax: 31,
        production: 5,
        nbrMoisAvantFloraison: 4,
        prixUnitaireDeLaPlante: 8)
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

        if (probabiliteMauvaisesHerbes < 50)  // Si la proba est inférieure à 50% 
                                              // ce type de plante attire frotement les mauvaises herbes
            EstEntoureeParMauvaisesHerbes = true;

        if (EstEntoureeParMauvaisesHerbes)
            NbrMoisAvecMauvaisesHerbesConsecutif++;

        if (NbrMoisAvecMauvaisesHerbesConsecutif > 4)
            // si compteur est à plus de mois avec des mauvaises herbes alors la plante meurt
            // ce type de plante est très résistante face aux mauvaises herbes
            EstMorte = true;
    }

    public override void EtreMalade(Random random)
    {
        double proba = random.Next(0, 100);
        if (proba < 25) // Type de plante très peu résistant face aux maladies
            EstMalade = true;

        if (EstMalade)
            NbrMoisMaladeConsecutif++;

        if (NbrMoisMaladeConsecutif > 3) // Type de plante peu résistant face aux maladies
            EstMorte = true;
    }

    public override bool Pourrir()
    {
        if (!EstRecoltable || EstMorte)
            return false; // Pas concernée par la pourriture (pas encore récoltable ou déjà morte)

        NbrMoisRecoltableMaisPasRecoltee++;

        if (NbrMoisRecoltableMaisPasRecoltee > 5)//Au delà de 5 mois en étant récoltable, le produit de la plante pourri
        //Ce type de plante a un produit qui ne se gache pas vite
        {
            EstMorte = true;
            EstRecoltable = false; //Réinitialisation de certains état
            return true;
        }
        return false;
    }
}