using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class BaseEnemy : MonoBehaviour
{
    public float enemyId;
    public float health;
    public GameObject targetPlayer;
    public spellType weakSpellType;
    public spellType resistedSpellType;
    public spellType ImmuneSpellType;
    public float weaknessDamageFactor;
    public float resistedDamageFactor;

    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("spell"))
        {
            GameObject ob = collision.gameObject;
            applySpell(ob.GetComponent<BaseBullet>().element, ob.GetComponent<BaseBullet>().damage);
            Destroy(ob);
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
        else if(spell != ImmuneSpellType)
        {
            health -= default_damage;
        }

        if (health <= 0)
            Destroy(gameObject);
    }
}
