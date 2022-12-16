using System;
using UnityEngine;

namespace CleanCity
{
	public class PlayerStatusManager : MonoBehaviour, IPlayerStatusManager
	{
		/// <summary>�ő�̗�</summary>
		[SerializeField] private int maxHp;
		/// <summary>�̗�</summary>
		[SerializeField] private int hp;
		/// <summary>��{���x</summary>
		[SerializeField] private int baseSpeed;

		public int MaxHp => maxHp;
		public int Hp => hp;
		public int BaseSpeed => baseSpeed;

		public event Action<int> OnDamage;
		public event Action OnDead;
	}
}