namespace CastTheDice;

public class Dice
{
    private static readonly Random rnd = new();

    public int Value {get; private set;}

    public void ThrowDice()
    {
        Value = rnd.Next(1, 7);
    }
}
