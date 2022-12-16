using UnityEngine;

namespace CleanCity
{
  [DefaultExecutionOrder(-100000000)]
  public class GameSystem : MonoBehaviour
  {

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
      Result
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
    }

    private void Start()
    {
      Status = State.Menu;
    }
  }
}