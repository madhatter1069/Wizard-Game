using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    public int hitPoints;
    // Start is called before the first frame update
    void Start()
    {
        hitPoints = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("spell") || other.gameObject.CompareTag("EnemySpell")){
            hitPoints++;
            if (hitPoints >= 3){
                Destroy(gameObject);
            }
            Destroy(other.gameObject);
        }
    }
}
