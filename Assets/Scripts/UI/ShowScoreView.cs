using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowScoreView : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;
    // アニメーション時に使用する一時的な現在値
    int _tempCurrentValue;
    public void SetScoreText(int value, float time)
    {
        DOTween.To(() => _tempCurrentValue,
                value =>
                {
                    // 背景バーはアニメーションで更新
                    _tempCurrentValue = value;
                    _text.text = $"Score:{_tempCurrentValue}";
                },
                value, time);
        transform.DOShakeScale(duration: time, strength: 0.3f);
    }
}
