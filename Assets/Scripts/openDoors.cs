using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openDoors : MonoBehaviour
{
    public GameObject EnemyList;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(EnemyList){
            if (EnemyList.transform.childCount == 0){
                Destroy(EnemyList.gameObject);
                Destroy(gameObject);
            }
        }
        else if(!EnemyList || EnemyList == null)
        {
            Destroy(EnemyList.gameObject);
            Destroy(gameObject);
        }
    }
}
