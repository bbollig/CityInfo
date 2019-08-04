using System.ComponentModel.DataAnnotations;

namespace CityInfo.API.Models
{
    public class PointofInterestForCreationDto
    {
        [Required(ErrorMessage = "You need to provide a name value.")]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }
    }
}
