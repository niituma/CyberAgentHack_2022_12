using System.Collections;
using UnityEngine;

namespace CleanCity
{
    public class PlayerHitEnemy : MonoBehaviour
    {
		[SerializeField] private float coolTime = 0.75f;

		private IDamageable damageable;
		private IPlayerAnimator playerAnimator;

		private bool nowWaitCoolTime = false;

		private void Start()
		{
			damageable = GetComponent<IDamageable>();
			playerAnimator = GetComponent<IPlayerAnimator>();
		}

		private void OnCollisionEnter(Collision col)
		{
			//クールタイム待機中であればダメージを受けない
			if (nowWaitCoolTime) return;

			//コライダーに触れた時、敵のコライダーであればダメージを受ける
			IEnemyCollider enemyCollider = col.gameObject.GetComponent<IEnemyCollider>();
			if (enemyCollider != null)
			{
				damageable.Damage(enemyCollider.DamagePoint);
				playerAnimator.Damage();
				StartCoroutine(DamageCoolTime());
			}
		}

		//攻撃を受けた後の無敵時間を待機
		private IEnumerator DamageCoolTime()
		{
			nowWaitCoolTime = true;
			yield return new WaitForSeconds(coolTime);
			nowWaitCoolTime = false;
		}
	}
}