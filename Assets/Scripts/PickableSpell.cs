using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableSpell : MonoBehaviour
{

    //public int spellIndex;

    //public GameObject[] spellObjects;
    [SerializeField] private GameObject spellProjectile;


    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    { 
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Player>().ChangeSpell(spellProjectile);
            Destroy(gameObject);
        }
    }
}
