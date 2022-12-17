namespace CleanCity
{
    public interface IGarbageDatabase 
    {
        /// <summary>ランダムなゴミを取得</summary>
        Garbage CreateRandomGarbage();
    }
}