using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class EnemyBullet : MonoBehaviour
{
    private Vector2 moveDirection;
    public int damage;
    [SerializeField] public spellType element;

    private float rotation;


    void Start()
    {

        rotation = 0f;
        rotation = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;

        transform.transform.Rotate(0f, 0f, rotation-45, Space.World);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void changeDir(Vector2 newDir){
        moveDirection=newDir;
    }

    void OnTriggerEnter2D(Collider2D other)
    { 
        if (other.gameObject.CompareTag("floor"))
        {
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<Player>().GetSpellDamage(damage);
            Destroy(gameObject);
        }
    }
}
