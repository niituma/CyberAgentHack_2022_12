using System;

namespace CleanCity
{
	public interface IDamageable
	{
		/// <summary>ダメージを受ける</summary>
		void Damage(int point);

		/// <summary>ダメージを受けた時のコールバック</summary>
		event Action<int> OnDamage;
	}
}