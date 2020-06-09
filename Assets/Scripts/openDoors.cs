using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class openDoors : MonoBehaviour
{
    public GameObject EnemyList;
    [SerializeField] private Image DirArrow;
    public float timer;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(EnemyList){
            if (EnemyList.transform.childCount == 0){
                Destroy(EnemyList.gameObject);
                ShowArrow();
            }
        }
        else if(!EnemyList || EnemyList == null)
        {
            Destroy(EnemyList.gameObject);
            ShowArrow();
        }
    }

    public void ShowArrow(){
       StartCoroutine(ShoArrow());
    }

    IEnumerator ShoArrow(){
        DirArrow.GetComponent<Image>().enabled = true;
        yield return new WaitForSeconds(timer);
        DirArrow.GetComponent<Image>().enabled = false;
        Destroy(gameObject);
    }
}
