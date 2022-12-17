using System;

namespace CleanCity
{
    public interface IPickGarbage
    {
        /// <summary>重さ</summary>
        float Weight { get; }
        /// <summary>持っているごみの数</summary>
        int GarbageAmount { get; }
        /// <summary>持っているごみをすべて削除</summary>
        void ClearGarbage();
        /// <summary>拾った時のコールバック</summary>
        event Action<Garbage> OnPickUpGabage;
    }
}