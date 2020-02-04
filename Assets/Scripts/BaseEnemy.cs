using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BaseEnemy : MonoBehaviour
{
    public float enemyId;
    public float health;
    public GameObject targetPlayer;
    public spellType weakSpellType;
    public spellType resistedSpellType;
    public spellType ImmuneSpellType;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
