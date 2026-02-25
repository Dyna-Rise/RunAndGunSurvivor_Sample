using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class NormalShooter : MonoBehaviour
{
    [Header("Bullet管理スクリプトと連携")]
    public BulletManager bulletManager;

    [Header("生成オブジェクトと位置")]
    public GameObject bulletPrefabs;//生成対象プレハブ
    public GameObject gate; //生成位置

    [Header("弾速")]
    public float shootSpeed = 10.0f; //弾速

    GameObject bullets; //生成した弾をまとめるオブジェクト
    
    //InputAction(Playerマップ)のAttackアクションがおされたら
    void OnAttack(InputValue value)
    {
        Shoot();
    }

    void Shoot()
    {
        if (bulletManager.GetBulletRemaining() > 0)
        {
            //Bulletプレハブを生成
            GameObject obj = Instantiate(
                bulletPrefabs,
                gate.transform.position,
                Quaternion.Euler(90, 0, 0)
                );

            //生成したBulletをBulletsオブジェクトにまとめる
            obj.transform.parent = bullets.transform;

            //生成したBullet自身のRigidbodyを参照
            Rigidbody bulletRbody = obj.GetComponent<Rigidbody>();
            //前方（Z軸）に飛ばす
            bulletRbody.AddForce(new Vector3(0, 0, shootSpeed), ForceMode.Impulse);

            //bulletを消費
            bulletManager.ConsumeBullet();
        }
        else //残弾がない
        {
            //マガジンを消費して弾を補充
            bulletManager.RecoverBullet();
        }
    }

    void Start()
    {
        //指定したタグを持っているオブジェクトを検索
        bullets = GameObject.FindGameObjectWithTag("Bullets"); 
    }    
}
