using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class BossEnemy : MonoBehaviour
{
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

    public GameObject Shot; 
    

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
        if (health <= 0){
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
            Vector3 dir = targetPlayer.transform.position - transform.position;
            dir = targetPlayer.transform.InverseTransformDirection(dir);
            Vector2 UD = new Vector2(0, dir.y);
            Vector2 LR = new Vector2(dir.x, 0);
            GameObject projectile = Instantiate(Shot, transform.position, transform.rotation);
            //float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

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
            Destroy(gameObject);
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
