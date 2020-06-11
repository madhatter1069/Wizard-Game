using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowKillSwitch : MonoBehaviour
{
    public bool killSwitch = false;
    private bool switchActive = false;

    [SerializeField] private GameObject enemyList;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (enemyList)
        {
            if (enemyList.transform.childCount == 0)
            {
                switchActive = true;
            }
        }
        else if (!enemyList || enemyList == null)
        {
            switchActive = true;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player" && switchActive == true)
        {
            Debug.Log("killswitch true");
            killSwitch = true;
            switchActive = false;
            Destroy(gameObject, 2f);
        }
    }

}
