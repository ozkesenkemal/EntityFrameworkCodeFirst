namespace EntityFrameworkCodeFirst.Interface
{
    internal interface IAuditable
    {
        public DateTime? InsertDateTime { get; set; }
        public DateTime? UpdateDateTime { get; set; }
    }
}
