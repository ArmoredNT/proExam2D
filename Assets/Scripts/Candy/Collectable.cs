using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private int value;
    [SerializeField] private GameObject Player;
    
    void Start()
    {
        Player = GameObject.Find("Monster");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.transform.tag == "Player")
        {
            
            Player.GetComponent<Player>().increaseScore(value);
            Player.GetComponent<Player>().getScore();
            Destroy(gameObject);
        }
        else
        {
            print("you let the candy touch the ground");
            Destroy(gameObject);
        }
        
        
    }
}
