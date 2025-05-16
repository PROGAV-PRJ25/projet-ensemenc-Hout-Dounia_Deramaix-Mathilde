public static class PlanteFactory
{
    //Utilisation d'un design pattern factory car on crée l'une des deux plantes selon le choix du joueur
    //Permet aussi une alternative au long constructeur de Plante.cs
    public static Plante CreerPlanteAcidulee(string nom)
    {
        return new PlanteAcidulee(nom);
    }

    public static Plante CreerPlanteSucree(string nom)
    {
        return new PlanteSucree(nom);
    }
}