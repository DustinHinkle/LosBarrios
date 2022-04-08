public interface ISpeakerHelper
{
    public string GetFirstName(string fname);
    public string GetLastName(string lname);
    public string GetEmailAddrress(string email);
}

public class MySpeakerHelper : ISpeakerHelper
{
    public string GetFirstName(string fname)
    {
        // TODO: validation steps
        return fname;
    }
    public string GetLastName(string lname)
    {
        return string.Empty;
    }
    public string GetEmailAddrress(string email)
    {
        return string.Empty;
    }
}