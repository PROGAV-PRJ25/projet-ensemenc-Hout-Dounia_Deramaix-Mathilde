public static class PlanteFactory
{
    public static Plante CreerPlanteAcidulee(string nom)
    {
        return new PlanteAcidulee(nom);
    }

    public static Plante CreerPlanteSucree(string nom)
    {
        return new PlanteSucree(nom);
    }
}