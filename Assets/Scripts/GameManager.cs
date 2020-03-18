using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject Doors;
    [SerializeField] private GameObject win;
    [SerializeField] private GameObject lose;
    public int p1health;
    public int p2health;
    // Start is called before the first frame update
    void Start()
    {
        p1health = 1;
        p2health = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Doors.transform.childCount == 0){
            win.SetActive(true);
            StartCoroutine(QuitGame());
        }
        if (p1health == 0 && p2health == 0){
            lose.SetActive(true);
            StartCoroutine(QuitGame());
        }
    }
    private IEnumerator QuitGame(){
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(0);
    }
}
