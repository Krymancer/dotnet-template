using FluentAssertions;

namespace Tests;

public class Tests
{
    [Fact]
    public void MathIsHard()
    {
        (1 + 1 == 2).Should().BeTrue();
    }
}