using System;

namespace CleanCity
{
    public interface IDeadable 
    {
        /// <summary>死んでいるか</summary>
        bool IsDead { get; }
        /// <summary>死亡</summary>
        void Dead();
        /// <summary>死んだ時のコールバック</summary>
        event Action OnDead;
    }
}