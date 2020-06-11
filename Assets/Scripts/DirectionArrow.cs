using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionArrow : MonoBehaviour
{
    //[SerializeField] private GameObject cameraPan;
    //[SerializeField] private GameObject arrowSwitch;

    void Start()
    {
        
    }


    void FixedUpdate()
    {


        /*
        Debug.Log(arrowSwitch.GetComponent<ArrowKillSwitch>().killSwitch);
        if (arrowSwitch.GetComponent<ArrowKillSwitch>().killSwitch == true)
        {
            Debug.Log("killswitch = true");
            arrowSwitch.GetComponent<ArrowKillSwitch>().killSwitch = false;
            Destroy(gameObject);
        }
     
        //Debug.Log(cameraPan.GetComponent<CameraPan>().newRoom);
        if (cameraPan.GetComponent<CameraPan>().newRoom == true)
        {
            Debug.Log("Delete");
            cameraPan.GetComponent<CameraPan>().ResetNewRoom();
            Destroy(gameObject);
        }
        */
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Destroy(gameObject, 5f);
        }
    }
}
