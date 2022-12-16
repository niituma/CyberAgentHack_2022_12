using UnityEngine;

namespace CleanCity
{
    public interface ISetEnemyMoveDir
    {
        /// <summary>移動方向設定</summary>
        void SetMoveDistination(Vector3 position);
    }
}