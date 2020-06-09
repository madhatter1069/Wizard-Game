using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopup : MonoBehaviour
{
    private TextMeshPro textMesh;

    private float moveAmount;

    private void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
    }

    public void Setup(float damageAmount)
    {
        int convertFloat = (int)damageAmount;
        textMesh.SetText(convertFloat.ToString());
    }

    void Start()
    {
        //Debug.Log("Spawn");
        //Destroy(gameObject, 1.5f);
        moveAmount = transform.position.y + 0.75f;
    }

    void FixedUpdate()
    {
        if (transform.position.y < moveAmount)
        {
            transform.position = new Vector3(transform.position.x, (transform.position.y + 0.02f), transform.position.z);
            
            //Debug.Log("Y value = " + transform.position.y);
            //Debug.Log("Worked");
        }
        else
        {
            //Debug.Log("Broked");
            Destroy(gameObject);
        }
    }
}
