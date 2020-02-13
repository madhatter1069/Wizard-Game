using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    public GameObject confirm;
    public GameObject selectchar;

    private void Start(){
        //characterList = new GameObject [4];
        /*int index = 0;
        for (int i = 0; i<transform.childCount; ++i){
            if (transform.GetChild(i).gameObject.tag == "characterSelect"){
                characterList[index] = (transform.GetChild(i).GetChild(1).gameObject);
                index++;
            }
        }*/
        //player1 = characterList[PlayerPrefs.GetInt("Player1")];
        //player2 = characterList[PlayerPrefs.GetInt("Player2")];
    }

    public void PlayGame(){
        //SceneManager.LoadScene("SampleScene");
        SceneManager.LoadScene("ManuallyGeneratedLevel1");
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
