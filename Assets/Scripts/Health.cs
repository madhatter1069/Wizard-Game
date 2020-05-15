using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
public int health;
public int numOfHearts;
private int ID;
public int lastHeart;

public Image[] hearts;
public Sprite fullHeart;
public Sprite Heart34;
public Sprite HalfHeart;
public Sprite QuartHeart;
public Sprite emptyHeart;


    void Start(){
        health = numOfHearts*4;
        hearts = new Image [numOfHearts];
        lastHeart =numOfHearts-1;
        
        object[] obj = GameObject.FindObjectsOfType<GameObject>();
        foreach (object o in obj)
        {
            GameObject g = (GameObject) o;
            if (g.name == "health display"){
                ID = transform.GetComponent<Player>().playId;
                for (int i = 0; i < g.transform.childCount; i++)
                {
                    GameObject heartList = g.transform.GetChild(i).gameObject;
                    
                    if ( heartList.name == "P" + (ID+1).ToString() + "hearts" ){
                        for (int a = 0; a < heartList.transform.childCount; a++)
                        {
                            hearts[a] = heartList.transform.GetChild(a).gameObject.GetComponent<Image>();
                        }
                    }

                }
            }
        }
    }

    void Update()
    {
        if (health > numOfHearts*4){
            health = numOfHearts*4;
        }

        for (int i = 0; i < hearts.Length; i++){
            /*if (i< health){
                hearts[i].sprite = fullHeart;
            }
            else {
                hearts[i].sprite = emptyHeart; 
            }*/
            if(i<numOfHearts){
                hearts[i].enabled = true;
            }
            else {
                hearts[i].enabled = false; 
            }
        }
           
    }
    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.CompareTag("enemy")){
            gameObject.GetComponent<Player>().GetSpellDamage(1);
        }
    }

    public void doDamage(int damage){
        for (int i = 0; i < damage; i++)
        {
            if (health>0){
                health--;
                if (hearts[lastHeart].sprite == fullHeart){
                    hearts[lastHeart].sprite = Heart34;
                }
                else if (hearts[lastHeart].sprite == Heart34){
                    hearts[lastHeart].sprite = HalfHeart;
                }
                else if (hearts[lastHeart].sprite == HalfHeart){
                    hearts[lastHeart].sprite = QuartHeart;
                }
                else if (hearts[lastHeart].sprite == QuartHeart){
                    hearts[lastHeart].sprite = emptyHeart;
                    --lastHeart;
                }
            } 
        }
    }

    public void HealMe(int regen)
    {
        for(int i=0; i<regen; i++)
        {
            if (health<numOfHearts*4)
            {
                health++;
                if (hearts[lastHeart].sprite == fullHeart){
                    lastHeart++;
                    hearts[lastHeart].sprite = QuartHeart;
                }
                else if (hearts[lastHeart].sprite == Heart34){
                    hearts[lastHeart].sprite = fullHeart;
                }
                else if (hearts[lastHeart].sprite == HalfHeart){
                    hearts[lastHeart].sprite = Heart34;
                }
                else if (hearts[lastHeart].sprite == QuartHeart){
                    hearts[lastHeart].sprite = HalfHeart;
                }
            }
        }
    }
}