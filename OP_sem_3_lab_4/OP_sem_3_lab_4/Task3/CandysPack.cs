using System.Text.Json;
using System.Text.Json.Serialization;

namespace OP_sem_3_lab_4.Task3
{
    class CandysPack
    {
        private int _candyAmount = 15;

        public int CandyAmount
        {
            get { return _candyAmount; }
            set { _candyAmount = value > 0 ? value : 10; }
        }

        public void Eat()
        {
            if (_candyAmount > 0)
            {
                _candyAmount--;
                Console.WriteLine("Mmmm, Yummy");
            }
            else
            {
                Console.WriteLine("Oh oh, seem like I have eatten all :(");
            }
        }
    }
}
