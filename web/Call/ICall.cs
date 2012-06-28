namespace web.Call
{
    public interface ICall
    {
        CallResponse Execute();
        string Url { get; }
    }
}