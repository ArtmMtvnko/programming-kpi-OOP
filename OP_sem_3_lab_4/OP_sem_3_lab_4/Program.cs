using OP_sem_3_lab_4.Task3;
using OP_sem_3_lab_4.Task4;

namespace OP_sem_3_lab_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CharacterFactory[] factories = new CharacterFactory[] 
            {
                new WarrionFactory(),
                new MagicianFactory(),
                new MinerFactory()
            };

            Character character;
            foreach (CharacterFactory factory in factories)
            {
                character = factory.CreateCharacter();
                character.Attack();
            }
        }
    }
}