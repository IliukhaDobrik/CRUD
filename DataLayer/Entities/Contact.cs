using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities;

public class Contact
{
    public Guid ContactId { get; set; }
    
    [Required(ErrorMessage = "Name is required.")]
    [DisplayName("Name")]
    public string Name { get; set; }
    
    [DisplayName("Mobile phone")]
    [Required(ErrorMessage = "Mobile phone is required.")]
    [StringLength(13)]
    [RegularExpression(@"^(\+375|80)(\-?|\s)(29|25|33|44)(\-?|\s)(\d{3})(\-?|\s)(\d{2})(\-?|\s)(\d{2})$", 
        ErrorMessage = "Mobile number is invalid.")]
    public string MobilePhone { get; set; }
    
    [DisplayName("Job title")]
    [Required(ErrorMessage = "Job title is required.")]
    public string JobTitle { get; set; }
    
    [DisplayName("Birth date")]
    [Required(ErrorMessage = "Birth date is required.")]
    [Range(typeof(DateTime), "1/1/1970", "1/1/2023", ErrorMessage = "Date is invalid.")]
    public DateTime BirthDate { get; set; }
}