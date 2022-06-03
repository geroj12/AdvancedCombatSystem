using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleAttackImageDirectionsVar3 : MonoBehaviour
{
    float decTimer;
    [SerializeField] private GameObject rechtsImg, linksImg, topImg, mid, block;
    [SerializeField] private Player player;

    public bool swipeLeft, swipeRight, swipeUp, swipeDown;
    private bool isDraging = false;
    private Vector2 startTouch, swipeDelta;

    private void Update()
    {
        swipeDown = swipeUp = swipeLeft = swipeRight = false;
        
        if (player.groundCheck.isGrounded)
        {
            Blocking();
        }
    }

    private void FixedUpdate()
    {
        DirectionImages();
    }

    public void DirectionImages()
    {
        float X = Input.GetAxis("Mouse X");
        float Y = Input.GetAxis("Mouse Y");


        if (player.Strafe == true)
        {
            if (player.blocking == false)
            {

                if (Input.GetMouseButtonDown(0))
                {
                    isDraging = true;
                    startTouch = Input.mousePosition;
                }
                else if (Input.GetMouseButtonUp(0))
                {                                                       
                    isDraging = false;
                    Reset();
                }

                swipeDelta = Vector2.zero;
                if (isDraging)
                {
                    if (Input.GetMouseButton(0))
                    {
                        swipeDelta = (Vector2)Input.mousePosition - startTouch;
                    }
                }

                if (swipeDelta.magnitude > 65)
                {
                    float x = swipeDelta.x;
                    float y = swipeDelta.y;
                    if (Mathf.Abs(x) > Mathf.Abs(y))
                    {
                        if (x < 0)
                        {
                            swipeLeft = true;
                        }
                        else
                        {
                            swipeRight = true;
                        }
                    }
                    else
                    {
                        if (y < 0)
                        {
                            swipeDown = true;
                        }
                        else
                        {
                            swipeUp = true;
                        }
                        Reset();
                    }
                }

                if (swipeRight)
                {
                    rechtsImg.SetActive(true);
                    linksImg.SetActive(false);
                    topImg.SetActive(false);
                    mid.SetActive(false);

                    player.mouseOnLeftSide = true;
                    player.mouseOnTopSide = player.mouseOnDownSide = player.mouseOnRightSide = false;
                   
                }

                if (swipeLeft)
                {
                    rechtsImg.SetActive(false);
                    linksImg.SetActive(true);
                    topImg.SetActive(false);
                    mid.SetActive(false);

                    player.mouseOnRightSide = true;
                    player.mouseOnDownSide = player.mouseOnTopSide = player.mouseOnLeftSide = false;

                }

                if (swipeUp)
                {
                    rechtsImg.SetActive(false);
                    linksImg.SetActive(false);
                    topImg.SetActive(true);
                    mid.SetActive(false);

                    player.mouseOnTopSide = true;
                    player.mouseOnDownSide = player.mouseOnLeftSide = player.mouseOnRightSide = false;
                }

                if (swipeDown)
                {
                    rechtsImg.SetActive(false);
                    linksImg.SetActive(false);
                    topImg.SetActive(false);
                    mid.SetActive(true);

                    player.mouseOnDownSide = true;
                    player.mouseOnLeftSide = player.mouseOnTopSide = player.mouseOnRightSide = false;
                }
            }
        }
        else
        {
            DeactivateAttackDirectionImages();
        }
    }

    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDraging = false;
    }

    void Blocking()
    {
        float mouseRB = Input.GetAxis("Fire2");
        if (player.equiped == true)
        {
            if (mouseRB > 0.1f)
            {
                decTimer += Time.deltaTime;
                if (decTimer > .5f)
                {
                    DeactivateAttackDirectionImages();
                    player.anim.SetBool("Block", true);
                    player.hurtBoxPlayer.GetComponent<BoxCollider>().enabled = false;
                    player.blocking = true;
                    block.SetActive(true);
                    player.BlockCollider.GetComponent<BoxCollider>().enabled = true;
                    decTimer = 0;
                }
            }
            else
            {
                player.anim.SetBool("Block", false);
                player.hurtBoxPlayer.GetComponent<BoxCollider>().enabled = true;
                player.blocking = false;
                block.SetActive(false);
                player.BlockCollider.GetComponent<BoxCollider>().enabled = false;
            }
        }
    }

    public void DeactivateAttackDirectionImages()
    {
        rechtsImg.SetActive(false);
        linksImg.SetActive(false);
        topImg.SetActive(false);
        mid.SetActive(false);
    }
}
