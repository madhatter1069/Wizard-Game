using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[ExecuteInEditMode]
public class NavHelper : MonoBehaviour
{
    public GameObject avatar;
    // Start is called before the first frame update
    void Start()
    {
        avatar.transform.position = new Vector3(transform.position.x,
                                                avatar.transform.position.y,
                                                transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        avatar.transform.position = new Vector3(transform.position.x,
                                                avatar.transform.position.y,
                                                transform.position.z); 
    }
}


