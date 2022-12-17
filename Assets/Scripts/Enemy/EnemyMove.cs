using UnityEngine;

namespace CleanCity
{
	public class EnemyMove : MonoBehaviour, ISetEnemyMoveDir
	{
		[SerializeField] private float speed = 100;
		[SerializeField] private float destroyArea = 0.5f;

		private Rigidbody rb;
		private Vector3 movePosition;

		private void Start()
		{
			rb = GetComponent<Rigidbody>();
		}

		/// <summary>移動する位置を設定</summary>
		public void SetMoveDistination(Vector3 position)
		{
			movePosition = position;
		}

		private void Update()
		{
			Vector3 moveDir = (movePosition - transform.position).normalized;
			rb.velocity = moveDir * speed;
			transform.rotation = Quaternion.LookRotation(new Vector3(moveDir.x, 0, moveDir.z));
			if (Vector3.Distance(transform.position, movePosition) < destroyArea)
			{
				Destroy(gameObject);
			}
		}
	}
}