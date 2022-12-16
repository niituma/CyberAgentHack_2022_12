using UnityEngine;

namespace CleanCity
{
	public class EnemyMove : MonoBehaviour, ISetEnemyMoveDir
	{
		[SerializeField] private float speed = 100;
		private Rigidbody rb;

		private void Start()
		{
			rb = GetComponent<Rigidbody>();
		}

		public void SetMoveDir(Vector3 dir)
		{
			rb.velocity = dir * speed;
		}
	}
}