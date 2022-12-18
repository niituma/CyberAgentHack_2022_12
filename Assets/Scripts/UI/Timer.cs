using CleanCity;
using CleanCity.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Utility;

public class Timer : MonoBehaviour
{
    [SerializeField]
    int _countdownMinutes = 3;
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
        _countdownSeconds = _countdownMinutes * 60;
    }

    private void Start()
    {
        Locator<IWaveSystem>.Resolve().OnAddWave += (num) =>
        {
            _countdownSeconds = _countdownMinutes * 60;
        };
        _waveSystem = Locator<IWaveSystem>.Resolve();
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
