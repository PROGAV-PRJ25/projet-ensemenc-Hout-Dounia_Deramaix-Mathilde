public class PlanteAcidulee : Plante
{
    public PlanteAcidulee(string nom) : base(
        nom,
        nature: "acidulée",
        solPref: "acide",
        espacement: 0.5,
        surfaceNecessaire: 0.4,
        vitesseCroissance: 3,
        besoinEau: "humide",
        temperaturePreferemin: 40,
        temperaturePreferemax: 45,
        esperanceVie: 8,
        production: 3,
        nbrMoisAvantRecolte: 6,
        prixUnitaireDeLaPlante: 10)
    {
        this.Nom = nom;
    }
}

