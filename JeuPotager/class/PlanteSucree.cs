public class PlanteSucree : Plante
{
    public PlanteSucree(string nom) : base(
        nom,
        nature: "Sucrée",
        solPref: "Sucre",
        espacement: 0.4,
        surfaceNecessaire: 0.3,
        vitesseCroissance: 2,
        besoinEau: "Très humide",
        temperaturePreferemin: 15,
        temperaturePreferemax: 25,
        esperanceVie: 6,
        production: 5,
        nbrMoisAvantRecolte: 4)
    {
        this.Nom = nom;
    }
}