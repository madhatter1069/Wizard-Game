using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Spell : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject spell;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        spell = player.GetComponent<Player>().GetSpell();
        gameObject.GetComponent<Image>().sprite = spell.GetComponent<SpriteRenderer> ().sprite;
    }

    public void SetPlay(GameObject playr){
        player = playr;
    }

}
