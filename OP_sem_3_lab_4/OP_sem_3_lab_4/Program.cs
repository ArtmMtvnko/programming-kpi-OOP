﻿using System.Text.Json;
using OP_sem_3_lab_4.Task3;

namespace OP_sem_3_lab_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PresentPack pack = new PresentPack();
            PresentPack clone = pack.DeepClone();
        }
    }
}