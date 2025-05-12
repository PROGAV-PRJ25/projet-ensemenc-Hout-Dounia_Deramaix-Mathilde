public class MauvaiseHerbe : Plante
{
    public MauvaiseHerbe() : base(
        nom: "Mauvaise herbe",
        nature: "Invasive",
        solPref: "Tous types",
        espacement: 0.1,
        surfaceNecessaire: 0.1,
        vitesseCroissance: 1,
        besoinEau: "Aucune",
        nbrDeMoisSansLumConsecutif: 0,
        temperaturePreferemin: 0,
        temperaturePreferemax: 50,
        esperanceVie: 2,
        production: 0,
        nbrMoisAvantRecolte: 1)
    {
    }

    public override string ToString()
    {
        return $"🍀";
    }
}
