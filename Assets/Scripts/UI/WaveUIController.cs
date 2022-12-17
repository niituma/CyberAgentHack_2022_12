using CleanCity;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Utility;

public class WaveUIController : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI _waveText;
    CanvasGroup _canvasGroup;
    // Start is called before the first frame update
    void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 0f;

        Locator<IWaveSystem>.Resolve().OnAddWave += (num) =>
        {
            SetAnimUI(num);
        };

        if (GameSystem.Singleton)
        {
            GameSystem.Singleton.onStatusChanged += (before, to) =>
                   {
                       if (to == GameSystem.State.InGame)
                       {
                           SetAnimUI(Locator<IWaveSystem>.Resolve().GetWave);
                       }
                   };
        }
    }

    public void SetAnimUI(int num)
    {
        SetWaveUI(num);
    }

    Tween SetWaveUI(int num)
    {
        _waveText.text = $"WAVE:{num}";
        transform.localScale = Vector3.zero;
        GetComponent<CanvasGroup>().alpha = 0;
        return DOTween.Sequence().Append(transform.DOScale(1f, 1f).SetEase(Ease.InQuad))
                                 .Join(_canvasGroup.DOFade(1, 1.5f));
    }
}
