using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BufferMgmt.Web.Models
{
    public class BufferSize
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int BranchId { get; set; }
        public int CustomerId { get; set; }
        public int MaterialCodeId { get; set; }
        public decimal BufferStock { get; set; }

        public Customer Customer { get; set; }
        public Branch Branch { get; set; }
        public MaterialCode MaterialCode { get; set; }
    }
}
