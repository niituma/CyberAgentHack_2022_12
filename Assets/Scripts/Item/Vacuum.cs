using DG.Tweening;
using UnityEngine;
using Utility;

namespace CleanCity
{
    public class Vacuum : MonoBehaviour
    {
        [SerializeField] private TrailRenderer garbageTrail;
        [SerializeField] private float vacuumTime = 0.5f;
        
        public void Use()
        {
            IGarbageDatabase garbageDatabase = Locator<IGarbageDatabase>.Resolve();
            IPlayerStatusManager playerStatusManager = Locator<IPlayerStatusManager>.Resolve();
            foreach(Garbage garbage in garbageDatabase.GetGarbageInstances())
            {
                if (garbage.IsPickedUp) continue;
                TrailRenderer trail = Instantiate(garbageTrail, garbage.transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity, garbage.transform);
                Tween moveTween = garbage.transform.DOMove(playerStatusManager.GetPosition, vacuumTime);
                moveTween.onUpdate += () => 
                {
                    if (garbage.IsPickedUp) 
                    {
                        moveTween.Kill(); 
                    }
                };
                moveTween.onKill += () =>
                {
                    Destroy(trail.gameObject);
                };
            }
            Locator<SoundBank>.Resolve().VacuumSE();
        }
	}
}