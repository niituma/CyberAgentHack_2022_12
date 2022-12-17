using System;

namespace CleanCity
{
	public interface IDamageable
	{
		/// <summary>ダメージを受ける</summary>
		void Damage(int point);
		/// <summary>回復する</summary>
		void Heal();

		/// <summary>ダメージを受けた時のコールバック</summary>
		event Action<int> OnDamage;
		/// <summary>回復した時のコールバック</summary>
		event Action OnHeal;
	}
}