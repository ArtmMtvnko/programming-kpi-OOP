using System;

namespace OP_sem_3_lab_3
{
    class RunScript
    {
        public static void MyMain()
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
    abstract class Person
    {
        protected string post;
        protected int payment;

        public Person(string post) => this.post = post;

        public abstract void Add(Person person);

        public abstract void Remove(Person person);

        public abstract int CollectPayment();

        public abstract void Display(int indent);
    }

    class Employee : Person
    {
        public Employee(string post) : base(post)
        {
            this.post = post;
            this.payment = new Random().Next(500);
        }

        public override void Add(Person person)
        {
            throw new NotImplementedException();
        }

        public override void Remove(Person person)
        {
            throw new NotImplementedException();
        }

        public override int CollectPayment()
        {
            return payment;
        }

        public override void Display(int indent)
        {
            Console.WriteLine($"{new String('-', indent)}{post}: {payment}");
        }
    }

    class Composite : Person
    {
        private List<Person> _employees = new List<Person>();

        public Composite(string name) : base(name)
        {
            this.payment = 0;
        }

        public override void Add(Person person)
        {
            _employees.Add(person);
        }

        public override void Remove(Person person)
        {
            _employees.Remove(person);
        }

        public override int CollectPayment()
        {
            payment = 0;
            foreach (Person person in _employees)
            {
                payment += person.CollectPayment();
            }
            return payment;
        }

        public override void Display(int indent)
        {
            Console.WriteLine($"{new String('-', indent)}{post}: {payment}");

            foreach (Person person in _employees)
            {
                person.Display(indent + 2);
            }
        }
    }
}
