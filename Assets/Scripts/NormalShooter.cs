using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class NormalShooter : MonoBehaviour
{
    //[Header("Bullet管理スクリプトと連携")]

    //[Header("生成オブジェクトと位置")]
    //生成対象プレハブ
    //生成位置となるオブジェクト

    //[Header("弾速")]

    //生成した弾をまとめるオブジェクト
    
    //InputAction(Playerマップ)のAttackアクションがおされたら
    void OnAttack(InputValue value)
    {
        //Shoot();
    }

    void Shoot()
    {
        //残弾があればBulletを生成してZ軸前方に飛ばす
        //残弾がなければマガジンを消費して充填補充
    }

    void Start()
    {
        //Bulletsタグを持っているオブジェクトを検索
    }    
}
