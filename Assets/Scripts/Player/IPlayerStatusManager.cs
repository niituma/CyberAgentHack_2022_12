using System;

namespace CleanCity
{
    public interface IPlayerStatusManager
    {
        /// <summary>�ő�̗�</summary>
        int MaxHp { get; }
        /// <summary>�̗�</summary>
        int Hp { get; }
        /// <summary>��{���x</summary>
        int BaseSpeed { get; }

        /// <summary>�_���[�W���󂯂����̃R�[���o�b�N</summary>
        event Action<int> OnDamage;
        /// <summary>���񂾎��̃R�[���o�b�N</summary>
        event Action OnDead;
    }
}