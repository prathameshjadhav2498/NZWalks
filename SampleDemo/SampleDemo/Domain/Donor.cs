using System.ComponentModel.DataAnnotations;

namespace SampleDemo.Domain
{
    public class Donar
    {
        [Key]
        public Guid Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is Mandatory")]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public string Name { get; set; }

    }
}
