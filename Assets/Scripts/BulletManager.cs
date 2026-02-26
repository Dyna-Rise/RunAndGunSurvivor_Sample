using System.Collections;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    //充填数の上限（定数）

    //[Header("弾数・保有マガジン数")]
    //残弾数
    //マガジン数 ※充填時に消費

    //[Header("充填時間")]
    //マガジン補充時間
    //充填までのカウントダウン

    //発生中の充填コルーチン情報の参照用

    //弾の消費
    public void ConsumeBullet()
    {
        //残弾があれば弾を消費
        
        //弾を消費
        
    }

    //残数の取得
    //public int GetBulletRemaining()
    //{
       //現状の残弾を返す
    //}


    //弾の充填
    public void AddBullet(int num)
    {
        
    }

    //充填メソッド
    public void RecoverBullet()
    {
        //充填コルーチンが作動していないとき、マガジンの残数があれば補充コルーチンを発動

    }

    //充填コルーチン
    //IEnumerator RecoverBulletCol()
    

    //画面上に簡易GUI表示
    void OnGUI()
    {
        //色を黒にする

        //残弾数を表示(左から50、上から50、幅100、高さ30)

        //マガジン数を表示(上から75)

        //充填コルーチンが走っている間のみ赤色の点滅で充填までカウントダウン(上から25)
        //if (bulletRecover != null)
    }
}
