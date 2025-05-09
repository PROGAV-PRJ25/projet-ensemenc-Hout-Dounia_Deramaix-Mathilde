// classe heritière pour gerer les mauvaise herbes
public class MauvaiseHerbe : Plante
{
    public MauvaiseHerbe()
        : base("Mauvaise herbe", "Invasive", "N'importe", 0.1, 0.1, "Rapide", "Aucune", "Aucune", "Aucune", 0, 1, 0)
    {

    }
    public override string ToString()
    {
        return $"🌾";
    }
}
