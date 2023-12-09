namespace OP_sem_3_lab_4.Task3
{
    interface IPresentPack
    {
        public Dictionary<string, object> GiftSet { get; }
        IPresentPack DeepClone();
    }
}
