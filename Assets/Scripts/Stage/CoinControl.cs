﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinControl : MonoBehaviour
{
    public float speed = 3.5f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        //rb.velocity = new Vector2(-speed, 0);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Collider2D>().tag.Contains("Player")){
            Debug.Log("Player hit");
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (GameManagement.instance.isStartGame){
            rb.position -= new Vector2(speed * Time.deltaTime, 0);

            if(transform.position.x < screenBounds.x * -2){
            Destroy(this.gameObject);
        }
        }
    }
}
