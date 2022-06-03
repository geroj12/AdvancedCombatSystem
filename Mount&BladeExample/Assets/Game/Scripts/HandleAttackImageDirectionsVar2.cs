using UnityEngine;

public class HandleAttackImageDirectionsVar2 : MonoBehaviour
{  
    float decTimer;
    [SerializeField] private GameObject rechtsImg, linksImg, topImg, mid, block;
    [SerializeField] private Player player;

    private void Update()
    {
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
                if (Input.GetMouseButton(0))
                {
                    if (Input.GetAxis("Mouse X") < 0 && Input.GetAxis("Mouse Y") < 0.15f && Input.GetAxis("Mouse Y") > -0.15f) //<0.15 und >-0.15 ist der 15° winkel wo es noch als left zählt
                    {
                        rechtsImg.SetActive(false);
                        linksImg.SetActive(true);
                        topImg.SetActive(false);
                        mid.SetActive(false);
                        
                        player.mouseOnLeftSide = true;
                        player.mouseOnTopSide = player.mouseOnDownSide = player.mouseOnRightSide = false;

                    }
                    else if (Input.GetAxis("Mouse X") > 0 && Input.GetAxis("Mouse Y") < 0.15f && Input.GetAxis("Mouse Y") > -0.15f)
                    {
                        rechtsImg.SetActive(true);
                        linksImg.SetActive(false);
                        topImg.SetActive(false);
                        mid.SetActive(false);

                        
                        player.mouseOnRightSide = true;
                        player.mouseOnDownSide = player.mouseOnTopSide = player.mouseOnLeftSide = false;

                    }
                    else if (Input.GetAxis("Mouse Y") > 0 && Input.GetAxis("Mouse X") < 0.15f && Input.GetAxis("Mouse X") > -0.15f)
                    {
                        rechtsImg.SetActive(false);
                        linksImg.SetActive(false);
                        topImg.SetActive(true);
                        mid.SetActive(false);

                       player.mouseOnTopSide = true;
                       player.mouseOnDownSide = player.mouseOnLeftSide = player.mouseOnRightSide = false;
                    }
                    else if (Input.GetAxis("Mouse Y") < 0 && Input.GetAxis("Mouse X") < 0.15f && Input.GetAxis("Mouse X") > -0.15f)
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
        }
        else
        {
            DeactivateAttackDirectionImages();
        }
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
