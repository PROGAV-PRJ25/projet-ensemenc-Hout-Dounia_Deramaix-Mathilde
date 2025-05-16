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
            niveauHumiditeSol: 4,
            temperatureConsigne: 40.5,
            meteo)
    {
        Nom = nom;
        Meteo = meteo;
    }
}


