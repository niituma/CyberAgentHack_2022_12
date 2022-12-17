using System;

namespace CleanCity
{
    public interface IScoreManager
    {
        /// <summary>スコア取得</summary>
        int GetScore { get; }
        /// <summary>スコアが追加されたときのコールバック</summary>
        event Action<(int nowScore, int addScore)> OnAddScore;
        /// <summary>スコアを追加する</summary>
        void AddScore(int score);
    }
}
