namespace LoggingKata
{
    public interface ITrackable
    {
        string Name { get; set; } //property
        Point Location { get; set; }
    }
}
//interfaces specify behavior