using System;

namespace CleanCity
{
    public interface IScoreManager
    {
        /// <summary>スコア取得</summary>
        int GetScore { get; }
        /// <summary>スコアが追加されたときのコールバック</summary>
        event Action<(int nowScore, int addScore)> OnAddScore;
        /// <summary>ゴミがごみ箱に捨てられた時のコールバック</summary>
        event Action OnGarbageDiscarded;
        /// <summary>スコアを追加する</summary>
        void AddScore(int score);
        /// <summary>処理したごみの数を追加</summary>
        void AddClearedGarbage();
    }
}
