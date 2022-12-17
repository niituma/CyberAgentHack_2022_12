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
    /// 0Ç©Ç«Ç§Ç©ämîFÇ∑ÇÈÇΩÇﬂÇÃïœêî
    /// </summary>
    public float _countdownSeconds { get; private set; }
    [SerializeField]
    TextMeshProUGUI _timeText;

    private void Awake()
    {
        Locator<Timer>.Register(this);
        _countdownSeconds = _countdownMinutes * 60;
    }

    void Update()
    {
        if (GameSystem.Singleton.Status != GameSystem.State.InGame 
            || GameSystem.Singleton.Status == GameSystem.State.Result) { return; }

        if (_countdownSeconds <= 0) 
        { 
            FindObjectOfType<PlayerStatusManager>()?.Dead();
            return;
        }

        _countdownSeconds -= Time.deltaTime;
        var span = new TimeSpan(0, 0, (int)_countdownSeconds);
        _timeText.text = span.ToString(@"mm\:ss");
    }
}
