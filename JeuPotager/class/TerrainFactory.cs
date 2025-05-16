public static class TerrainFactory
{
    //Utilisation d'un design pattern factory car on crée l'une des deux terrains selon le choix du joueur
    //Permet aussi une alternative au long constructeur de Terrain.cs
    public static Terrain CreerTerrainAcidule(string nom, Meteo meteo)
    {
        return new TerrainAcidule(nom, meteo);
    }

    public static Terrain CreerTerrainSucre(string nom, Meteo meteo)
    {
        return new TerrainSucre(nom, meteo);
    }
}