using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class openDoors : MonoBehaviour
{
    public GameObject EnemyList;
    [SerializeField] private Image DirArrow;
    public float timer;
    [SerializeField] private string doorDirection;
    [SerializeField] private GameObject directionArrow;
    
    // Start is called before the first frame update
    void Start()
    {
        DirArrow.GetComponent<Image>().enabled = false;
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

        if (doorDirection == "up")
        {
            Vector3 directionArrowPos = new Vector3(transform.position.x, (transform.position.y - 1f), transform.position.z);
            GameObject dirArrow = Instantiate(directionArrow, directionArrowPos, new Quaternion(0, 0, 0, 0));
            Destroy(gameObject);
        }
        if (doorDirection == "down")
        {
            Vector3 directionArrowPos = new Vector3(transform.position.x, (transform.position.y + 1f), transform.position.z);
            GameObject dirArrow = Instantiate(directionArrow, directionArrowPos, new Quaternion(0, 0, 0, 0));
            Destroy(gameObject);
        }
        if (doorDirection == "left")
        {
            Vector3 directionArrowPos = new Vector3((transform.position.x + 1f), transform.position.y, transform.position.z);
            GameObject dirArrow = Instantiate(directionArrow, directionArrowPos, new Quaternion(0, 0, 0, 0));
            Destroy(gameObject);
        }
        if (doorDirection == "right")
        {
            Vector3 directionArrowPos = new Vector3((transform.position.x - 1f), transform.position.y, transform.position.z);
            GameObject dirArrow = Instantiate(directionArrow, directionArrowPos, new Quaternion(0, 0, 0, 0));
            Destroy(gameObject);
        }

        //StartCoroutine(ShoArrow());
    }

    IEnumerator ShoArrow(){
        DirArrow.GetComponent<Image>().enabled = true;
        yield return new WaitForSeconds(timer);
        DirArrow.GetComponent<Image>().enabled = false;
        Destroy(gameObject);
    }
}
