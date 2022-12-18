using System;

namespace CleanCity
{
    public class ScoreManager : IScoreManager
    {
        private int score;

		/// <summary>スコア取得</summary>
		public int GetScore => score;

		/// <summary>スコアが追加されたときのコールバック</summary>
		public event Action<(int nowScore, int addScore)> OnAddScore;
		public event Action OnAddClearedGarbage;

		/// <summary>スコアを追加する</summary>
		public void AddScore(int score)
        {
            this.score += score;
            OnAddScore?.Invoke((this.score, score));
		}

		/// <summary>処理したごみの数を追加</summary>
		public void AddClearedGarbage()
		{
			OnAddClearedGarbage?.Invoke();
		}
	}
}