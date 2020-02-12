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
        Animation();
    }

    void OnTriggerEnter2D(Collider2D other)
    { 
        //Debug.Log("Spell select");
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Player>().ChangeSpell(spellProjectile);
            Destroy(gameObject);
        }
    }



    private void Animation()
    {
        transform.Rotate(Vector3.forward, Time.deltaTime * 100);
        transform.Translate(Vector3.up * Mathf.Sin(Time.time*3) / 200f,Space.World);
    }
}

