﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("FindPlayers",0.01f);
    }
    void FindPlayers(){
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        player1 = players[0];
        player2 = players[1];
    }

    // Update is called once per frame
    void LateUpdate()
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
