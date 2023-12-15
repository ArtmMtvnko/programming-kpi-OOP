﻿using OP_sem_3_lab_5.Task5;
using OP_sem_3_lab_5.Task6;

namespace OP_sem_3_lab_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserComponent userComponent = new UserComponent();

            userComponent.WriteText();
            userComponent.SaveType = new BaseSave();
            Console.WriteLine(userComponent.SaveText() + "\n=============\n");

            userComponent.WriteText();
            userComponent.SaveType = new TrimSave();
            Console.WriteLine(userComponent.SaveText() + "\n=============\n");

            userComponent.WriteText();
            userComponent.SaveType = new EncriptionSave();
            Console.WriteLine(userComponent.SaveText() + "\n=============\n");
        }
    }
}