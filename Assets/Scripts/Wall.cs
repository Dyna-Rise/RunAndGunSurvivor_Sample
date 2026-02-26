using System.Collections;
using UnityEngine;

public class Wall : MonoBehaviour
{
    //[Header("生成プレハブオブジェクト")]
    //生成プレハブ

    //[Header("耐久力")]
    //耐久力

    //[Header("ダメージ時間・振動対象・振動スピード・振動量")]
    //ダメージ時間
    //振動対象オブジェクト
    //振動スピード
    //振動量

    //振動対象の初期位置
    //振動による移動座標

    //ダメージコルーチン

    void Start()
    {
        //振動対象の初期値を取得
        
    }

    void Update()
    {
        //ダメージコルーチンが発動している間
    }

    //衝突
    void OnTriggerEnter(Collider other)
    {
        //ダメージコルーチン中ならキャンセル

        //衝突相手が「Bullet」の場合ダメージコルーチンの発動

    }

    //ダメージコルーチン
    //IEnumerator DamageCol()

}
