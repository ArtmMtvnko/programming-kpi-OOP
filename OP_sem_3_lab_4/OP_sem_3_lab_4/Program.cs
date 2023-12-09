using System.Text.Json;
using OP_sem_3_lab_4.Task3;

namespace OP_sem_3_lab_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPresentPack pack = new PresentPack();
            Console.WriteLine(pack.GiftSet);
            IPresentPack clone = pack.DeepClone();
            Console.WriteLine(clone.GiftSet);
        }
    }
}