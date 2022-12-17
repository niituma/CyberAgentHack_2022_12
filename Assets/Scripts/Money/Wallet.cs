using System;
using UnityEngine;

namespace CleanCity
{
	public class Wallet : IWallet
	{
		[SerializeField] private int money;

		public int GetMoney => money;

		public event Action<(int nowMoney, int addMoney)> OnChangeMoney;

		public void AddMoney(int money)
		{
			this.money += money;
			OnChangeMoney?.Invoke((this.money, money));
		}

		public void ReduceMoney(int money)
		{
			this.money -= money;
			OnChangeMoney?.Invoke((this.money, money));
		}
	}
}