using OP_sem_3_lab_4.Task3;

namespace OP_sem_3_lab_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PresentPack pack = new PresentPack();
            Console.WriteLine(pack.GiftSet);

            PresentPack clone = pack.DeepClone() as PresentPack;

            CandysPack gottenPack = clone.GiftSet["Candys"] as CandysPack;
            gottenPack.Eat();
            Console.WriteLine(gottenPack.CandyAmount);
        }
    }
}