class Program
{
    static void Main()
    {
        Student student = new Student
        {
            Id = 101,
            Name = "Ayush Raj",
            Marks = 92
        };

        StudentRepository repo = new StudentRepository();
        repo.InsertStudent(student);
    }
}