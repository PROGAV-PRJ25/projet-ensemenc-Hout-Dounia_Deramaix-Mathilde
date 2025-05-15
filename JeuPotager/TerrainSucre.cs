public class TerrainSucre : Terrain
{
    public TerrainSucre(string nom, Meteo meteo)
        : base(
            nom,
            superficie: 20,
            longueurTerrain: 4,
            largeurTerrain: 8,
            typeSol: "sucre",
            humiditeSol: "très humide",
            niveauHumiditeSol: 6,
            temperatureConsigne: 20.5,
            meteo)
    {
        this.Nom = nom;
        this.meteo = meteo;
    }
}
