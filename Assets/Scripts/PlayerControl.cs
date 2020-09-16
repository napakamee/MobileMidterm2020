using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControl : MonoBehaviour
{
    public float jumpForce;
    public int scorePerSec = 1;
    public bool isDead = false;
    public bool isJump = false;
    public bool canJump = false;
    private Rigidbody2D rb;

    public float maxSwipeDistance = 400;
    public float minSwipeDistance = 100;
    private Vector2 fingerStart;
    private Vector2 fingerEnd;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(!isDead){
            GameManagement.instance.Score ++;
        }
        SwipeCheck();
    }

    private void FixedUpdate()
    {
        PlayerJump();
    }
    void PlayerJump()
    {

        if (!isDead)
        {
            if (isJump && canJump)
            {
                rb.velocity = new Vector2(0, 0);
                rb.AddForce(new Vector2(0, jumpForce * 2.2f));
                isJump = false;
                canJump = false;
            }

        }
    }

    void OnCollisionStay2D(Collision2D collisionInfo)
    {
        canJump = true;
    }
    private void SwipeCheck()
    {

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                fingerStart = touch.position;
                //canJump = false;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                fingerEnd = touch.position;
                JumpForceCal();
                isJump = true;

                //if (fingerEnd.y > fingerStart.y && rb.velocity.y == 0)



            }


        }
    }

    private void JumpForceCal()
    {
        Vector2 distance = fingerEnd - fingerStart;
        float xDistance = Mathf.Abs(distance.x);
        float yDistance = Mathf.Abs(distance.y);

        if (distance.y > 0)
        {
            if (yDistance < minSwipeDistance)
            {
                jumpForce = minSwipeDistance;
            }

            if (yDistance > maxSwipeDistance)
            {
                jumpForce = maxSwipeDistance;
            }

            if (yDistance > minSwipeDistance && yDistance < maxSwipeDistance)
            {
                jumpForce = yDistance;
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger : " + other.name);
        if(other.name == "Coin"){
            GameManagement.instance.Score += 1000;
            
        }
        else{
            isDead = true;
            SettingSimulated();
        }
    }

    public void SettingSimulated()
    {
        rb.simulated = GameManagement.instance.isStartGame;
    }
}
