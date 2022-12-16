using UnityEngine;

namespace CleanCity
{
    public class PlayerAnimator : MonoBehaviour, IPlayerAnimator
    {
        [SerializeField] private Animator animator;

        public void StartMove()
        {
            animator.SetBool("Move", true);
        }

        public void EndMove()
        {
            animator.SetBool("Move", false);
        }

        public void Damage()
        {
            animator.SetTrigger("Damage");
        }
    }
}