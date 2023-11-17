namespace OP_sem_3_lab_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person director = new Composite("Director");

            Person headTeacherJunior = new Composite("Junior headTeacher");
            Person headTeacherMiddle = new Composite("Middle headTeacher");
            Person headTeacherSenior = new Composite("Senior headTeacher");

            director.Add(headTeacherJunior);
            director.Add(headTeacherMiddle);
            director.Add(headTeacherSenior);

            Person teacher1 = new Employee("Teacher 1");
            Person teacher2 = new Employee("Teacher 2");
            Person teacher3 = new Employee("Teacher 3");
            Person teacher4 = new Employee("Teacher 4");
            Person teacher5 = new Employee("Teacher 5");
            Person teacher6 = new Employee("Teacher 6");

            headTeacherJunior.Add(teacher1);
            headTeacherJunior.Add(teacher6);

            headTeacherMiddle.Add(teacher2);
            headTeacherMiddle.Add(teacher5);

            headTeacherSenior.Add(teacher3);
            headTeacherSenior.Add(teacher4);

            director.CollectPayment();
            director.Display(2);
        }
    }
}