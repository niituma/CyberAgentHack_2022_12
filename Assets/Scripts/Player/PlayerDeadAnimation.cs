using UnityEngine;

namespace CleanCity
{
    public class PlayerDeadAnimation : MonoBehaviour
    {
        private IPlayerAnimator animator;
		private IDeadable deadable;

		private void Start()
		{
			animator = GetComponent<IPlayerAnimator>();
			deadable = GetComponent<IDeadable>();
			deadable.OnDead += animator.Dead;
		}
	}
}