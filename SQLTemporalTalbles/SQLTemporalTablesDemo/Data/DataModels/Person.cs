namespace SQLTemporalTablesDemo.Data.DataModels
{
    public class Person : BaseModifiableDeletableModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Note { get; set; }
    }
}
