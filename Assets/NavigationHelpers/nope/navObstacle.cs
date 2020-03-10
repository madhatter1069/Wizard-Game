using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class navObstacle : MonoBehaviour
{
    public Transform avatar;
    public float planeYOffset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        avatar.position = new Vector3(transform.position.x, 0,transform.position.y + planeYOffset);
    }
}
