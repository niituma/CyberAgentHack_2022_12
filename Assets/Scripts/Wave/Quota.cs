using UnityEngine;

namespace CleanCity
{
	//ノルマ
	[CreateAssetMenu(menuName = "CleanCity/Quota", fileName = "Quota")]
	public class Quota : ScriptableObject, IQuota
	{
		[SerializeField] private int[] quota;
		[SerializeField] private float[] enemySpawnTimeSpan;
		[SerializeField] private int[] enemyMaxCount;
		[SerializeField] private int[] waveTimes;

		public int GetNextQuota(int nowWave)
		{
			return quota[nowWave];
		}

		public float GetNextSpawnTimeSpan(int waveNow)
		{
			return enemySpawnTimeSpan[waveNow];
		}
		
		public int GetNextMaxSpawnCount(int waveNow)
		{
			return enemyMaxCount[waveNow];
		}

		public int GetNextWaveTimeSec(int waveNow)
		{
			return waveTimes[waveNow];
		}
	}
}