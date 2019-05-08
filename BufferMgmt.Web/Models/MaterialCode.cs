using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BufferMgmt.Web.Models
{
    public class MaterialCode
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string MaterialCodeName { get; set; }

        public ICollection<BufferSize> BufferSize { get; set; }
        public ICollection<MaterialDetail> MaterialDetail { get; set; }

    }
}
