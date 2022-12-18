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
    RectTransform rectTransform;

    Tween BreakTimeAnim;
    // Start is called before the first frame update
    void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();
        _canvasGroup.alpha = 0f;

        Locator<IWaveSystem>.Resolve().OnAddWave += (num) =>
        {
            SetAnimUI(num);
        };

        Locator<IWaveSystem>.Resolve().OnBreakTimeStatusChanged += (active) =>
        {
            if (active)
            {
                SetBreakTimeUI();
            }
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
        if (BreakTimeAnim != null) { BreakTimeAnim.Kill(); }
        _waveText.text = $"WAVE:{num}";
        transform.localScale = Vector3.zero;
        GetComponent<CanvasGroup>().alpha = 0;
        return DOTween.Sequence().Append(transform.DOScale(1f, 1f).SetEase(Ease.InQuad))
                                 .Join(_canvasGroup.DOFade(1, 1.5f));
    }

    void SetBreakTimeUI()
    {
        _waveText.text = $"BREAK TIME";
        transform.localScale = Vector3.one;
        GetComponent<CanvasGroup>().alpha = 1;
        BreakTimeAnim = DOTween.Sequence()
                          .Append(rectTransform.DOLocalMoveY(10f, 0.5f)
                          .SetRelative(true)
                          .SetEase(Ease.OutQuad))
                          .Join(DOTween.To(() => GetComponent<CanvasGroup>().alpha, a => GetComponent<CanvasGroup>().alpha = a, 0, 0.5f))
                          .SetLoops(-1, LoopType.Yoyo);
    }
}
