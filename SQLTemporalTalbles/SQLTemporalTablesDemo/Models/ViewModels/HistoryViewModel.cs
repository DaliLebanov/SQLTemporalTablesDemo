
namespace SQLTemporalTablesDemo.Managers
{
    internal class HistoryViewModel
    {
        public int ID { get; set; }
        public string ChangedBy { get; set; }
        public DateTime DateOfChangeUTC { get; set; }
    }
}