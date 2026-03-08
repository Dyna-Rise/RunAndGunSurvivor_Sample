using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class NormalSword : MonoBehaviour
{
    public GameObject swordObject;
    public int swordPower = 3;
    public float swordTime = 0.5f;
    Coroutine swordAttackCol;
    bool isSword;

    void OnCrouch(InputValue value)
    {
        Debug.Log("Sword");
        SwordAttack();
    }
    void Start()
    {
        swordObject.SetActive(false);
    }

    void SwordAttack()
    {
        if (swordAttackCol == null)
        {
            swordAttackCol = StartCoroutine(SwordAttackCol());
        }
    }

    IEnumerator SwordAttackCol()
    {
        swordObject.SetActive(true);
        isSword = true;
        yield return new WaitForSeconds(swordTime);
        swordObject.SetActive(false);
        isSword = false;
        swordAttackCol = null;
    }

    public int GetSwordPower()
    {
        return swordPower;
    }

    public bool GetIsSword()
    {
        return isSword;
    }
}
