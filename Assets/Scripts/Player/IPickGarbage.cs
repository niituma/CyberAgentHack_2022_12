namespace CleanCity
{
    public interface IPickGarbage
    {
        /// <summary>�d��</summary>
        float Weight { get; }
        /// <summary>�����Ă��邲�݂̐�</summary>
        int GarbageAmount { get; }
        /// <summary>�����Ă��邲�݂����ׂč폜</summary>
        void ClearGarbage();
    }
}