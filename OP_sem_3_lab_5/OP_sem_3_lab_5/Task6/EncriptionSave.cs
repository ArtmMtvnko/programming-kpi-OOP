using System.Text;

namespace OP_sem_3_lab_5.Task6
{
    class EncriptionSave : ISaveText
    {
        public string SaveText(string text)
        {
            //return Convert.ToBase64String(Encoding.UTF8.GetBytes(text));
            return Math.Abs(text.GetHashCode()).ToString();
        }
    }
}
