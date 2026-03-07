using System.Collections;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    const int MinLane = -2;
    const int MaxLane = 2;
    const float LaneWidth = 1.0f;

    public int goalPosition;

    public GameObject[] enemyObjects;
    public GameObject[] itemObjects;
    public GameObject[] trapObjects;
    public BulletManager bulletManager;
    public GameObject goalPrefab;

    bool createGoal;

    public float maxEnemyIntervalTime = 5.0f;
    public float maxItemIntervalTime = 10.0f;
    public float maxTrapIntervalTime = 10.0f;

    Coroutine enemyObjectGenerateCol;
    Coroutine itemObjectGenerateCol;
    Coroutine trapObjectGenerateCol;

    void Update()
    {
        if (GameManager.gameState == GameState.gameover || GameManager.gameState == GameState.retry || createGoal) return;

        if (transform.position.z > goalPosition)
        {
            CreateGoal();
            createGoal = true;
        }
        else
        {
            if (enemyObjectGenerateCol == null)
            {
                enemyObjectGenerateCol = StartCoroutine(EnemyObjectGenerateCol());
            }
            if (itemObjectGenerateCol == null)
            {
                itemObjectGenerateCol = StartCoroutine(ItemObjectGenerateCol());
            }
            if (trapObjectGenerateCol == null)
            {
                trapObjectGenerateCol = StartCoroutine(TrapObjectGenerateCol());
            }
        }

    }

    IEnumerator EnemyObjectGenerateCol()
    {
        float generationInterval = Random.Range(1, maxEnemyIntervalTime + 1.0f);
        yield return new WaitForSeconds(generationInterval);
        int index = Random.Range(0, enemyObjects.Length);
        int targetLane = Random.Range(MinLane, MaxLane + 1);
        Instantiate(
            enemyObjects[index],
            new Vector3(targetLane * LaneWidth, 1, transform.position.z),
            Quaternion.identity
            );
        enemyObjectGenerateCol = null;
    }


    IEnumerator TrapObjectGenerateCol()
    {
        float generationInterval = Random.Range(1, maxTrapIntervalTime + 1.0f);
        yield return new WaitForSeconds(generationInterval);
        int index = Random.Range(0, trapObjects.Length);
        Instantiate(
            trapObjects[index],
            new Vector3(0, 1, transform.position.z),
            Quaternion.identity
            );
        trapObjectGenerateCol = null;
    }

    IEnumerator ItemObjectGenerateCol()
    {
        float generationInterval = Random.Range(5, maxItemIntervalTime + 1.0f);
        yield return new WaitForSeconds(generationInterval);
        int index;
        if (bulletManager.GetBulletRemaining() <= 0 && bulletManager.GetMagazineRemaining() <= 0)
        {
            index = 0;
        }
        else
        {
            index = Random.Range(0, itemObjects.Length);
        }
        int targetLane = Random.Range(MinLane, MaxLane + 1);
        Instantiate(
            itemObjects[index],
            new Vector3(targetLane * LaneWidth, 1, transform.position.z),
            Quaternion.identity
            );
        itemObjectGenerateCol = null;
    }

    void CreateGoal()
    {
        Instantiate(
            goalPrefab,
            new Vector3(0, 1, transform.position.z),
            Quaternion.identity
            );
    }

}
