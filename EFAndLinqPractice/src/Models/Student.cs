namespace EFAndLinqPractice_SchoolAPI.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [required]
        [Column(TypeName = "date")]
        public DateTime Birthday {get; set; }
        public decimal Height { get; set; }
    }
}
