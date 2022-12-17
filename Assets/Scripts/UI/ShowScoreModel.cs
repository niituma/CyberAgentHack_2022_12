using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class ShowScoreModel
{
    public int Score { get => _score.Value; set => _score.Value = value; }
    public IObservable<int> CurrentChanged => _score;
    readonly ReactiveProperty<int> _score = new();

    public void SetValue(int value)
    {
        _score.Value = value;
    }
}
