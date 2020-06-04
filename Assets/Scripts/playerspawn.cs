using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerspawn : MonoBehaviour
{
    [SerializeField] private int playerID = 0;
    [SerializeField] private int characterint;
    [SerializeField] private GameObject characterlist;

    // Start is called before the first frame update
    void Start()
    {
        characterlist = transform.GetChild(0).gameObject;
        spawnplayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetPlayer(GameObject plr){
        object[] obj = GameObject.FindObjectsOfType<GameObject>();
        foreach (object o in obj)
        {
            GameObject g = (GameObject) o;
            if (g.name == "health display"){
                for (int i = 0; i < g.transform.childCount; i++)
                {
                    GameObject spellDisplay = g.transform.GetChild(i).gameObject;
                    
                    if ( spellDisplay.name == "P" + (playerID+1).ToString() + "Spell" ){
                        spellDisplay.GetComponent<Spell>().SetPlay(plr);
                    }

                }
            }
        }
    }

    public void spawnplayer(){
        GameObject player;
        characterint = PlayerPrefs.GetInt(playerID.ToString());
        player = Instantiate (characterlist.transform.GetChild(characterint).gameObject,
                    transform.position, transform.rotation);
        player.GetComponent<Player>().SetID(playerID);
        player.name = "player" + (playerID+1).ToString();
        SetPlayer(player);
    }
}
