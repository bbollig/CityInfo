using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Entities
{
    public class PointOfInterest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        //Leaving out the ForeignKey decoration would demonstrate convention-based approach to 
        //relationship discovery. The EFCore Framework will find this and realize the connection 
        //between the City entity and the PointOfInterest entity and will automatically map the 
        //foreign key relationship to the ID property. But we can explicitly define this relationship 
        //using the attribute as well. 
        [ForeignKey("CityId")]
        public City City { get; set; }
        public int CityId { get; set; }

    }
}
