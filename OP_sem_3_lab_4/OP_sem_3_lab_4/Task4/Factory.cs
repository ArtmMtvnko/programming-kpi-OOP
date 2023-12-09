namespace OP_sem_3_lab_4.Task4
{
    abstract class CharacterFactory
    {
        public abstract Character CreateCharacter(); // Our factory method
    }

    class WarrionFactory : CharacterFactory
    {
        public override Character CreateCharacter()
        {
            return new Warrior();
        }
    }

    class MagicianFactory : CharacterFactory
    {
        public override Character CreateCharacter()
        {
            return new Magician();
        }
    }

    class MinerFactory : CharacterFactory
    {
        public override Character CreateCharacter()
        {
            return new Miner();
        }
    }

    class RunInProgram
    {
        public static void MyMain()
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
