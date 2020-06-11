using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderDoor : MonoBehaviour
{
    [SerializeField] private GameObject enemyList;
    [SerializeField] private string doorDirection;
    [SerializeField] private GameObject directionArrow;


    void Start()
    {
        
    }


    void FixedUpdate()
    {
        if (enemyList)
        {
            if (enemyList.transform.childCount == 0)
            {
                Destroy(enemyList.gameObject);
                ShowArrow();
            }
        }
        else if (!enemyList || enemyList == null)
        {
            Destroy(enemyList.gameObject);
            ShowArrow();
        }
    }

    private void ShowArrow()
    {
        if (doorDirection == "up")
        {
            Vector3 directionArrowPos = new Vector3(transform.position.x, (transform.position.y - 1.5f), transform.position.z);
            GameObject dirArrow = Instantiate(directionArrow, directionArrowPos, new Quaternion(0, 0, 0, 0));
            Destroy(gameObject);
        }
        if (doorDirection == "down")
        {
            Vector3 directionArrowPos = new Vector3(transform.position.x, (transform.position.y + 1.5f), transform.position.z);
            GameObject dirArrow = Instantiate(directionArrow, directionArrowPos, new Quaternion(0, 0, 0, 0));
            Destroy(gameObject);
        }
        if (doorDirection == "left")
        {
            Vector3 directionArrowPos = new Vector3((transform.position.x + 1.5f), transform.position.y, transform.position.z);
            GameObject dirArrow = Instantiate(directionArrow, directionArrowPos, new Quaternion(0, 0, 0, 0));
            Destroy(gameObject);
        }
        if (doorDirection == "right")
        {
            Vector3 directionArrowPos = new Vector3((transform.position.x - 1.5f), transform.position.y, transform.position.z);
            GameObject dirArrow = Instantiate(directionArrow, directionArrowPos, new Quaternion(0, 0, 0, 0));
            Destroy(gameObject);
        }
    }
}
