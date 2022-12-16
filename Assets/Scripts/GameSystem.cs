using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CleanCity
{
  [DefaultExecutionOrder(-100000000)]
  public class GameSystem : MonoBehaviour
  {
    
    private const string MainSceneName = "MainScene";
    private const string TitleSceneName = "TitleScene";
    private const string GameSceneName = "GameScene";

    public static GameSystem Singleton
    {
      get;
      private set;
    }
    
    public enum State
    {
      Init,
      Menu,
      InGame,
      Result,
      BeforeReload
    }

    private State _state = State.Init;
    
    /// <summary>
    /// ゲームの状態
    /// 値を変更するとonStatusChangedを呼ぶ
    /// </summary>
    public State Status
    {
      get => _state;
      set
      {
        if (_state == value)
        {
          return;
        }
        var before = _state;
        _state = value;
        onStatusChanged?.Invoke(before, value);
      }
    }
    
    public delegate void StatusChangeListener(State before, State changedTo);

    /// <summary>
    /// ゲームの状態が変わったときに呼ばれる関数
    /// </summary>
    public StatusChangeListener onStatusChanged;
    
    private void Awake()
    {
      if (Singleton != null)
      {
        Destroy(Singleton.gameObject);
      }
      Singleton = this;

      InitializeScene();
    }

    private void Start()
    {
      Status = State.Menu;
    }

    /// <summary>
    /// MainSceneにTitleとGameを合成する
    /// </summary>
    private async void InitializeScene()
    {
      var mainScene = SceneManager.GetSceneByName(MainSceneName);
      
      // load title scene
      await SceneManager.LoadSceneAsync(TitleSceneName, LoadSceneMode.Additive);
      var titleScene = SceneManager.GetSceneByName(TitleSceneName);
      
      // load game scene
      await SceneManager.LoadSceneAsync(GameSceneName, LoadSceneMode.Additive);
      var gameScene = SceneManager.GetSceneByName(GameSceneName);
      
      // merge scenes
      SceneManager.MergeScenes(titleScene, mainScene);
      SceneManager.MergeScenes(gameScene, mainScene);
    }

    /// <summary>
    /// ゲームを再読み読みする
    /// </summary>
    public static void RestartGame()
    {
      Singleton.Status = State.BeforeReload;
      SceneManager.LoadScene(MainSceneName);
    }
    
  }
}