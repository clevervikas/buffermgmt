using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BufferMgmt.DAL.Entities
{
    public class Grade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string GradeName { get; set; }

        public ICollection<MaterialDetail> MaterialDetail { get; set; }
    }
}
