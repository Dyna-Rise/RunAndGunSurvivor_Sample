using System.Collections;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    const int MinLane = -2;
    const int MaxLane = 2;
    const float LaneWidth = 1.0f;

    public GameObject[] enemyObjects;
    public GameObject[] itemObjects;

    public float maxEnemyIntervalTime = 5.0f;
    public float maxItemIntervalTime = 10.0f;

    int targetLane;

    Coroutine enemyObjectGenerateCol;
    Coroutine itemObjectGenerateCol;

    void Update()
    {
        if (enemyObjectGenerateCol == null)
        {
            enemyObjectGenerateCol = StartCoroutine(EnemyObjectGenerateCol());
        }
        if (itemObjectGenerateCol == null)
        {
            itemObjectGenerateCol = StartCoroutine(ItemObjectGenerateCol());
        }

    }

    IEnumerator EnemyObjectGenerateCol()
    {
        float generationInterval = Random.Range(1, maxEnemyIntervalTime + 1.0f);
        yield return new WaitForSeconds(generationInterval);
        int index = Random.Range(0, enemyObjects.Length);
        targetLane = Random.Range(MinLane, MaxLane + 1);
        Instantiate(
            enemyObjects[index],
            transform.position + new Vector3(targetLane * LaneWidth, 0, 0),
            Quaternion.identity
            );
        enemyObjectGenerateCol = null;
    }

    IEnumerator ItemObjectGenerateCol()
    {
        float generationInterval = Random.Range(5, maxItemIntervalTime + 1.0f);
        yield return new WaitForSeconds(generationInterval);
        int index = Random.Range(0, itemObjects.Length);
        targetLane = Random.Range(MinLane, MaxLane + 1);
        Instantiate(
            itemObjects[index],
            transform.position + new Vector3(targetLane * LaneWidth, 0, 0),
            Quaternion.identity
            );
        itemObjectGenerateCol = null;
    }

}
