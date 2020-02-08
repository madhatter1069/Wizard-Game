using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentHelper : MonoBehaviour
{
    public GameObject avatar;
    public float planeYOffset;
    // Start is called before the first frame update
    void Start()
    {
        //init avatar's position
        avatar.transform.position = new Vector3(transform.position.x,0,transform.position.y+planeYOffset);
       
    }

    // Update is called once per frame
    void Update()
    {
        //update this position in terms of avatar's position
        transform.position = new Vector3(avatar.transform.position.x, avatar.transform.position.z-planeYOffset,0);
       
    }
}
