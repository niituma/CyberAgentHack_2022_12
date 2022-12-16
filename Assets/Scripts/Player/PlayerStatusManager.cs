using System;
using UnityEngine;

namespace CleanCity
{
	public class PlayerStatusManager : MonoBehaviour, IPlayerStatusManager
	{
		/// <summary>Å‘å‘Ì—Í</summary>
		[SerializeField] private int maxHp;
		/// <summary>‘Ì—Í</summary>
		[SerializeField] private int hp;
		/// <summary>Šî–{‘¬“x</summary>
		[SerializeField] private int baseSpeed;

		public int MaxHp => maxHp;
		public int Hp => hp;
		public int BaseSpeed => baseSpeed;

		public event Action<int> OnDamage;
		public event Action OnDead;
	}
}