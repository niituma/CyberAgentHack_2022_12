namespace CleanCity
{
    public interface IPickGarbage
    {
        /// <summary>d‚³</summary>
        float Weight { get; }
        /// <summary>‚Á‚Ä‚¢‚é‚²‚İ‚Ì”</summary>
        int GarbageAmount { get; }
        /// <summary>‚Á‚Ä‚¢‚é‚²‚İ‚ğ‚·‚×‚Äíœ</summary>
        void ClearGarbage();
    }
}