using System;
using UnityEngine;

namespace CleanCity
{
	public class PlayerStatusManager : MonoBehaviour, IPlayerStatusManager
	{
		[SerializeField] private int maxHp;
		[SerializeField] private int hp;
		[SerializeField] private int baseSpeed;

		public int MaxHp => maxHp;
		public int Hp => hp;
		public int BaseSpeed => baseSpeed;

		public event Action<int> OnDamage;
		public event Action OnDead;
	}
}