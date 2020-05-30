using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class BossEnemy : MonoBehaviour
{
    public float enemyId;
    public float health;
    public float maxHealth;
    public int attackDamage;
 
    public spellType weakSpellType;
    public spellType resistedSpellType;
    public spellType immuneSpellType;
    public float weaknessDamageFactor;
    public float resistedDamageFactor;

    public float targetingRange;
    public float loseTargetingRange;
    public float attackRange;
    public float attackCD;
    private float shotTime;
    [SerializeField] private GameObject spell;
    [SerializeField] private float spellSpeed;
    

    [SerializeField]GameObject targetPlayer;
    private bool _isMoving = false;
    private bool _isAttacking = false;

    private Vector3 _scale;


    

    void Start()
    {
        _scale = transform.localScale;
        shotTime = Time.time;
        health = maxHealth;
    }

    void Update()
    {
        Shoot();
        CheckTargetPlayer();
        if (health <= 0){
            switch (enemyId)
            {
                case 1:
                    FindObjectOfType<AudioManager>().Play("SlimeDeath");
                    break;

                case 2:
                    FindObjectOfType<AudioManager>().Play("SkeletonDeath");
                    break;
            }
            Destroy(gameObject);
        }
        
    }

    private void Shoot()
    {
        if (targetPlayer)
        {
            if(Time.time - shotTime > attackCD)
            {
                GameObject bullet = Instantiate(spell, transform.position, transform.rotation);
                Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
                bullet.transform.parent = null;
                shotTime = Time.time;
                Vector2 facing = targetPlayer.transform.position - transform.position ;
                facing = facing.normalized;
                bullet.GetComponent<EnemyBullet>().changeDir(facing);
                bulletRb.velocity = facing * spellSpeed ;
            }
        }

    }

    private void applySpell(spellType spell, float default_damage)
    {
        if(spell == weakSpellType)
        {health -= weaknessDamageFactor * default_damage;}
        else if(spell == resistedSpellType)
        {health -= resistedDamageFactor * default_damage;}
        else if(spell != immuneSpellType)
        {health -= default_damage;}
        
        if (health <= 0)
        {
            switch (enemyId)
            {
                case 1:
                    FindObjectOfType<AudioManager>().Play("SlimeDeath");
                    break;

                case 2:
                    FindObjectOfType<AudioManager>().Play("SkeletonDeath");
                    break;
            }
            
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("spell"))
        {
            GameObject ob = collision.gameObject;
            applySpell(ob.GetComponent<BaseBullet>().element, ob.GetComponent<BaseBullet>().damage);
            Destroy(ob); //destroy spell bullet after collision;
        }
    }

    private void CheckTargetPlayer()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject p in players){
            if (!targetPlayer)
            {
                for (int i=0;i<players.GetLength(0);++i)
                {
                    if (Vector2.Distance(p.transform.position, transform.position) <= targetingRange) {
                        targetPlayer = p;
                        GetComponent<Pathfinding.AIDestinationSetter>().target = targetPlayer.transform;
                        return;
                    }
                }
            }
            else if(targetPlayer){
                if (Vector2.Distance(targetPlayer.transform.position, transform.position) >= loseTargetingRange)
                {
                    targetPlayer = null;
                    GetComponent<Pathfinding.AIDestinationSetter>().target = null;
                    _isMoving = false;
                    return;
                }
                if(Vector2.Distance(targetPlayer.transform.position, transform.position) > Vector2.Distance(p.transform.position, transform.position)){
                    if (Vector2.Distance(p.transform.position, transform.position) <= targetingRange) {
                        targetPlayer = p;
                        GetComponent<Pathfinding.AIDestinationSetter>().target = targetPlayer.transform;
                        return;
                    }
                }
            }
        }
    }

    public GameObject getTargetPlayer()
    {
        return targetPlayer;
    }

    public void ResetHealth()
    {
        health = maxHealth;
    }


}
