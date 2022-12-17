using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CleanCity
{
    public class GarbageBox : MonoBehaviour
    {
		[SerializeField] private Animator animator;
		[SerializeField] private Transform garbagePosition;
		[SerializeField] private float moveTime = 0.5f;
		[SerializeField] private int capacity = 10;

		private List<Garbage> garbagesInBox = new List<Garbage>();

		/// <summary>ゴミを全てゴミ箱へ入れる</summary>
        public void Clear(List<Garbage> garbages)
		{
			animator.Play("ThrowingGarbage");
			foreach (Garbage garbage in garbages)
			{
				garbage.transform.SetParent(null);
				garbage.transform.DOMove(garbagePosition.position, moveTime).SetEase(Ease.InBack);

				//ゴミ箱のキャパシティがいっぱいになったらゴミ箱の中のごみを1つ消す
				garbagesInBox.Add(garbage);
				if(garbagesInBox.Count > capacity)
				{
					Destroy(garbagesInBox[0].gameObject);
					garbagesInBox.RemoveAt(0);
				}
			}
		}
    }
}