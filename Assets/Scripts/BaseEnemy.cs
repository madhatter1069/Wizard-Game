﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class BaseEnemy : MonoBehaviour
{
    public float enemyId;
    public float health;
    public int attackDamage;
 
    public spellType weakSpellType;
    public spellType resistedSpellType;
    public spellType immuneSpellType;
    public float weaknessDamageFactor;
    public float resistedDamageFactor;

    public float targetingRange;
    public float loseTargetingRange;
    public int targetID;

    public float attackRange;
    public float attackCD;

    [SerializeField] GameObject targetPlayer;
    private bool _isMoving = false;
    private bool _isAttacking = false;
    private Vector3 _scale;

    [SerializeField] private GameObject damagePopup;

    [SerializeField] private GameObject gameManager;


    void Start()
    {
        _scale = transform.localScale;

        //soundController = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckTargetPlayer();
        Attack(); //attack() should be called before move()
        Move();
        
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

    private void Move()
    {
        //find player, start moving and animation
        if(targetPlayer) {
            if (!_isMoving && !_isAttacking)
            {
                _isMoving = true;
                StartCoroutine(MoveAnimation());
            }

            if (targetPlayer.transform.position.x > transform.transform.position.x)
                GetComponent<SpriteRenderer>().flipX = true;
            else
                GetComponent<SpriteRenderer>().flipX = false;
        }

        
    }

    private void Attack()
    {
        if (targetPlayer)
        {
            if(Vector2.Distance(targetPlayer.transform.position,transform.position) < attackRange)
            {
                if (!_isAttacking)
                {
                    _isAttacking = true;
                    _isMoving = false; //stop moving animation
                    StartCoroutine(AttackAnimation()); //animate before applying damage in case player is destoryed(dead)

                    /*
                    if (targetPlayer.GetComponent<Player>().GetSpellDamage(attackDamage))
                    {
                        Debug.Log("BaseEnemy Script");
                        GetComponent<Pathfinding.AIDestinationSetter>().target = null;
                        targetPlayer.transform.position = targetPlayer.GetComponent<Player>().spawnPos;
                        targetPlayer = null;
                    }
                    else
                    {
                        Debug.Log("BaseEnemy Script");
                    }
                    */
                    
                }
            }
            //_isAttacking is reset when animation ends
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("spell"))
        {
            GameObject ob = collision.gameObject;
            float spellDamage = ob.GetComponent<BaseBullet>().damage;
            applySpell(ob.GetComponent<BaseBullet>().element, spellDamage);

            /*
            Vector3 dmgPopupPos = transform.position;
            GameObject dmgPopup = Instantiate(damagePopup, dmgPopupPos, transform.rotation);
            dmgPopup.GetComponent<DamagePopup>().Setup(spellDamage);
            */

            Destroy(ob); //destroy spell bullet after collision;
        }
    }

    private void applySpell(spellType spell, float default_damage)
    {
        if (spell == weakSpellType)
        {
            float weakDamage = weaknessDamageFactor * default_damage;
            health -= weakDamage;

            //Vector3 dmgPopupPos = transform.position + new Vector3(0, 0.5f, 0);
            Vector3 dmgPopupPos = transform.position;
            GameObject dmgPopup = Instantiate(damagePopup, dmgPopupPos, transform.rotation);
            dmgPopup.GetComponent<DamagePopup>().Setup(weakDamage);
        }
        else if (spell == resistedSpellType)
        {
            float resistDamage = resistedDamageFactor * default_damage;
            health -= resistDamage;

            //Vector3 dmgPopupPos = transform.position + new Vector3(0, 0.5f, 0);
            Vector3 dmgPopupPos = transform.position;
            GameObject dmgPopup = Instantiate(damagePopup, dmgPopupPos, transform.rotation);
            dmgPopup.GetComponent<DamagePopup>().Setup(resistDamage);
        }
        else if (spell != immuneSpellType)
        {
            health -= default_damage;

            //Vector3 dmgPopupPos = transform.position + new Vector3(0, 0.5f, 0);
            Vector3 dmgPopupPos = transform.position;
            GameObject dmgPopup = Instantiate(damagePopup, dmgPopupPos, transform.rotation);
            dmgPopup.GetComponent<DamagePopup>().Setup(default_damage);
        }
        else if (spell == immuneSpellType)
        {
            //Vector3 dmgPopupPos = transform.position + new Vector3(0, 0.5f, 0);
            Vector3 dmgPopupPos = transform.position;
            GameObject dmgPopup = Instantiate(damagePopup, dmgPopupPos, transform.rotation);
            dmgPopup.GetComponent<DamagePopup>().Setup(0);
        }

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

    

    private void CheckTargetPlayer()
    {
        
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject p in players){
            if (targetPlayer == null)
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
            else if(targetPlayer != null){
                targetID = targetPlayer.GetComponent<Player>().playId;

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

                if (targetID == 0)
                {
                    if (gameManager.GetComponent<GameManager>().p1health == 0)
                    {
                        targetPlayer = null;
                    }
                }
                else if (targetID == 1)
                {
                    if (gameManager.GetComponent<GameManager>().p2health == 0)
                    {
                        targetPlayer = null;
                    }
                }
            }
        }
    }


    private IEnumerator MoveAnimation()
    {
        while (_isMoving)
        {
            transform.localScale = new Vector3(_scale.x, 0.9f * _scale.y, _scale.z);
            yield return new WaitForSeconds(0.15f);
            transform.localScale = _scale;
            yield return new WaitForSeconds(0.15f);
        }
    }

    private IEnumerator AttackAnimation()
    {
        Vector3 currentPos = transform.position;
        Vector3 targetPos = targetPlayer.transform.position;

        transform.Translate((targetPos - transform.position).normalized * -3f * Time.deltaTime);
        yield return new WaitForSeconds(0.2f);

        transform.Translate((targetPos - transform.position).normalized * 3f * Time.deltaTime);
        yield return new WaitForSeconds(0.05f);

        transform.position = currentPos;
  
        yield return new WaitForSeconds(attackCD);
        _isAttacking = false;

    }

    //accessors
    public GameObject getTargetPlayer()
    {
        return targetPlayer;
    }
    public bool isAttacking()
    {
        return _isAttacking;
    }
    public bool isMoving()
    {
        return _isMoving;
    }
}
