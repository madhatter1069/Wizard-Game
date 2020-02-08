using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum spellType {def, ice , fire, earth, wind, lightning};



public class BaseBullet : MonoBehaviour
{
    public float moveSpeed = 12;
    private Vector2 moveDirection;
    public float damage = 1;
    public spellType element;

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
}
