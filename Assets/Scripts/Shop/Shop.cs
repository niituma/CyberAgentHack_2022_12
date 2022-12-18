using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace CleanCity
{
	public class Shop : MonoBehaviour
	{
		[SerializeField] private Button bombButton;
		[SerializeField] private Button vacuumButton;

		[SerializeField] private TMP_Text bombCountText;
		[SerializeField] private TMP_Text vacuumCounttext;

		[SerializeField] private Animator animator;
		[SerializeField] private Animator bombButtonAnimator;
		[SerializeField] private Animator vacuumButtonAnimator;

		[SerializeField] private int bombPrice = 300;
		[SerializeField] private int vacuumPrice = 300;

		[SerializeField] private Bomb bomb;
		[SerializeField] private Vacuum vacuum;

		private int bombCount;
		private int vacuumCount;
		private IWallet wallet;

		private void Start()
		{
			wallet = Locator<IWallet>.Resolve();
			bombButton.onClick.AddListener(BuyBomb);
			vacuumButton.onClick.AddListener(BuyVacuum);

			Locator<IWaveSystem>.Resolve().OnBreakTimeStatusChanged += (b) => 
			{
				if (b)
					animator.Play("Show");
				else
					animator.Play("Hide");
			};
		}

		private void BuyBomb()
		{
			if(wallet.GetMoney >= bombPrice)
			{
				bombCount++;
				wallet.ReduceMoney(bombPrice);
				bombButtonAnimator.Play("Bought");
				bombCountText.text = bombCount.ToString();
				Locator<SoundBank>.Resolve().BoughtSE();
			}
		}

		private void BuyVacuum()
		{
			if (wallet.GetMoney >= vacuumPrice)
			{
				vacuumCount++;
				wallet.ReduceMoney(vacuumPrice);
				vacuumButtonAnimator.Play("Bought");
				vacuumCounttext.text = vacuumCount.ToString();
				Locator<SoundBank>.Resolve().BoughtSE();
			}
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.B))
			{
				if(bombCount > 0)
				{
					bombCount--;
					bomb.Use();
					bombCountText.text = bombCount.ToString();
				}
			}

			if (Input.GetKeyDown(KeyCode.V))
			{
				if (vacuumCount > 0)
				{
					vacuumCount--;
					vacuum.Use();
					vacuumCounttext.text = vacuumCount.ToString();
				}
			}
		}
	}
}