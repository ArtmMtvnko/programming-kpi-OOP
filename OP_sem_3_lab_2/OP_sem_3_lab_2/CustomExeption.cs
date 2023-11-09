using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP_sem_3_lab_2
{
    internal class ZooOverflowExeption : Exception
    {
        private int capacity;
        private int animalsAmount;

        public int Capacity { get => capacity; }
        public int AnimalsAmount { get => animalsAmount; }

        public ZooOverflowExeption(string messege, Zoo zoo) : base(messege)
        {
            capacity = zoo.Capacity;
            animalsAmount = zoo.AnimalsAmount;
        }
    }

    class EmptyTaskExeption : Exception
    {
        private int tasksCount;
        public int TasksCount { get => tasksCount; }

        public EmptyTaskExeption(string messege, Employee employee) : base(messege)
        {
            tasksCount = employee.ToDoCount;
        }
    }

    class NegativeTimeExeption : Exception
    {
        public TimeExeptionArgs TimeExeptionArgs { get; }
        public NegativeTimeExeption(string messege, TimeExeptionArgs timeExeptionArgs) : base(messege)
        {
            TimeExeptionArgs = timeExeptionArgs;
        }
    }

    class TimeExeptionArgs
    {
        public TimeSpan Current { get; }
        public TimeSpan EndOfShift { get; }
        public TimeExeptionArgs(TimeSpan endOfShift)
        {
            Current = DateTime.Now.TimeOfDay;
            EndOfShift = endOfShift;
        }

        public TimeExeptionArgs(TimeSpan endOfShift, TimeSpan current)
        {
            Current = current;
            EndOfShift = endOfShift;
        }
    }
}
