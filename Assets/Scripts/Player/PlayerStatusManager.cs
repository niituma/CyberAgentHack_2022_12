using CleanCity.UI;
using System;
using UnityEngine;
using Utility;

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
		/// <summary>所持制限</summary>
		[SerializeField] private int canHaveGarbageLimit = 10;
		
		[SerializeField] private bool isTest = false;

		public int MaxHp => maxHp;
		public int Hp => hp;
		public int BaseSpeed => baseSpeed;
		public int CanHaveGarbageLimit => canHaveGarbageLimit;
		public Vector3 GetPosition => transform.position;

		public bool IsDead { get; private set; } = false;

		/// <summary>ダメージを受けた時のコールバック</summary>
		public event Action<int> OnDamage;
		/// <summary>回復したときのコールバック</summary>
		public event Action OnHeal;
		/// <summary>死亡したときのコールバック</summary>
		public event Action OnDead;

		public void Damage(int point)
		{
			if(!isTest) if (GameSystem.Singleton.Status != GameSystem.State.InGame) return;
			if (IsDead) return;

			hp -= point;

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

		public void Heal()
		{
			if (!isTest) if (GameSystem.Singleton.Status != GameSystem.State.InGame) return;
			if (IsDead) return;
			if (hp == maxHp) return;

			hp++;
			OnHeal?.Invoke();
		}

		public void Dead()
		{
			//すでに死んでいたら無視する
			if (IsDead) return;

			Debug.Log("死亡");
			IsDead = true;
			//コールバック
			OnDead?.Invoke();
		}
	}
}