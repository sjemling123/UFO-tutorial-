﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    
    private Rigidbody2D rb2d;

    public Text countText;
    public Text winText;
    private int count;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
        count = 0;
        winText.text = " ";
        SetcountText();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetcountText();
        }
    }

        void SetcountText()
        {
            countText.text = "Count:" + count.ToString();

        if (count >= 12)
        {
            winText.text = "You Win!";
        }

     }
     }
