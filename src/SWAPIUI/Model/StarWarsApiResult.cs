namespace SWAPIUI.Model
{ 

public class StarWarsApiResult
{
    public int Count { get; set; }
    public string Next { get; set; }
    public string Previous { get; set; }
    public List<StarWarsCharacter> Results { get; set; }
}
}