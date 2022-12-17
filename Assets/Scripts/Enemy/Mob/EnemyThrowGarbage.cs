using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

namespace CleanCity
{
	public class EnemyThrowGarbage : MonoBehaviour
	{
		[SerializeField] private float throwInterval = 1.5f;

		private IGarbageDatabase garbageDatabase;

		private void Start()
		{
			garbageDatabase = Locator<IGarbageDatabase>.Resolve();
			StartCoroutine(CreateGarbage());
		}

		///<summary>ゴミをインターバル毎に生成する</summary>
		private IEnumerator CreateGarbage()
		{	
			while(true)
			{
				yield return new WaitUntil(() => GameSystem.Singleton.Status == GameSystem.State.InGame);
				yield return new WaitForSeconds(throwInterval);
				Garbage garbage = garbageDatabase.CreateRandomGarbage();

				garbage.transform.position = transform.position;
				//ランダムな向きに設定
				garbage.transform.Rotate(new Vector3(0, Random.Range(0, 360), 0));
			}
		}
	}
}