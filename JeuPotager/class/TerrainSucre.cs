public class TerrainSucre : Terrain
{
    public TerrainSucre(string nom, Meteo meteo)
        : base(
            nom,
            superficie: 20,
            longueurTerrain: 4,
            largeurTerrain: 8,
            typeSol: "sucre",
            humiditeSol: "tresHumide",
            niveauHumiditeSol: 26,
            temperatureConsigne: 20,
            meteo,
            risquePresenceIntrus: 10)
    {
        Nom = nom;
        Meteo = meteo;
    }
}
