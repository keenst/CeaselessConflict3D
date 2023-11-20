public struct Fighter
{
    public float HP { get; set; }
    public float HPMax { get; }
    public float SP { get; set; }
    public float SPMax { get; }
    
    public Fighter(float hp, float sp)
    {
        HPMax = hp;
        HP = hp;
        SPMax = sp;
        SP = sp;
    }
}
