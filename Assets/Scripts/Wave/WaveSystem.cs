using System;
using Utility;

namespace CleanCity
{
    public class WaveSystem : IWaveSystem
    {
        private int wave = 1;

        public int GetWave => wave;

		public event Action<int> OnAddWave;

        private IScoreManager scoreManager;
        private IQuota quota;

        public WaveSystem()
        {
            scoreManager = Locator<IScoreManager>.Resolve();
            quota = Locator<IQuota>.Resolve();
            scoreManager.OnAddClearedGarbage += CheckAddWave;
        }

        private void CheckAddWave(int clearedGarbageCount)
        {
            if(clearedGarbageCount >= quota.GetNextQuota(wave))
            {
                wave++;
                OnAddWave?.Invoke(wave);
            }
        }
    }
}