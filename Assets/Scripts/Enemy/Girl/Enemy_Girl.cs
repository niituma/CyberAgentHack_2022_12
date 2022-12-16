using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CleanCity
{
	public class Enemy_Girl : MonoBehaviour, ISetEnemyMoveDir
	{
		public void SetMoveDistination(Vector3 position)
		{
			//プレイヤーに直進するので、設定する必要なし
		}
	}
}