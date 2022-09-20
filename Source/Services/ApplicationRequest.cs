namespace Source.Services;

#pragma warning disable CS8618

public class ApplicationRequest
{
    public int Id { get; set; }
    public string Code { get; set; } = Guid.NewGuid().ToString();
    public DateTime Date { get; set; } = DateTime.Now;
}