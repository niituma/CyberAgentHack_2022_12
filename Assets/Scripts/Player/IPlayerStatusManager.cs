using System;

namespace CleanCity
{
    public interface IPlayerStatusManager
    {
        /// <summary>最大体力</summary>
        int MaxHp { get; }
        /// <summary>体力</summary>
        int Hp { get; }
        /// <summary>基本速度</summary>
        int BaseSpeed { get; }

        /// <summary>ダメージを受けた時のコールバック</summary>
        event Action<int> OnDamage;
        /// <summary>死んだ時のコールバック</summary>
        event Action OnDead;
    }
}