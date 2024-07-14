namespace Domain.ValueObjects;

public class Colour(string code) : ValueObject
{
    private Colour() : this("#0000000")
    {
    }
    public static Colour White => new("#FFFFFF");

    public static Colour Red => new("#FF5733");

    public static Colour Orange => new("#FFC300");

    public static Colour Yellow => new("#FFFF66");

    public static Colour Green => new("#CCFF99");

    public static Colour Blue => new("#6666FF");

    public static Colour Purple => new("#9966CC");

    public static Colour Grey => new("#999999");

    public string Code { get; } = string.IsNullOrWhiteSpace(code) ? "#000000" : code;

    protected static IEnumerable<Colour> SupportedColours
    {
        get
        {
            yield return White;
            yield return Red;
            yield return Orange;
            yield return Yellow;
            yield return Green;
            yield return Blue;
            yield return Purple;
            yield return Grey;
        }
    }

    public static Colour From(string code)
    {
        var colour = new Colour(code);

        if (!SupportedColours.Contains(colour)) throw new UnsupportedColourException(code);

        return colour;
    }

    public static implicit operator string(Colour colour)
    {
        return colour.ToString();
    }

    public static explicit operator Colour(string code)
    {
        return From(code);
    }

    public override string ToString()
    {
        return Code;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Code;
    }
}