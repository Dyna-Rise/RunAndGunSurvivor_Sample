using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class NormalShooter : MonoBehaviour
{
    [Header("生成オブジェクトと位置")]
    public GameObject bulletPrefabs;//生成対象プレハブ
    public GameObject gate; //生成位置

    [Header("弾速")]
    public float shootSpeed = 10.0f; //弾速

    [Header("弾数上限")]
    public int maxRemaining = 10; //補充時の上限
    int bulletRemaining; //残弾数

    [Header("保有マガジン数")]
    public int magazine = 1; //マガジン数 ※補充時に消費

    [Header("補充時間")]
    public float recoveryTime = 3.0f;　//マガジン補充時間


    Coroutine bulletRecover;

    //InputAction(Playerマップ)のAttackアクションがおされたら
    void OnAttack(InputValue value)
    {
        Shoot();
    }

    void Shoot()
    {        
        if (bulletRemaining > 0) //残弾があれば
        {
            bulletRemaining--; //弾を消費
            //Bulletプレハブを生成
            GameObject obj = Instantiate(
                bulletPrefabs,
                gate.transform.position,
                Quaternion.Euler(90, 0, 0)
                );
            //生成したBullet自身のRigidbodyを参照
            Rigidbody bulletRbody = obj.GetComponent<Rigidbody>();
            //前方（Z軸）に飛ばす
            bulletRbody.AddForce(new Vector3(0, 0, shootSpeed), ForceMode.Impulse);
        }
        else //残弾がない時
        {
            if(bulletRecover == null) //補充コルーチンがすでに走っていれば何もしない
            {
                if(magazine > 0) //マガジンの残数があれば補充可能
                {
                    magazine--; //マガジンは消費

                    //補充コルーチンの発動(Coroutine型の変数に発動したコルーチンの情報を参照させる
                    //※Coroutine型の変数が何かを参照していれば、すでにコルーチンが走っていると見なされる（コルーチンの終わりに解放予定）
                    bulletRecover = StartCoroutine(BulletRecover());

                }
            }
        }
    }

    void Start()
    {
        bulletRemaining = maxRemaining; //スタート時の弾数を弾数上限に揃える
    }

    //補充コルーチン
    IEnumerator BulletRecover()
    {
        yield return new WaitForSeconds(recoveryTime); //ウェイト処理
        bulletRemaining = maxRemaining; //弾数補充

        //補充が終わったのでCoroutine型の変数を解放
        //※またコルーチンが発動できるようにする
        bulletRecover = null; 
    }
}
