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
            switch (type)
            {
                case ItemType.Magazine:
                    other.gameObject.GetComponent<BulletManager>().magazine++;
                    break;
                case ItemType.ShootPower:
                    other.gameObject.GetComponent<NormalShooter>().ShootPowerUp();
                    break;
                case ItemType.LifeUp:
                    other.gameObject.GetComponent<PlayerRun>().LifeUP();
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