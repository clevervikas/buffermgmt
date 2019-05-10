namespace BufferMgmt.DAL.Entities
{
    public class BufferSizeVM
    {
        public int Id { get; set; }

        public int BranchId { get; set; }
        public int CustomerId { get; set; }
        public int MaterialCodeId { get; set; }
        public decimal BufferStock { get; set; }
    }
}
