using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Controler : MonoBehaviour
{
    Rigidbody2D rb2D;
    public float speed;
    int Score;
    public Text scoreText;
    public Text WinText;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        Score = 0;   
    }

    void Update()
    {
        if (Score >= 7)
        {
            WinText.gameObject.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2D.AddForce(movement*speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pickup"))
        {
            Destroy(collision.gameObject);
            Score++;
            UpdateScore();
        }
    }

    void UpdateScore()
    {
        scoreText.text = $"<color=white>Score: {Score.ToString()}</color>";
    }
}
