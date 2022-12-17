using System;

namespace CleanCity
{
	public interface IWallet
	{
		int GetMoney { get; }
		event Action<(int nowMoney, int addMoney)> OnChangeMoney;
		void AddMoney(int money);
		void ReduceMoney(int money);
	}
}