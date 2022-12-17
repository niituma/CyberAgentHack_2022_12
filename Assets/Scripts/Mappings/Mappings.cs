using UnityEngine;
using Utility;

namespace CleanCity
{
    public class Mappings : MonoBehaviour
    {
        [SerializeField] private PlayerStatusManager playerStatusManager;
        [SerializeField] private GarbageDatabase garbageDatabase;
        [SerializeField] private Quota quota;
        [SerializeField] private SoundBank soundBank;
        [SerializeField] private GarbageAreaManager garbageAreaManager;

        private void Awake()
        {
            Locator<IPlayerStatusManager>.Register(playerStatusManager);
            Locator<IDamageable>.Register(playerStatusManager);
            Locator<IDeadable>.Register(playerStatusManager);
            Locator<IGarbageDatabase>.Register(garbageDatabase);
            Locator<IQuota>.Register(quota);
            Locator<IScoreManager>.Register(new ScoreManager());
            Locator<IWallet>.Register(new Wallet());
            Locator<IWaveSystem>.Register(new WaveSystem());
            Locator<SoundBank>.Register(soundBank);
            Locator<IGarbageAreaManager>.Register(garbageAreaManager);
        }
    }
}