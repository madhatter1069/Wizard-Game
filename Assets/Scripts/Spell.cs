using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Spell : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private int ID = 1;
    [SerializeField] private GameObject spell;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetPlayer());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        StartCoroutine(wait());
        spell = player.GetComponent<Player>().GetSpell();
        gameObject.GetComponent<Image>().sprite = spell.GetComponent<SpriteRenderer> ().sprite;
    }

    IEnumerator GetPlayer(){
        yield return new WaitForSeconds(.1f);
        object[] obj = GameObject.FindObjectsOfType<GameObject>();
        foreach (object o in obj)
        {
            GameObject g = (GameObject) o;
            if (g.name == "player" + ID.ToString()){
                player = g;
            }
        }
    }

    IEnumerator wait(){
        yield return new WaitForSeconds(.2f);
    }

}
