using UnityEngine;

namespace CleanCity
{
	public class EnemyMove : MonoBehaviour, ISetEnemyMoveDir
	{
		[SerializeField] private float speed = 100;
		
		private Rigidbody rb;
		[SerializeField] private Vector3 moveDir;

		private void Start()
		{
			rb = GetComponent<Rigidbody>();
		}

		/// <summary>移動方向設定</summary>
		public void SetMoveDir(Vector3 dir)
		{
			moveDir = dir;
		}

		private void Update()
		{
			rb.velocity = moveDir * speed;
		}
	}
}