using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("追随スピード")]
    public float cameraSpeed = 2.0f;

    GameObject player; //対象Player
    Vector3 differencePos; //距離の差
    Vector3 targetPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        differencePos = player.transform.position - transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(player != null)
        {
            targetPos = player.transform.position - differencePos;
            transform.position = Vector3.Lerp(transform.position,targetPos, Time.deltaTime * cameraSpeed);
        }
    }
}
