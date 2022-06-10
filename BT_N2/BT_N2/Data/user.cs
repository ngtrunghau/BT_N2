using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace BT_N2.Data
{
    [Table("user")]
    public class user {         
   

        [Key]
        

        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        [Unique()]

        public string username { get; set; }
        public string password { get; set; }


    
}
}
