using dotnet_rpg.Models;

namespace dotnet_rpg;

public class Character
{
    public int Id { get; set; }
    public string Name { get; set; } = "Frodo";
    public int HitPointd { get; set; } = 100;
    public int Strength { get; set; } = 10;
    public int Defence { get; set; } = 10;
    public int Intellengece { get; set; } = 10;
    public RpgClass Class { get; set; } = RpgClass.Thief;

}
