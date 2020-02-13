using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int playId;
    public float health;
    public float moveSpeed = 4;
    public float bulletSpeed = 6;
    [SerializeField] private GameObject spell;
    public float shootCD;
    float lastShootTime;

    private Vector2 currentFacing;

    public Animator anim;

    void Start()
    {
        currentFacing = Vector2.down;
        lastShootTime = Time.time;

        anim = GetComponent<Animator>();

        anim.SetBool("Walking", false);
        anim.SetBool("Attacking", false);
        anim.SetInteger("Vertical", 0);
        anim.SetInteger("Horizontal", 1);
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
            anim.SetBool("Walking", true);
            anim.SetInteger("Vertical", 1);
            //anim.SetInteger("Horizontal", 0);
        }
        if (Input.GetKey(down))
        {
            UpDown = Vector2.down;
            getKey = true;
            anim.SetBool("Walking", true);
            anim.SetInteger("Vertical", 0);
            //anim.SetInteger("Horizontal", 1);
        }
        if (Input.GetKey(left))
        {
            LeftRight = Vector2.left;
            getKey = true;
            anim.SetBool("Walking", true);
            anim.SetInteger("Vertical", 0);
            anim.SetInteger("Horizontal", -1);
        }
        if (Input.GetKey(right))
        {
            LeftRight = Vector2.right;
            getKey = true;
            anim.SetBool("Walking", true);
            anim.SetInteger("Vertical", 0);
            anim.SetInteger("Horizontal", 1);
        }
        if (getKey)
        {
            currentFacing = (UpDown + LeftRight).normalized;
            gameObject.transform.Translate(currentFacing * moveSpeed * Time.deltaTime);
            //Debug.Log(currentFacing);
        }
        if (Input.GetKey(up)==false && Input.GetKey(down) == false && Input.GetKey(left) == false && Input.GetKey(right) == false)
        {
            anim.SetBool("Walking", false);
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
            anim.SetBool("Attacking", true);
            //GameObject bullet = Instantiate(spell);
            GameObject bullet = Instantiate(spell, transform.position, transform.rotation);
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            bullet.transform.parent = null;
            //bullet.transform.position = transform.position;
            bullet.GetComponent<BaseBullet>().changeDir(currentFacing);
            lastShootTime = Time.time;

            bulletRb.velocity = currentFacing * bulletSpeed;
        }
        if (Input.GetKey(shootKey) == false)
        {
            anim.SetBool("Attacking", false);
        }
    }

    public void SetID(int ID){
        playId = ID;
    }
    
    public GameObject GetSpell(){
        return spell; 
    }

    public bool GetSpellDamage(float damage)
    {
        health -= damage;
        StartCoroutine(DamageAnimation());
        if (health <= 0)
        {
            Destroy(GetComponent<NavHelper>().avatar);
            Destroy(gameObject);
            return true;
        }
        return false;

    }


    private IEnumerator DamageAnimation()
    {
        Color color = GetComponent<SpriteRenderer>().color;
        GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, 0.7f);
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = color;
    }
}
