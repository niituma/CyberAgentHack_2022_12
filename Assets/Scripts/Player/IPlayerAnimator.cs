namespace CleanCity
{
    public interface IPlayerAnimator
    {
        /// <summary>�ړ��J�n�̃A�j���[�V����</summary>
        void StartMove();
        /// <summary>�ړ��I���̃A�j���[�V����</summary>
        void EndMove();
        /// <summary>�_���[�W���󂯂����̃A�j���[�V����</summary>
        void Damage();
    }
}