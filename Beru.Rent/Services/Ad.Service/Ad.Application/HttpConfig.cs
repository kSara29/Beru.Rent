namespace Ad.Application;

public class HttpConfig
{
    private Dictionary<string, HttpCongifOtp> Configs { get; set; }
}

public class HttpCongifOtp{
    public string Url { get; set; }
    public int Timeout { get; set; }
}