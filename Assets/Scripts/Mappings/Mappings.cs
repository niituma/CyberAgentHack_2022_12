using UnityEngine;
using Utility;

namespace CleanCity
{
    public class Mappings : MonoBehaviour
    {
        [SerializeField] private PlayerStatusManager playerStatusManager;

        private void Awake()
        {
            Locator<IPlayerStatusManager>.Register(playerStatusManager);
            Locator<IDamageable>.Register(playerStatusManager);
            Locator<IDeadable>.Register(playerStatusManager);
        }
    }
}