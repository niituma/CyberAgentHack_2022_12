using CleanCity;
using System;
using TMPro;
using UnityEngine;
using Utility;

public class Timer : MonoBehaviour
{
    /// <summary>
    /// 0かどうか確認するための変数
    /// </summary>
    public float _countdownSeconds { get; private set; }
    [SerializeField]
    TextMeshProUGUI _timeText;

    private IWaveSystem _waveSystem;

    private void Awake()
    {
        Locator<Timer>.Register(this);
    }

    private void Start()
    {
        _waveSystem = Locator<IWaveSystem>.Resolve();
        var quota = Locator<IQuota>.Resolve();
        
        Locator<IWaveSystem>.Resolve().OnAddWave += (num) =>
        {
            _countdownSeconds = quota.GetNextWaveTimeSec(_waveSystem.GetWave);
        };
        _countdownSeconds = quota.GetNextWaveTimeSec(1);
    }

    void Update()
    {
        if (GameSystem.Singleton.Status != GameSystem.State.InGame
            || GameSystem.Singleton.Status == GameSystem.State.Result)
        {
            return;
        }

        if (_waveSystem.IsBreakTime)
        {
            _timeText.color = Color.black;
            return;
        }

        if (_countdownSeconds <= 0) 
        { 
            FindObjectOfType<PlayerStatusManager>()?.Dead();
            return;
        }

        _countdownSeconds -= Time.deltaTime;
        var span = new TimeSpan(0, 0, (int)_countdownSeconds);
        _timeText.text = span.ToString(@"mm\:ss");

        if (_countdownSeconds <= 10)
        {
            _timeText.color = Color.red;
        }
        else
        {
            _timeText.color = Color.black;
        }
    }
}
