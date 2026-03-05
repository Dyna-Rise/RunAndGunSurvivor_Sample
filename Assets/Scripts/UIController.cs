using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject[] lifeIcons;
    public GameObject gunIcons;
    public Sprite[] gunSprites;
    public GameObject player;

    void Start()
    {
        UpdateLife(player.GetComponent<PlayerRun>().Life());
    }

    public void UpdateLife(int life)
    {
        for(int i = 0; i < lifeIcons.Length; i++)
        {
            if (i < life) lifeIcons[i].SetActive(true);
            else lifeIcons[i].SetActive(false);
        }
    }

    public void UpdateGuns()
    {
        int gunNum = player.GetComponent<NormalShooter>().GetShootPower() - 1;
        gunIcons.GetComponent<Image>().sprite = gunSprites[gunNum];
    }

}
