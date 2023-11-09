﻿using System;
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
        public int TasksAmount { get => tasksCount; }

        public EmptyTaskExeption(string messege, Employee employee) : base(messege)
        {
            
        }
    }
}
