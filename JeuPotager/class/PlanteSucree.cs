public class PlanteSucree : Plante
{
    public PlanteSucree(string nom) : base(
        nom,
        nature: "Sucrée",
        solPref: "Sucre",
        besoinEau: "tres humide",
        temperaturePreferemin: 15,
        temperaturePreferemax: 25,
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

    public override void Pourrir()
    {
        if (EstRecoltable)
            NbrMoisRecoltableMaisPasRecoltee++;

        if (NbrMoisRecoltableMaisPasRecoltee > 5) // Le produit de ce type de plante ne se gâche pas vite
            EstMorte = true;
    }
}