using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("FindPlayers",0.1f);
    }
    void FindPlayers(){
        object[] obj = GameObject.FindObjectsOfType<GameObject>();
        foreach (object o in obj)
        {
            GameObject g = (GameObject) o;
            if (g.name == "player1"){
                player1 = g;
            }
            if (g.name == "player2"){
                player2 = g;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        MoveCam();
    }

    void MoveCam(){
        float size = gameObject.GetComponent<Camera>().orthographicSize;
        float height = 2.0f * size;
        float width = height * gameObject.GetComponent<Camera>().aspect;
        Camera cam = Camera.main;
        
        if(player1.transform.position.x > gameObject.transform.position.x + size){
            gameObject.transform.Translate(16f,0,0);
            player2.transform.position = player1.transform.position;
        }
        if(player2.transform.position.x > gameObject.transform.position.x + size){
            gameObject.transform.Translate(16f,0,0);
            player1.transform.position = player2.transform.position;
        }
        if(player1.transform.position.y > (gameObject.transform.position.y + size)){
            gameObject.transform.Translate(0,16f,0);
            player2.transform.position = player1.transform.position;
        }
        if(player2.transform.position.y > gameObject.transform.position.y + size){
            gameObject.transform.Translate(0,16f,0);
            player1.transform.position = player2.transform.position;
        }

        if(player1.transform.position.x < gameObject.transform.position.x - size){
            gameObject.transform.Translate(-16f,0,0);
            player2.transform.position = player1.transform.position;
        }
        if(player2.transform.position.x < gameObject.transform.position.x - size){
            gameObject.transform.Translate(-16f,0,0);
            player1.transform.position = player2.transform.position;
        }
        if(player1.transform.position.y < (gameObject.transform.position.y - size)){
            gameObject.transform.Translate(0,-16f,0);
            player2.transform.position = player1.transform.position;
        }
        if(player2.transform.position.y < gameObject.transform.position.y - size){
            gameObject.transform.Translate(0,-16f,0);
            player1.transform.position = player2.transform.position;
        }
        
    }
}
