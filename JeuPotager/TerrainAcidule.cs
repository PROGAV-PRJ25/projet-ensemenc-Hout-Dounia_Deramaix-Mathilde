public class TerrainAcidule : Terrain
{
    public TerrainAcidule(string nom, Meteo meteo)
        : base(
            nom,
            superficie: 20,
            longueurTerrain: 4,
            largeurTerrain: 5,
            typeSol: "acide",
            humiditeSol: "humide",
            niveauHumiditeSol: 9,
            temperatureConsigne: 40.5,
            meteo,
            risquePresenceIntrus: 10)
    {
        Nom = nom;
        Meteo = meteo;
    }
}


