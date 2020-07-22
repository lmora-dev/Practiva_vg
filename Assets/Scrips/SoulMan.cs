using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulMan : MonoBehaviour
{
    public int soulValue = 100;
    public int soulCount = 1;

    BeginManager begin;

    public GameObject SoulPicked;
               
    void Start()
    {

        begin = GameObject.FindGameObjectWithTag("GameController").GetComponent<BeginManager>();

    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            begin.UpdateScore(soulValue);
            begin.UpdateSoul(soulCount);

            Instantiate(SoulPicked, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }

    }
}
