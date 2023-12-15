namespace OP_sem_3_lab_5.Task6
{
    class TrimSave : ISaveText
    {
        public string SaveText(string text)
        {
            return text.Trim();
        }
    }
}
