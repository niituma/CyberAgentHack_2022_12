using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class ShowScoreModel
{
    public int Score { get => _score.Value; set => _score.Value = value; }
    public IObservable<int> CurrentScoreChanged => _score;
    readonly ReactiveProperty<int> _score = new();

    public int Count { get => _count.Value; set => _count.Value = value; }
    public IObservable<int> CurrentCountChanged => _count;
    readonly ReactiveProperty<int> _count = new();

    public void SetScoreValue(int value)
    {
        _score.Value = value;
    }

    public void SetCountValue(int value)
    {
        _count.Value = value;
    }
}
