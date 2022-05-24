using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForPlayer : MonoBehaviour
{
    public GameObject left, right, bottom, top;
    public GameObject playerObj;
    public Transform playerTransform;

    private void Start()
    {
        left.SetActive(false);
        right.SetActive(false);
        bottom.SetActive(false);
        top.SetActive(false);



    }
    string Direction()
    {
        string front;
        string right;
        float tolerance = 0.15f;

        if (Vector3.Dot(transform.forward, playerTransform.position - transform.position) < -tolerance) front = "Back";
        else if (Vector3.Dot(transform.forward, playerTransform.position - transform.position) > tolerance) front = "Front";
        else front = "Center";

        if (Vector3.Dot(transform.right, playerTransform.position - transform.position) < -tolerance) right = "Left";
        else if (Vector3.Dot(transform.right, playerTransform.position - transform.position) > tolerance) right = "Right";
        else right = "Center";


        print(front + right);
        //if (front.Equals("Front") && right.Equals("Left"))
        //{
        //    LeftArmGetsHit = true;
        //}
        return front + right;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject playerTrans = GameObject.FindGameObjectWithTag("Player");
            playerTransform = playerTrans.gameObject.transform;
        }     
    }

   
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerObj = GameObject.FindGameObjectWithTag("Player");
            Direction();
            if (playerObj.GetComponent<Player>().mouseOnLeftSide == true)
            {
                left.SetActive(false);
                right.SetActive(true);
                bottom.SetActive(false);
                top.SetActive(false);

            }
            if (playerObj.GetComponent<Player>().mouseOnRightSide == true)
            {
                left.SetActive(true);
                right.SetActive(false);
                bottom.SetActive(false);
                top.SetActive(false);
            }
            if (playerObj.GetComponent<Player>().mouseOnDownSide == true)
            {
                left.SetActive(false);
                right.SetActive(false);
                bottom.SetActive(true);
                top.SetActive(false);
            }
            if (playerObj.GetComponent<Player>().mouseOnTopSide == true)
            {
                left.SetActive(false);
                right.SetActive(false);
                bottom.SetActive(false);
                top.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {         
            left.SetActive(false);
            right.SetActive(false);
            bottom.SetActive(false);
            top.SetActive(false);
            playerTransform = null;
            playerObj = null;
        }
    }
}
