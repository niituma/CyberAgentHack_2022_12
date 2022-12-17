using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CleanCity
{
    //SEを再生する関数を書くclass
    public class SoundBank : MonoBehaviour
    {
        // 音データの再生装置を格納する
        private new AudioSource audio;

        // 音データを格納する
  //      [SerializeField] private AudioClip step;      //足音
        [SerializeField] private AudioClip button;      //ボタン
        [SerializeField] private AudioClip pickup;      //拾う
        [SerializeField] private AudioClip discard;     //捨てる
        [SerializeField] private AudioClip conflict;    //衝突
        [SerializeField] private AudioClip result;      //リザルト


        private void Start()
        {
            // コンポーネントから再生装置を検出する
            audio = gameObject.AddComponent<AudioSource>();
        }

        //// 足音のSE
        //public void StepSE()
        //{
        //    //音を鳴らす
        //    audio.PlayOneShot(step);
        //}

        // ボタンを押したときに再生するSE
        public void IsInPutButton()
        {
            //音を鳴らす
            audio.PlayOneShot(button);
        }

        // ゴミを拾った時に再生するSE
        public void TrashPickUP()
        {
            //音を鳴らす
            audio.PlayOneShot(pickup);
        }

        // ゴミを捨てた時に再生するSE
        public void TrashDiscard()
        {
            //音を鳴らす
            audio.PlayOneShot(discard);
        }

        // プレイヤーが衝突した時に再生するSE
        public void IsPlayerConflict()
        {
            //音を鳴らす
            audio.PlayOneShot(conflict);
        }

        // リザルトの時につかうSE（使わない可能性もある）
        public void ResultSE()
        {
            //音を鳴らす
            audio.PlayOneShot(result);
        }
    }
}