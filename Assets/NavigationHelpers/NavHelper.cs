using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class NavHelper : MonoBehaviour
{
    public GameObject avatar;
    public float planeYOffset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }


    void LateUpdate()
    {
        //update avatar's position in terms of current position
        avatar.transform.position = new Vector3(transform.position.x, 0, transform.position.y + planeYOffset);
    }

}


