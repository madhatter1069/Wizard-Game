using System.Collections;
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
    public float attackRange;
    public float attackCD;

    [SerializeField]GameObject targetPlayer;
    private bool _isMoving = false;
    private bool _isAttacking = false;
    private Vector3 _scale;

    void Start()
    {
        _scale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        Attack(); //attack() should be called before move()
        Move();
        CheckTargetPlayer();
        
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
                    if (targetPlayer.GetComponent<Player>().GetSpellDamage(attackDamage))
                    {
                        GetComponent<AgentHelper>().ResetTarget();
                        targetPlayer = null;
                    }
                    
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
            applySpell(ob.GetComponent<BaseBullet>().element, ob.GetComponent<BaseBullet>().damage);
            Destroy(ob); //destroy spell bullet after collision;
        }
    }

    private void applySpell(spellType spell, float default_damage)
    {
        if(spell == weakSpellType)
        {
            health -= weaknessDamageFactor * default_damage;
        }
        else if(spell == resistedSpellType)
        {
            health -= resistedDamageFactor * default_damage;
        }
        else if(spell != immuneSpellType)
        {
            health -= default_damage;
        }

        if (health <= 0)
        {
            Destroy(GetComponent<AgentHelper>().avatar);
            Destroy(gameObject);
        }
    }

    

    private void CheckTargetPlayer()
    {
        if (!targetPlayer)
        {
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            for (int i=0;i<players.GetLength(0);++i)
            {
                if (Vector2.Distance(players[i].transform.position, transform.position) <= targetingRange) {
                    targetPlayer = players[i];
                    return;
                }
            }
        }
        else
        {
            if (Vector2.Distance(targetPlayer.transform.position, transform.position) >= loseTargetingRange)
            {
                targetPlayer = null;
                _isMoving = false;
                return;
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
