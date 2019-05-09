
namespace BufferMgmt.Web.Models
{
    public class MaterialDetail
    {
        public int Id { get; set; }
        public int BranchId { get; set; }
        public int CustomerId { get; set; }
        public int MaterialCodeId { get; set; }
        public int GradeId { get; set; }
        public int RefLength { get; set; }
        public decimal BufferStock { get; set; }

        public Customer Customer { get; set; }
        public Branch Branch { get; set; }
        public MaterialCode MaterialCode { get; set; }
        public Grade Grade { get; set; }
    }
}
