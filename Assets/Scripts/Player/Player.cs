using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector2 _moveDir;

    private Rigidbody2D rb;

    [SerializeField] private float speed;
    [SerializeField] private TextMeshProUGUI scoreDisplayer;
    [SerializeField] private TextMeshProUGUI endDisplayer;
    [SerializeField] private TextMeshProUGUI message;

    [SerializeField] private GameObject spawner;

    [SerializeField] private Sprite m1;
    [SerializeField] private Sprite m2;
    
    private int score;

    public int chr;
    // Start is called before the first frame update
    void Start()
    {
        InputManager.init(this);
        InputManager.moveMode();
        rb = gameObject.GetComponent<Rigidbody2D>();

        endDisplayer.text = "";
        message.text = "Choose your character by pressing 1 or 2";
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (chr == 1)
        {
            speed = 0.5f;
            spawner.GetComponent<Spawner>().startSpawn();
            chr = 0;
            gameObject.GetComponent<SpriteRenderer>().sprite = m1;
            message.text = "";
        }
        else if (chr == 2)
        {
            speed = 2f;
            spawner.GetComponent<Spawner>().startSpawn();
            chr = 0;
            gameObject.GetComponent<SpriteRenderer>().sprite = m2;
            message.text = "";
        }
        
        rb.AddForce(_moveDir * speed);
        
        UIStuff();
    }

    void UIStuff()
    {
        scoreDisplayer.text = "Score: " + score;
    }
    public void finalUI()
    {
        endDisplayer.text = "Final Score: " + score;

        if (score < 15)
        {
            message.text = "Sadness";
        }
        else if (score >= 15 && score < 35)
        {
            message.text = "Sugar Rush";
        }
        else if (score >= 35 && score < 50)
        {
            message.text = "Halloween";
        }
        else if (score > 50)
        {
            message.text = "Candy craze";
        }
    }
    public void SetMoveDirection(Vector2 newDirection)
    {
        
        _moveDir = newDirection;
        

    }

    public void Reset()
    {
        print("reset");
        score = 0;
        endDisplayer.text = "";
        message.text = "";
        gameObject.transform.position = new Vector3(0, -3f);
        spawner.GetComponent<Spawner>().amountSpawned = 0;
        spawner.GetComponent<Spawner>().startSpawn();
    }

    public void increaseScore(int value)
    {
        score += value;
    }
    public void getScore()
    {
        print(score);
    }
}
