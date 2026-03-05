using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRun : MonoBehaviour
{
    const int MinLane = -2;
    const int MaxLane = 2;
    const float LaneWidth = 1.0f;
    const int DefaultLife = 3;
    const float StunDuration = 0.5f;

    CharacterController controller;
    Animator animator;

    Vector3 moveDirection = Vector3.zero;
    int targetLane;
    int life = DefaultLife;
    float recoverTime = 0.0f;

    float currentMoveInputX;
    Coroutine resetIntervalCol;

    public float gravity = 20.0f;
    public float speedZ = 5.0f;
    public float speedX = 3.0f;
    public float speedJump = 8.0f;
    public float accelerationZ = 10.0f;

    public int Life()
    {
        return life;
    }

    public void LifeUP()
    {
        life++;
        if (life > DefaultLife) life = DefaultLife;
    }

    bool IsStun()
    {
        return recoverTime > 0.0f || life <= 0;
    }

    void OnMove(InputValue value)
    {
        if (resetIntervalCol == null)
        {
            Vector2 inputVector = value.Get<Vector2>();
            currentMoveInputX = inputVector.x; // x成分が左右の入力（-1:左, 0:なし, 1:右）
        }
    }
    void OnJump(InputValue value)
    {
        Jump();
    }
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //if (Input.GetKeyDown("left")) MoveToLeft();
        //if (Input.GetKeyDown("right")) MoveToRight();
        //if (Input.GetKeyDown("space")) Jump();

        if (currentMoveInputX < 0) MoveToLeft();
        if (currentMoveInputX > 0) MoveToRight();

        if (IsStun())
        {
            moveDirection.x = 0.0f;
            moveDirection.z = 0.0f;
            recoverTime -= Time.deltaTime;
        }
        else
        {
            float acceleratedZ = moveDirection.z + (accelerationZ * Time.deltaTime);
            moveDirection.z = Mathf.Clamp(acceleratedZ, 0, speedZ);

            float ratioX = (targetLane * LaneWidth - transform.position.x) / LaneWidth;
            moveDirection.x = ratioX * speedX;
        }

        //Debug.Log(moveDirection.x);
        moveDirection.y -= gravity * Time.deltaTime;

        Vector3 globalDirection = transform.TransformDirection(moveDirection);
        controller.Move(globalDirection * Time.deltaTime);

        if (controller.isGrounded) moveDirection.y = 0;

        //animator.SetBool("run", moveDirection.z > 0.0f);
    }

    public void MoveToLeft()
    {
        if (IsStun()) return;
        if (controller.isGrounded && targetLane > MinLane)
        {
            targetLane--;
            currentMoveInputX = 0;
            resetIntervalCol = StartCoroutine(ResetInterval());
        }
    }

    public void MoveToRight()
    {
        if (IsStun()) return;
        if (controller.isGrounded && targetLane < MaxLane)
        {
            targetLane++;
            currentMoveInputX = 0;
            resetIntervalCol = StartCoroutine(ResetInterval());
        }
    }

    IEnumerator ResetInterval()
    {
        yield return new WaitForSeconds(0.1f);
        resetIntervalCol = null;
    }

    public void Jump()
    {
        if (IsStun()) return;
        if (controller.isGrounded)
        {
            moveDirection.y = speedJump;
            animator.SetTrigger("jump");
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (IsStun()) return;

        if(hit.gameObject.tag == "Enemy")
        {
            life--;
            GameObject canvas = GameObject.FindGameObjectWithTag("UI");
            canvas.GetComponent<UIController>().UpdateLife(life);
            recoverTime = StunDuration;

            //animator.SetTrigger("damage");

            hit.gameObject.GetComponent<Wall>().CreateEffect();
        }
    }
}
