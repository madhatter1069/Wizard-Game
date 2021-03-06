﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableSpell : MonoBehaviour
{

    //public int spellIndex;

    //public GameObject[] spellObjects;
    [SerializeField] private GameObject spellProjectile;
    public float timer;

    void OnTriggerEnter2D(Collider2D other)
    { 
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Player>().ChangeSpell(spellProjectile);
            //Destroy(gameObject);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine(respawnBook());
        }
    }

    IEnumerator respawnBook()
    {
        yield return new WaitForSeconds(timer);
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
}
