using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BufferMgmt.Web.Models
{
    public class Branch
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string BranchName { get; set; }

        public ICollection<BufferSize> BufferSize { get; set; }
        public ICollection<MaterialDetail> MaterialDetail { get; set; }

    }
}
