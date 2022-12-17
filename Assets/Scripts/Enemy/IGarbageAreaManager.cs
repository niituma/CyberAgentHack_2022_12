using UnityEngine;

namespace CleanCity
{
  public interface IGarbageAreaManager
  {
    public bool InGarbageArea(Vector3 pos);
  }
}