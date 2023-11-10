namespace DataLayer.Entities;

public class Contact
{
    public Guid ContactId { get; set; }
    public string Name { get; set; }
    public string MobilePhone { get; set; }
    public string JobTitle { get; set; }
    public DateTime BirthDate { get; set; }
}