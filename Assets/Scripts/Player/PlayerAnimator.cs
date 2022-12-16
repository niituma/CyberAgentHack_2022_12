using UnityEngine;

namespace CleanCity
{
    public class PlayerAnimator : MonoBehaviour, IPlayerAnimator
    {
        [SerializeField] private Animator animator;

        /// <summary>移動開始のアニメーション</summary>
        public void StartMove()
        {
            animator.SetBool("Move", true);
        }

        /// <summary>移動終了のアニメーション</summary>
        public void EndMove()
        {
            animator.SetBool("Move", false);
        }

        /// <summary>ダメージを受けた時のアニメーション</summary>
        public void Damage()
        {
            animator.SetTrigger("Damage");
        }
    }
}