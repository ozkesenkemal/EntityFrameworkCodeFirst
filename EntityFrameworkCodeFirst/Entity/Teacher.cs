namespace EntityFrameworkCodeFirst.Entity
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
    }
}