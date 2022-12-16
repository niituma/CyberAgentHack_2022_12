using System;
using CleanCity;
using UnityEngine;

namespace Utility
{
  public class DestroyOnStatusChange : MonoBehaviour
  {

    [SerializeField] private GameSystem.State state;
    
    private void Start()
    {
      GameSystem.Singleton.onStatusChanged += Destroy;
    }

    private void Destroy(GameSystem.State _, GameSystem.State to)
    {
      if (to == state)
      {
        Destroy(gameObject);
        GameSystem.Singleton.onStatusChanged -= Destroy;
      }
    }
  }
}