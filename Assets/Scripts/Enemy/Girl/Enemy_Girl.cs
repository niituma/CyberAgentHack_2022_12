using System.Collections;
using UnityEngine;
using Utility;

namespace CleanCity
{
	public class Enemy_Girl : MonoBehaviour, ISetEnemyMoveDir
	{
		[SerializeField] float moveSpeed = 100;
		[SerializeField] float lifeTime = 10;
		private Rigidbody rb;
		private Vector3 moveDir;

		private void Start()
		{
			rb = GetComponent<Rigidbody>();
			IPlayerStatusManager playerStatus = Locator<IPlayerStatusManager>.Resolve();
			moveDir = (playerStatus.GetPosition - transform.position).normalized;
			transform.rotation = Quaternion.LookRotation(new Vector3(moveDir.x, 0, moveDir.z));

			StartCoroutine(WaitLifeTime());
		}

		public void SetMoveDistination(Vector3 position)
		{
			//プレイヤーに直進するので、移動先を設定する必要なし
		}

		private void Update()
		{
			rb.velocity = moveDir * moveSpeed;
		}

		private IEnumerator WaitLifeTime()
		{
			yield return new WaitForSeconds(lifeTime);
			Destroy(gameObject);
		}
	}
}