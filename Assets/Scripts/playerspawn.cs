using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerspawn : MonoBehaviour
{
    [SerializeField] private int playerID;
    [SerializeField] private int characterint;
    [SerializeField] private GameObject characterlist;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player;
        characterint = PlayerPrefs.GetInt(playerID.ToString());
        player = Instantiate (characterlist.transform.GetChild(characterint).gameObject,
                    transform.position, transform.rotation);
        player.GetComponent<Player>().SetID(playerID);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
