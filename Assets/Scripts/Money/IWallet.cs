using System;

namespace CleanCity
{
	public interface IWallet
	{
		int GetMoney { get; }
		event Action<(int nowMoney, int addMoney)> OnChangeMoney;
		/// <summary>�����ǉ�</summary>
		void AddMoney(int money);
		/// <summary>��������</summary>
		void ReduceMoney(int money);
	}
}