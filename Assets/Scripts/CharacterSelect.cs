using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    public GameObject confirm;
    public GameObject selectchar;

    private void Start(){
        
    }

    public void PlayGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlayAlone(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PickFirstPlayer(int ind){
        PlayerPrefs.SetInt("0", ind);

    }

    public void SinglePlayer(){
        PlayerPrefs.SetInt("3", 1);
    }

    public void PickSecondPlayer(int ind){
        PlayerPrefs.SetInt("1", ind);
        PlayerPrefs.SetInt("3", 0);
        if (PlayerPrefs.GetInt("0") == PlayerPrefs.GetInt("1")){
            confirm.SetActive(false);
            selectchar.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("0") != PlayerPrefs.GetInt("1")){
            confirm.SetActive(true);
            selectchar.SetActive(false);
        }

    }

}
