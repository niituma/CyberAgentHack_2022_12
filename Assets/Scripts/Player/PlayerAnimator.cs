using UnityEngine;

namespace CleanCity
{
    public class PlayerAnimator : MonoBehaviour, IPlayerAnimator
    {
        [SerializeField] private Animator animator;

        /// <summary>�ړ��J�n�̃A�j���[�V����</summary>
        public void StartMove()
        {
            animator.SetBool("Move", true);
        }

        /// <summary>�ړ��I���̃A�j���[�V����</summary>
        public void EndMove()
        {
            animator.SetBool("Move", false);
        }

        /// <summary>�_���[�W���󂯂����̃A�j���[�V����</summary>
        public void Damage()
        {
            animator.SetTrigger("Damage");
        }
    }
}