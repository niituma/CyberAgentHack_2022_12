using UnityEngine;

namespace CleanCity
{
	//ノルマ
	[CreateAssetMenu(menuName = "CleanCity/Quota", fileName = "Quota")]
	public class Quota : ScriptableObject, IQuota
	{
		[SerializeField] private int[] quota;

		public int GetNextQuoa(int nowWave)
		{
			return quota[nowWave];
		}
	}
}