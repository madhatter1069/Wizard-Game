using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum spellType { def,ice,fire};



public class BaseBullet : MonoBehaviour
{
    public float moveSpeed;
    public Vector2 moveDirection;
    public float damage;

    float lifeTime;
    float beginTime;

    void Start()
    {
        beginTime = Time.time;
        lifeTime = 4;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckLifeTime();
        
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
}
