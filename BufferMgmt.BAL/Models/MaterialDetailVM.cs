
namespace BufferMgmt.DAL.Entities
{
    public class MaterialDetailVM
    {
        public int Id { get; set; }
        public int BranchId { get; set; }
        public int CustomerId { get; set; }
        public int MaterialCodeId { get; set; }
        public int GradeId { get; set; }
        public int RefLength { get; set; }
        public decimal BufferStock { get; set; }
    }
}
