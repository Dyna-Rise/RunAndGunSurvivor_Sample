using UnityEngine;

public enum ItemType
{
    Magazine,
    ShootPower,
    LifeUp
}

public class Item : MonoBehaviour
{
    public ItemType type;
    public GameObject effectPrefab;
    public float deleteTime = 15.0f;    

    void Start()
    {
        Destroy(gameObject, deleteTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject canvas = GameObject.FindGameObjectWithTag("UI");
            switch (type)
            {
                case ItemType.Magazine:
                    other.gameObject.GetComponent<BulletManager>().magazine++;
                    break;
                case ItemType.ShootPower:
                    other.gameObject.GetComponent<NormalShooter>().ShootPowerUp();
                    canvas.GetComponent<UIController>().UpdateGuns();
                    break;
                case ItemType.LifeUp:
                    PlayerRun playerRun = other.gameObject.GetComponent<PlayerRun>();
                    playerRun.LifeUP();
                    canvas.GetComponent<UIController>().UpdateLife(playerRun.Life());
                    break;
            }

            EffectCreate();
        }
    }

    void EffectCreate()
    {
        Instantiate(
            effectPrefab,
            transform.position,
            Quaternion.identity
            );
        Destroy(gameObject);
    }
}