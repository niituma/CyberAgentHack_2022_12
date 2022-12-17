using UnityEngine;
using Utility;

namespace CleanCity
{
    public class Mappings : MonoBehaviour
    {
        [SerializeField] private PlayerStatusManager playerStatusManager;
        [SerializeField] private GarbageDatabase garbageDatabase;
        [SerializeField] private SoundBank soundBank;

        private void Awake()
        {
            Locator<IPlayerStatusManager>.Register(playerStatusManager);
            Locator<IDamageable>.Register(playerStatusManager);
            Locator<IDeadable>.Register(playerStatusManager);
            Locator<IGarbageDatabase>.Register(garbageDatabase);
            Locator<IScoreManager>.Register(new ScoreManager());
            Locator<SoundBank>.Register(soundBank);
        }
    }
}