using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum spellType {def, ice , fire, earth, wind, lightning, none};



public class BaseBullet : MonoBehaviour
{
    public float moveSpeed = 6;
    private Vector2 moveDirection;
    public float damage = 1;
    [SerializeField] public spellType element;

    float rotation;

    float lifeTime;
    float beginTime;

    void Start()
    {
        beginTime = Time.time;
        lifeTime = 4;

        rotation = 0f;

        if (moveDirection.x == 0 && moveDirection.y > 0)
        {
            // Up (0, 1)
            rotation = 45f;
        }
        else if (moveDirection.x < 0 && moveDirection.y > 0)
        {
            // Up Left (-1, 1)
            rotation = 90f;
        }
        else if (moveDirection.x > 0 && moveDirection.y > 0)
        {
            // Up Right (1, 1)
            rotation = 0f;
        }
        else if (moveDirection.x == 0 && moveDirection.y < 0)
        {
            // Down (0, -1)
            rotation = 225f;
        }
        else if (moveDirection.x < 0 && moveDirection.y < 0)
        {
            // Down Left (-1, -1)
            rotation = 180f;
        }
        else if (moveDirection.x > 0 && moveDirection.y < 0)
        {
            // Down Right (1, -1)
            rotation = 270f;
        }
        else if (moveDirection.x < 0 && moveDirection.y == 0)
        {
            // Left (-1, 0)
            rotation = 135f;
        }
        else if (moveDirection.x > 0 && moveDirection.y == 0)
        {
            // Right (1, 0)
            rotation = 315f;
        }
        else
        {
            // moveDirection = (0,0); Not Moving
            rotation = 0f;
        }

        transform.transform.Rotate(0f, 0f, rotation, Space.World);
    }

    // Update is called once per frame
    void Update()
    {
        //Move();
        CheckLifeTime();
        
    }

    public void changeDir(Vector2 newDir){
        moveDirection=newDir;
    }

    private void Move()
    {
        transform.transform.Translate(moveDirection*moveSpeed*Time.deltaTime);

    }


    private void CheckLifeTime()
    {
        if (Time.time - beginTime > lifeTime)
            Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D other)
    { 
        if (other.gameObject.CompareTag("floor"))
        {
            Destroy(gameObject);
        }
    }
}
