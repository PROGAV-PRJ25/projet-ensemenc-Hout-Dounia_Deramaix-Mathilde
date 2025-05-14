public static class TerrainFactory
{
    public static Terrain CreerTerrainAcidule(string nom, Meteo meteo)
    {
        return new TerrainAcidule(nom, meteo);
    }

    public static Terrain CreerTerrainSucre(string nom, Meteo meteo)
    {
        return new TerrainSucre(nom, meteo);
    }
}