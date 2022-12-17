using System;

namespace CleanCity
{
	public interface IWallet
	{
		int GetMoney { get; }
		event Action<(int nowMoney, int addMoney)> OnChangeMoney;
		/// <summary>Ç®ã‡í«â¡</summary>
		void AddMoney(int money);
		/// <summary>Ç®ã‡å∏è≠</summary>
		void ReduceMoney(int money);
	}
}