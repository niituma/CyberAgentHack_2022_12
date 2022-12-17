using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowScoreView : MonoBehaviour
{
<<<<<<< HEAD
    [SerializeField] 
    TextMeshProUGUI _scoreText;
    [SerializeField]
    TextMeshProUGUI _countText;
    // Aj[VΙgp·ικIΘ»έl
    int _scoreCurrentValue;
    int _countCurrentValue;
    bool _scoreAnim;
    bool _countAnim;
=======
    [SerializeField] TextMeshProUGUI _text;
    // γ’γγ‘γΌγ·γ§γ³ζγ«δ½Ώη¨γγδΈζηγͺηΎε¨ε€
    int _tempCurrentValue;
>>>>>>> 6fa1bdfc72899dae39cf1c8efb3c1faba64c39c3
    public void SetScoreText(int value, float time)
    {
        DOTween.To(() => _scoreCurrentValue,
                value =>
                {
<<<<<<< HEAD
                    // wio[ΝAj[VΕXV
                    _scoreCurrentValue = value;
                    _scoreText.text = $"Score:{_scoreCurrentValue}";
=======
                    // θζ―γγΌγ―γ’γγ‘γΌγ·γ§γ³γ§ζ΄ζ°
                    _tempCurrentValue = value;
                    _text.text = $"Score:{_tempCurrentValue}";
>>>>>>> 6fa1bdfc72899dae39cf1c8efb3c1faba64c39c3
                },
                value, time);
        if (!_scoreAnim) { _scoreText.transform.DOShakeScale(duration: time, strength: 0.3f).OnComplete(() => _scoreAnim = false); }

        _scoreAnim = true;
    }

    public void SetCountText(int value, float time)
    {
        DOTween.To(() => _countCurrentValue,
                value =>
                {
                    // wio[ΝAj[VΕXV
                    _countCurrentValue = value;
                    _countText.text = $"Score:{_countCurrentValue}";
                },
                value, time);
        if (!_countAnim) { _countText.transform.DOShakeScale(duration: time, strength: 0.3f).OnComplete(() => _countAnim = false); }

        _countAnim = true;
    }
}
