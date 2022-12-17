using UnityEngine;

namespace CleanCity
{
  public class GarbageAreaManager : MonoBehaviour, IGarbageAreaManager
  {
    [SerializeField] public Vector3 range;
    
    public bool InGarbageArea(Vector3 pos)
    {
      var center = transform.position;
      if (center.x - range.x <= pos.x && pos.x <= center.x + range.x
          && center.z - range.z <= pos.z && pos.z <= center.z + range.z)
      {
        return true;
      }
      return false;
    }
  }
}