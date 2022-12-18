using System.Collections.ObjectModel;

namespace CleanCity
{
    public interface IGarbageDatabase 
    {
        /// <summary>ランダムなゴミを取得</summary>
        Garbage CreateRandomGarbage();
        /// <summary>生成されたごみをすべて取得</summary>
        ReadOnlyCollection<Garbage> GetGarbageInstances();
    }
}