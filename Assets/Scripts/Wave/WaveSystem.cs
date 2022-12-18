using System;
using Cysharp.Threading.Tasks;
using Utility;

namespace CleanCity
{
    public class WaveSystem : IWaveSystem
    {
        private int wave = 1;

        public int GetWave => wave;

		public event Action<int> OnAddWave;

        private bool _isBreakTime = false;
        public bool IsBreakTime 
        {
            get => _isBreakTime;
            private set
            {
                if (_isBreakTime == value)
                {
                    return;
                }
                _isBreakTime = value;
                OnBreakTimeStatusChanged?.Invoke(value);
            }
        }
        
        public event Action<bool> OnBreakTimeStatusChanged;

        private IScoreManager scoreManager;
        private IQuota quota;

        private int garbageCount = 0;//フェーズ終了時のゴミの数

        private const int BreakTimeMillisecond = 15 * 1000;

        public WaveSystem()
        {
            scoreManager = Locator<IScoreManager>.Resolve();
            quota = Locator<IQuota>.Resolve();
            scoreManager.OnGarbageDiscarded += CheckAddWave;
        }

        private async void CheckAddWave()
        {
            if (IsBreakTime)
            {
                return;
            }
            
            garbageCount++;

            if(garbageCount >= quota.GetNextQuota(wave))
            {
                garbageCount = 0;
                wave++;
                
                IsBreakTime = true;
                await UniTask.Delay(BreakTimeMillisecond);
                IsBreakTime = false;

                OnAddWave?.Invoke(wave);

                UnityEngine.Debug.Log("Wave:" + wave);
            }
        }

        /// <summary>
        /// 進捗を取得する
        /// </summary>
        /// <returns></returns>
        public float GetWaveProgress()
        {
            return garbageCount / (float)quota.GetNextQuota(wave);
        }
    }
}