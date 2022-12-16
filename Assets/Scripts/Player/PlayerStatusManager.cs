using System;
using UnityEngine;

namespace CleanCity
{
	public class PlayerStatusManager : MonoBehaviour, IPlayerStatusManager
	{
		/// <summary>最大体力</summary>
		[SerializeField] private int maxHp;
		/// <summary>体力</summary>
		[SerializeField] private int hp;
		/// <summary>基本速度</summary>
		[SerializeField] private int baseSpeed;

		public int MaxHp => maxHp;
		public int Hp => hp;
		public int BaseSpeed => baseSpeed;

		public event Action<int> OnDamage;
		public event Action OnDead;
	}
}