using UnityEngine;
using Utility;

namespace CleanCity
{
    public class OnClearedGarbageToAddMoney : MonoBehaviour
	{
		[SerializeField] private int sellingPrice = 8;

		private void Start()
		{
			Locator<IScoreManager>.Resolve().OnAddClearedGarbage += (_) => Locator<IWallet>.Resolve().AddMoney(sellingPrice);
		}
	}
}