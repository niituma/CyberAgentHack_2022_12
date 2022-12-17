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
			//�S�~�ɂԂ������Ƃ��S�~���E��
			Garbage garbage = col.gameObject.GetComponent<Garbage>();
			if (garbage != null)
			{
				PickUp(garbage);
			}

			//�S�~���ɂԂ������Ƃ��S�~���S�~���Ɏ̂Ă�
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
				//��������Ȃ�
			}
			else
			{
				Debug.Log("PickUp");
				garbagePlace.PickUp(garbage);
				garbages.Add(garbage);
				garbage.OnPickUp();
			}
		}

		public void ClearGarbage()
		{
			foreach (Garbage garbage in garbages) scoreManager.AddScore(garbage.Score);
			garbagePlace.Clear();
			garbages.Clear();
		}
	}
}