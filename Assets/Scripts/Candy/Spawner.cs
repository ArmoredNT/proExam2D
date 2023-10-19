using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject Candy1;
    [SerializeField] private GameObject Candy2;
    [SerializeField] private GameObject Candy3;
    private GameObject currentCandy;
    public int amountSpawned;
    //public bool charChosen = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startSpawn()
    {
        StopCoroutine(spawn());
        StartCoroutine(spawn());
    }
    void candyPicker()
    {
        int num = Random.Range(1, 7);
        print(num + "Current");
        if (num == 1)
        {
            currentCandy = Candy3;
        }
        else if (num == 2 || num == 3)
        {
            currentCandy = Candy2;
        }
        else
        {
            currentCandy = Candy1;
        }
    }
    public IEnumerator spawn()
    {
        yield return new WaitForSeconds(Random.Range(1, 3));
        newPos();
        candyPicker();
        Instantiate(currentCandy, gameObject.transform.position, Quaternion.identity);
        amountSpawned++;
        if (amountSpawned < 15)
        {
            StartCoroutine(spawn());
        }
        else
        {
            StartCoroutine(delay());
        }

        
    }
    IEnumerator delay()
    {
        yield return new WaitForSeconds(3f);
        
        Player.GetComponent<Player>().finalUI();

    }

    void newPos()
    {
        gameObject.transform.position = new Vector3(Random.Range(-8, 8), 5f, 0f);
    }
}
