using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject lifePanel;
    public GameObject[] lifeIcons;
    public GameObject gunIcon;
    public GameObject gunPanel;
    public Sprite[] gunSprites;
    public GameObject bulletPanel;
    public GameObject magazinePanel;
    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI bulletText;
    public TextMeshProUGUI magazineText;
    public GameObject reloadPanel;
    public GameObject gameOverPanel;
    public GameObject resultPanel;

    public GameObject player;

    Coroutine reloadEnd;

    void Start()
    {
        UpdateLife(player.GetComponent<PlayerRun>().Life());
        UpdateBullet();
        UpdateMagazine();
        UpdateScore(ScoreManager.score);
    }

    public void UpdateLife(int life)
    {
        for (int i = 0; i < lifeIcons.Length; i++)
        {
            if (i < life) lifeIcons[i].SetActive(true);
            else lifeIcons[i].SetActive(false);
        }
    }

    public void UpdateGun()
    {
        int gunNum = player.GetComponent<NormalShooter>().GetShootPower() - 1;
        if (gunNum < 0) gunNum = 0;
        gunIcon.GetComponent<Image>().sprite = gunSprites[gunNum];
    }

    public void UpdateMagazine()
    {
        magazineText.text = player.GetComponent<BulletManager>().GetMagazineRemaining().ToString();
    }


    public void UpdateBullet()
    {
        bulletText.text = player.GetComponent<BulletManager>().GetBulletRemaining().ToString();
    }

    public void UpdateScore(int value)
    {
        scoreText.text = value.ToString();
    }

    public void Reloding()
    {
        reloadEnd = StartCoroutine(ReloadEnd());
    }

    IEnumerator ReloadEnd()
    {
        yield return new WaitForSeconds(1.0f);
        reloadPanel.SetActive(false);
        reloadEnd = null;
    }

    void Update()
    {
        if (GameManager.gameState == GameState.gameover)
        {
            gunPanel.SetActive(false);
            bulletPanel.SetActive(false);
            magazinePanel.SetActive(false);
            gameOverPanel.SetActive(true);
            GameManager.gameState = GameState.retry;
        }
        else if (GameManager.gameState == GameState.stageclear)
        {
            gunPanel.SetActive(false);
            bulletPanel.SetActive(false);
            magazinePanel.SetActive(false);
            resultPanel.SetActive(true);
            GameManager.gameState = GameState.result;
        }
        else if (reloadEnd != null)
        {
            //点滅で充填中であることを表示
            float val = Mathf.Sin(Time.time * 50);
            if (val > 0) reloadPanel.SetActive(true);
            else reloadPanel.SetActive(false);
        }

    }
}
