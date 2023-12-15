using System.Security.Cryptography.X509Certificates;

namespace OP_sem_3_lab_5.Task6
{
    class UserComponent
    {
        private string _text;
        private ISaveText _saveText;

        public string Text { get; }

        public ISaveText SaveType { set { _saveText = value; } }

        public void WriteText()
        {
            _text = Console.ReadLine();
        }

        public string SaveText()
        {
            return _saveText.SaveText(_text);
        }
    }

    class RunInProgram2
    {
        public static void MyMain()
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
