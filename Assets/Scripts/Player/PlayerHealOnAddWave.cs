using UnityEngine;
using Utility;

namespace CleanCity
{
    public class PlayerHealOnAddWave : MonoBehaviour
    {
		private void Start()
		{
			Locator<IWaveSystem>.Resolve().OnAddWave += (_) => Locator<IDamageable>.Resolve().Heal();
		}
	}
}