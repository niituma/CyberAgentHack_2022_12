using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utility;

namespace CleanCity
{
	public class PlayerPickUpGarbage : MonoBehaviour, IPickGarbage
	{
		[SerializeField] private GarbagePlace garbagePlace;

		public float Weight => (int)garbages.Sum(x => x.Weight);
		public int GarbageAmount => garbages.Count;

		private List<Garbage> garbages = new List<Garbage>();
		private IPlayerStatusManager playerStatus;
		private IScoreManager scoreManager;

		private void Start()
		{
			playerStatus = Locator<IPlayerStatusManager>.Resolve();
			scoreManager = Locator<IScoreManager>.Resolve();
		}

		private void OnTriggerEnter(Collider col)
		{
			//ゴミにぶつかったときゴミを拾う
			Garbage garbage = col.gameObject.GetComponent<Garbage>();
			if (garbage != null)
			{
				PickUp(garbage);
			}

			//ゴミ箱にぶつかったときゴミをゴミ箱に捨てる
			GarbageBox garbageBox = col.gameObject.GetComponent<GarbageBox>();
			if(garbageBox != null)
			{
				garbageBox.Clear(garbages);
				ClearGarbage();
			}
		}

		public void PickUp(Garbage garbage)
		{
			if (garbage.IsPickedUp) return;

			if (playerStatus.CanHaveGarbageLimit <= garbages.Count)
			{
				//持ちきれない
			}
			else
			{
				Debug.Log("PickUp");
				garbagePlace.PickUp(garbage);
				garbages.Add(garbage);
				garbage.OnPickUp();
				Locator<SoundBank>.Resolve().TrashPickUP();
			}
		}

		public void ClearGarbage()
		{
			foreach (Garbage garbage in garbages)
			{
				scoreManager.AddClearedGarbage();
				scoreManager.AddScore(garbage.Score);
			}
			garbagePlace.Clear();
			garbages.Clear();
			Locator<SoundBank>.Resolve().TrashDiscard();
		}
	}
}