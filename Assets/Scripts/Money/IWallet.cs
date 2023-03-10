using System;

namespace CleanCity
{
	public interface IWallet
	{
		int GetMoney { get; }
		event Action<(int nowMoney, int addMoney)> OnChangeMoney;
		/// <summary>お金追加</summary>
		void AddMoney(int money);
		/// <summary>お金減少</summary>
		void ReduceMoney(int money);
	}
}