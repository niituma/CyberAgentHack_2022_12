using CleanCity;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveUIController : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI _waveText;
    // Start is called before the first frame update
    void Start()
    {
        GameSystem.Singleton.onStatusChanged += (before, to) =>
        {
            if (to == GameSystem.State.InGame)
            {
                SetAnimUI(1);
            }
        };
    }

    public void SetAnimUI(int num)
    {
        SetWaveUI(num);
    }

    Tween SetWaveUI(int num)
    {
        _waveText.text = $"WAVE : {num}";
        transform.localScale = Vector3.zero;
        GetComponent<CanvasGroup>().alpha = 0;
        return DOTween.Sequence().Append(transform.DOScale(1f, 1f).SetEase(Ease.InQuad))
                                 .Join(GetComponent<CanvasGroup>().DOFade(1, 1.5f))
                                 .AppendInterval(1.5f)
                                 .Join(GetComponent<CanvasGroup>().DOFade(0, 1.5f));
    }
}
