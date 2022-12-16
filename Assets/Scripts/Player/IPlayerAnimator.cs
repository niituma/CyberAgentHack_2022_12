namespace CleanCity
{
    public interface IPlayerAnimator
    {
        /// <summary>移動開始のアニメーション</summary>
        void StartMove();
        /// <summary>移動終了のアニメーション</summary>
        void EndMove();
        /// <summary>ダメージを受けた時のアニメーション</summary>
        void Damage();
    }
}