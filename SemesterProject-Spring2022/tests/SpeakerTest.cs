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
        s.FirstName = helper.ValidateFirstName("dude");

        //Assert
        Assert.NotEqual(s.FirstName, "Dude");
        
            
    }
    [Fact]
    public void TestEmail()
    {
        MySpeakerHelper helper = new MySpeakerHelper();
        
        Speaker s = new Speaker();

        s.Email = helper.ValidateEmailAddrress("Yolo@gmail.com");

        Assert.Equal(s.Email, "Yolo@gmail.com");

    }

    [Fact]
    public void TestSession()
    {
        MySpeakerSessionHelper helper = new MySpeakerSessionHelper();

        SpeakerSession s = new SpeakerSession();

        s.Podium = helper.GetPodium(true);
        
        Assert.NotEqual(s.Podium, false);
    }
    [Fact]
    public void TestSessionsTrue()
    {
        MySpeakerSessionHelper helper = new MySpeakerSessionHelper();

        SpeakerSession s = new SpeakerSession();

        s.Podium = helper.GetPodium(true);

        Assert.Equal(s.Podium, true);
    }



}

