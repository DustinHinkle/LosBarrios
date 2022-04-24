using Xunit;
using Xunit.Abstractions;
using LosBarriosDomain.SpeakerAggregate;
using LosBarriosDomain.SpeakerSessionAggregate;

namespace tests;

public class SpeakerTest
{
    [Fact]
    public void TestSpeakerFirstName()
    {
        MySpeakerHelper helper = new MySpeakerHelper();
        //Arrange
        Speaker s = new Speaker();
        
        //Act
        s.FirstName = helper.ValidateFirstName("Dude");

        //Assert
        Assert.Equal(s.FirstName, "Dude");
    }
    [Fact]
    public void TestEmail()
    {
        MySpeakerHelper helper = new MySpeakerHelper();
        
        Speaker s = new Speaker();

        s.Email = helper.ValidateEmailAddress("Yolo@gmail.com");

        Assert.Equal(s.Email, "Yolo@gmail.com");

    }
    [Fact]
    public void TestSession()
    {
        MySpeakerSessionHelper helper = new MySpeakerSessionHelper();

        SpeakerSession s = new SpeakerSession();

        s.Podium = helper.ValidatePodium(true);
        
        Assert.NotEqual(s.Podium, false);
    }
    [Fact]
    public void TestSessionsTrue()
    {
        MySpeakerSessionHelper helper = new MySpeakerSessionHelper();

        SpeakerSession s = new SpeakerSession();

        s.Podium = helper.ValidatePodium(true);

        Assert.Equal(s.Podium, true);
    }



}

