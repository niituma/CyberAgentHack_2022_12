using System;
using UnityEngine;

namespace CleanCity
{
	public class PlayerStatusManager : MonoBehaviour, IPlayerStatusManager, IDeadable, IDamageable
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

		/// <summary>ダメージを受けた時のコールバック</summary>
		public event Action<int> OnDamage;
		/// <summary>死亡したときのコールバック</summary>
		public event Action OnDead;

		public void Damage(int point)
		{
			hp -= point;

			//体力が0より低くなるとき、強制的に0にする
			if (hp < 0)
			{
				hp = 0;
				point = 0;
			}

			//受けたダメージが0であれば無視する
			if (point == 0) return;

			//コールバック
			OnDamage?.Invoke(point);

			Debug.Log("ダメージ:" + point);
			//体力が0になった時、死亡
			if(hp <= 0)
			{
				Dead();
			}
		}

		public void Dead()
		{
			Debug.Log("死亡");
			//コールバック
			OnDead?.Invoke();
		}
	}
}