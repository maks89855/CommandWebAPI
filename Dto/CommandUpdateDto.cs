using System.ComponentModel.DataAnnotations;

namespace CommandWebAPI.Dto
{
    public class CommandUpdateDto
    {
        [Required]
        public string HowTo { get; set; }
        [Required]
        public string Line { get; set; }
        [Required]
        public string Platform { get; set; }
    }
}
