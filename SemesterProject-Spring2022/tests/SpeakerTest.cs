#nullable disable
using Xunit;
using Xunit.Abstractions;
using LosBarriosDomain.SpeakerAggregate;
using LosBarriosDomain.SpeakerSessionAggregate;
using System;


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
    public void TestJob()
    {
        MySpeakerHelper helper = new MySpeakerHelper();

        Speaker s = new Speaker();

        s.JobTitle = helper.ValidateJobTitle("Electrical Engineer");

        Assert.Equal(s.JobTitle, "Electrical Engineer");
    }
    [Fact]
    public void TestEmployer()
    {
        MySpeakerHelper helper = new MySpeakerHelper();

        Speaker s = new Speaker();
        
        s.Employer = helper.ValidateEmployer("Xcel Energy");

        Assert.Equal(s.Employer, "Xcel Energy");
    }
    [Fact]
    public void TestAddress()
    {
        MySpeakerHelper helper = new MySpeakerHelper();

        Speaker s = new Speaker();

        s.Address = helper.ValidateAddress("1234 Street");

        Assert.Equal(s.Address, "1234 Street");

    }
    [Fact]
    public void TestCellPhone()
    {
        MySpeakerHelper helper = new MySpeakerHelper();

        Speaker s = new Speaker();

        s.CellPhone = helper.ValidateCellPhone("8061235555");

        Assert.Equal(s.CellPhone, "8061235555");
    }
    [Fact]
    public void TestBusinessPhone()
    {
        MySpeakerHelper helper = new MySpeakerHelper();

        Speaker s = new Speaker();

        s.BusinessPhone = helper.ValidateBusinessPhone("8061234444");

        Assert.Equal(s.BusinessPhone, "8061234444");
    }
    [Fact]
    public void TestLunchCount()
    {
        MySpeakerHelper helper = new MySpeakerHelper();

        Speaker s = new Speaker();

        s.LunchCount = helper.ValidateLunchCount(3);

        Assert.Equal(s.LunchCount, 3);
    }
    [Fact]
    public void TestDemonstration()
    {
        MySpeakerHelper helper = new MySpeakerHelper();

        Speaker s = new Speaker();

        s.Demonstration = helper.ValidateDemonstration("Show what an Electrical Engineer does");

        Assert.Equal(s.Demonstration, "Show what an Electrical Engineer does");
    }
    [Fact]
    public void TestTitle()
    {
        MySpeakerHelper helper = new MySpeakerHelper();

        Speaker s = new Speaker();

        s.TopicTitle = helper.ValidateTopicTitle("Engineering");

        Assert.Equal(s.TopicTitle, "Engineering");
    }
    [Fact]
    public void TestDescription()
    {
        MySpeakerHelper helper = new MySpeakerHelper();

        Speaker s = new Speaker();

        s.TopicDes = helper.ValidateTopicDes("Engineers apply mathematical and scientific information to create solutions");

        Assert.Equal(s.TopicDes, "Engineers apply mathematical and scientific information to create solutions");
    }
    [Fact]
    public void TestPodium()
    {
        MySpeakerSessionHelper helper = new MySpeakerSessionHelper();

        SpeakerSession s = new SpeakerSession();

        s.Podium = helper.GetPodium(true);
        
        Assert.Equal(s.Podium, true);
    }
    [Fact]
    public void TestOutlet()
    {
        MySpeakerSessionHelper helper = new MySpeakerSessionHelper();

        SpeakerSession s = new SpeakerSession();

        s.Outlet = helper.GetOutlet(true);

        Assert.Equal(s.Outlet, true);
    }
    [Fact]
    public void TestCleanWall()
    {
        MySpeakerSessionHelper helper = new MySpeakerSessionHelper();

        SpeakerSession s = new SpeakerSession();

        s.CleanWall = helper.GetCleanWall(false);

        Assert.Equal(s.CleanWall, false);
    }
    [Fact]
    public void TestWhiteBoard()
    {
        MySpeakerSessionHelper helper = new MySpeakerSessionHelper();

        SpeakerSession s = new SpeakerSession();

        s.WhiteBoard = helper.GetWhiteBoard(false);

        Assert.Equal(s.WhiteBoard, false);
    }
    [Fact]
    public void TestDemoTable()
    {
        MySpeakerSessionHelper helper = new MySpeakerSessionHelper();

        SpeakerSession s = new SpeakerSession();

        s.DemoTable = helper.GetDemoTable(true);

        Assert.Equal(s.DemoTable, true);
    }

    // [Fact]
    // public void CreateSpeaker()
    // {
    //     MySpeakerHelper helper = new MySpeakerHelper();

    // }

}




// }

// public  class SpeakerHelperFixture : IDisposable
// {
//     public SpeakerHelperFixture()
//     {
//     }

//     public SpeakerHelper Helper { get; set; } = new MySpeakerHelper();


//     public void Dispose(){}
// }
// public class UnitTestSpeaker : IClassFixture<MySpeakerHelper>
// {
//     private readonly SpeakerHelperFixture fixture;
//     private readonly ITestOutputHelper output;

//     public UnitTestSpeaker(ITestOutputHelper output, SpeakerHelperFixture fixture)
//     {
//         this.output;
//         this.fixture;
//     }


// }
