using UnityEngine;

namespace CleanCity
{
	public class EnemyCollider : MonoBehaviour, IEnemyCollider
	{
		[SerializeField] private int damagePoint = 1;
		public int DamagePoint => damagePoint;
	}
}