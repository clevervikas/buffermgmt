﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BufferMgmt.DAL.Entities
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string CustomerName { get; set; }

        public ICollection<BufferSize> BufferSize { get; set; }
        public ICollection<MaterialDetail> MaterialDetail { get; set; }

    }
}
