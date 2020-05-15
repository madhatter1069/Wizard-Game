using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour
{
    [SerializeField ] private int healthVal;
    public float timer;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && 
            other.gameObject.GetComponent<Player>().health<other.gameObject.GetComponent<Player>().maxHealth)
        {
            other.gameObject.GetComponent<Player>().HealPlayer(healthVal);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine(respawnHeart());
        } 
    }

    IEnumerator respawnHeart()
    {
        yield return new WaitForSeconds(timer);
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
}
