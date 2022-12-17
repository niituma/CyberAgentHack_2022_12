namespace CleanCity
{
	public interface IQuota
	{
		int GetNextQuota(int nowWave);

		float GetNextSpawnTimeSpan(int waveNow);

		int GetNextMaxSpawnCount(int waveNow);
	}
}