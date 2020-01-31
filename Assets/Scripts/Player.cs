using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int playId;
    public float moveSpeed = 4;
    [SerializeField] private GameObject spell;
    public float shootCD;
    float lastShootTime;

    private Vector2 currentFacing;

    void Start()
    {
        currentFacing = Vector2.down;
        lastShootTime = Time.time;
    }

    public void ChangeSpell(GameObject Newspell){
        spell=Newspell;
    }
    
    void FixedUpdate()
    {
        Move();
        Shoot();
    }

    //private functional helpers

    private void Move()
    {
        switch (playId)
        {
            case 0:
                Control(KeyCode.W, KeyCode.S,KeyCode.A,KeyCode.D);
                break;
            case 1:
                Control(KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.RightArrow);
                break;
            default:
                Control(KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D);
                break;
        }
        
    }

    private void Control(KeyCode up, KeyCode down, KeyCode left, KeyCode right)
    {
        Vector2 UpDown = new Vector2();
        Vector2 LeftRight = new Vector2();
        bool getKey = false;
        if (Input.GetKey(up))
        {
            UpDown = Vector2.up;
            getKey = true;
        }
        if (Input.GetKey(down))
        {
            UpDown = Vector2.down;
            getKey = true;
        }
        if (Input.GetKey(left))
        {
            LeftRight = Vector2.left;
            getKey = true;
        }
        if (Input.GetKey(right))
        {
            LeftRight = Vector2.right;
            getKey = true;
        }
        if (getKey)
        {
            currentFacing = (UpDown + LeftRight).normalized;
            gameObject.transform.Translate(currentFacing * moveSpeed * Time.deltaTime);
        }
    }

    private void Shoot()
    {
        KeyCode shootKey;
        switch (playId)
        {
            case 0:
                shootKey = KeyCode.LeftShift;
                break;
            case 1:
                shootKey = KeyCode.Space;
                break;
            default:
                shootKey = KeyCode.LeftShift;
                break;
        }

        if (Input.GetKey(shootKey) && Time.time-lastShootTime > shootCD)
        {
            GameObject bullet = Instantiate(spell);
            bullet.transform.parent = null;
            bullet.transform.position = transform.position;
            bullet.GetComponent<BaseBullet>().changeDir(currentFacing);
            lastShootTime = Time.time;
        }
    }
}
