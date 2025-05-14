public class PlanteAcidulee : Plante
{
    public PlanteAcidulee(string nom) : base(
        nom,
        nature: "Acidulée",
        solPref: "Acide",
        espacement: 0.5,
        surfaceNecessaire: 0.4,
        vitesseCroissance: 3,
        besoinEau: "Humide",
        nbrDeMoisSansLumConsecutif: 3,
        temperaturePreferemin: 40,
        temperaturePreferemax: 45,
        esperanceVie: 8,
        production: 3,
        nbrMoisAvantRecolte: 6)
    {
        this.Nom = nom;
    }
}

