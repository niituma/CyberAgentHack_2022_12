using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utility;

namespace CleanCity
{
  public class GoToResultOnDead : MonoBehaviour
  {
    private void Start()
    {
      Locator<IDeadable>.Resolve().OnDead += () =>
      {
        GameSystem.Singleton.Status = GameSystem.State.Result;
      };

      GameSystem.Singleton.onStatusChanged += async (before, to) =>
      {
        if (to == GameSystem.State.Result)
        {
          await SceneManager.LoadSceneAsync("ResultScene", LoadSceneMode.Additive);
          var scene = SceneManager.GetSceneByName("ResultScene");

          var main = SceneManager.GetSceneByName("MainScene");
          SceneManager.MergeScenes(scene, main);
        }
      };
    }
  }
}