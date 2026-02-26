using UnityEngine;

public class CameraController : MonoBehaviour
{
    //[Header("追随スピード")]

    //対象Player
    //元々のカメラとPlayerの距離の差
    //その1フレームにおける目的座標

    void Start()
    {
        //プレイヤーの検索

        //最初の距離の差を記録
    }

    void LateUpdate()
    {
        //プレイヤーがいればフレームごとに目的座標を計算、Vector3.Lerpメソッドで距離を補完する
    }
}
