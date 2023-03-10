using System;

namespace CleanCity
{
    public interface IWaveSystem
    {
        int GetWave { get; }
        event Action<int> OnAddWave;
        
        bool IsBreakTime { get; }

        event Action<bool> OnBreakTimeStatusChanged;

        float GetWaveProgress();
    }
}