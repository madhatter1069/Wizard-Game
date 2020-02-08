using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    public GameObject confirm;
    public GameObject selectchar;


    public void PlayGame(){
        SceneManager.LoadScene("SampleScene");

    }

    public void PickFirstPlayer(int ind){
        PlayerPrefs.SetInt("0", ind);

    }
    public void PickSecondPlayer(int ind){
        PlayerPrefs.SetInt("1", ind);
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
