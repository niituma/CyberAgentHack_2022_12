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
    // アニメーション時に使用する一時的な現在値
    int _scoreCurrentValue;
    int _countCurrentValue;
    bool _scoreAnim;
    bool _countAnim;
=======
    [SerializeField] TextMeshProUGUI _text;
    // 繧｢繝九Γ繝ｼ繧ｷ繝ｧ繝ｳ譎ゅ↓菴ｿ逕ｨ縺吶ｋ荳譎ら噪縺ｪ迴ｾ蝨ｨ蛟､
    int _tempCurrentValue;
>>>>>>> 6fa1bdfc72899dae39cf1c8efb3c1faba64c39c3
    public void SetScoreText(int value, float time)
    {
        DOTween.To(() => _scoreCurrentValue,
                value =>
                {
<<<<<<< HEAD
                    // 背景バーはアニメーションで更新
                    _scoreCurrentValue = value;
                    _scoreText.text = $"Score:{_scoreCurrentValue}";
=======
                    // 閭梧勹繝舌�ｼ縺ｯ繧｢繝九Γ繝ｼ繧ｷ繝ｧ繝ｳ縺ｧ譖ｴ譁ｰ
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
                    // 背景バーはアニメーションで更新
                    _countCurrentValue = value;
                    _countText.text = $"Score:{_countCurrentValue}";
                },
                value, time);
        if (!_countAnim) { _countText.transform.DOShakeScale(duration: time, strength: 0.3f).OnComplete(() => _countAnim = false); }

        _countAnim = true;
    }
}
