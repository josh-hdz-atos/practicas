namespace EFAndLinqPractice_SchoolAPI.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Birthday {get; set; }
        public decimal Height { get; set; }
    }
}
