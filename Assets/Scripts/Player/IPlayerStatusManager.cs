using System;
using UnityEngine;

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
        /// <summary>プレイヤーの位置</summary>
        Vector3 GetPosition { get; }
    }
}