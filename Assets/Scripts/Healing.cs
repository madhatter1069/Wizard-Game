using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour
{
    [SerializeField ] private int healthVal;
    public float timer;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.gameObject.GetComponent<Player>().health < other.gameObject.GetComponent<Player>().maxHealth)
        {
            if ((other.gameObject.GetComponent<Player>().health + healthVal) <= other.gameObject.GetComponent<Player>().maxHealth)
            {
                other.gameObject.GetComponent<Player>().HealPlayer(healthVal);
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                StartCoroutine(respawnHeart());
                //Debug.Log("Player " + other.gameObject.GetComponent<Player>().playId + " health/maxHealth: " + other.gameObject.GetComponent<Player>().health + "/" + other.gameObject.GetComponent<Player>().maxHealth);
            }
            else
            {
                int fillHealth = (int)(other.gameObject.GetComponent<Player>().maxHealth - other.gameObject.GetComponent<Player>().health);
                other.gameObject.GetComponent<Player>().HealPlayer(fillHealth);
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                StartCoroutine(respawnHeart());
                //Debug.Log("Player " + other.gameObject.GetComponent<Player>().playId + " health/maxHealth: " + other.gameObject.GetComponent<Player>().health + "/" + other.gameObject.GetComponent<Player>().maxHealth);
            }
        } 
    }

    IEnumerator respawnHeart()
    {
        yield return new WaitForSeconds(timer);
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
}
