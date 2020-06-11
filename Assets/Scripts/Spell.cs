using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Spell : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject spell;

    public GameObject basic;
    public GameObject fire;
    public GameObject ice;
    public GameObject electric;
    public GameObject earth;
    public GameObject chaos;

    public Sprite basicUI;
    public Sprite fireUI;
    public Sprite iceUI;
    public Sprite electricUI;
    public Sprite earthUI;
    public Sprite chaosUI;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player != null){
            spell = player.GetComponent<Player>().GetSpell();

            if (spell == basic)
            {
                gameObject.GetComponent<Image>().sprite = basicUI;
            }
            else if (spell == fire)
            {
                gameObject.GetComponent<Image>().sprite = fireUI;
            }
            else if (spell == ice)
            {
                gameObject.GetComponent<Image>().sprite = iceUI;
            }
            else if (spell == electric)
            {
                gameObject.GetComponent<Image>().sprite = electricUI;
            }
            else if (spell == earth)
            {
                gameObject.GetComponent<Image>().sprite = earthUI;
            }
            else if (spell == chaos)
            {
                gameObject.GetComponent<Image>().sprite = chaosUI;
            }


            //gameObject.GetComponent<Image>().sprite = spell.GetComponent<SpriteRenderer> ().sprite;
        }
    }

    public void SetPlay(GameObject playr){
        player = playr;
    }

}
