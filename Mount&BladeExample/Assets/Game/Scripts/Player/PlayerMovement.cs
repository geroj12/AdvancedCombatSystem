using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float inputX;
    float inputY;
    [SerializeField] private bool Strafe;
    Camera cam;
    [SerializeField] private float movementSpeed = 2f;
    [SerializeField] private float smoothValue = 0.2f;
    [SerializeField] private Animator anim;
    [SerializeField] private Player player;
    Vector3 Direction;
    float maxValue;
    [SerializeField] private GroundCheck groundCheck;


    private void Start()
    {
        cam = Camera.main;

    }

    private void Update()
    {
        if (groundCheck.isGrounded)
        {
            Movement();
        }
    }
    void Movement()
    {
        anim.SetBool("Strafe", Strafe);
        if (Input.GetKeyDown(KeyCode.V))
        {
            //anim.SetLayerWeight(anim.GetLayerIndex("Attacks"), 1f);
            if (Strafe)
            {
                Strafe = false;

            }
            else
            {
                Strafe = true;

            }
        }
        if (Strafe == true)
        {
            inputX = Input.GetAxis("Horizontal");
            inputY = Input.GetAxis("Vertical");

            float CamRot = cam.transform.rotation.eulerAngles.y;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, CamRot, 0), 4f * Time.deltaTime);

            anim.SetFloat("InputX", inputX);
            anim.SetFloat("InputY", inputY);
        }
        else
        {

            if (Input.GetKey(KeyCode.LeftShift) && player.equiped == false)
            {
                maxValue = 2;
                inputX = Input.GetAxis("Horizontal") * 2f;
                inputY = Input.GetAxis("Vertical") * 2f;
            }
            else
            {
                maxValue = 1;
                inputX = Input.GetAxis("Horizontal");
                inputY = Input.GetAxis("Vertical");
            }

            Direction = new Vector3(inputX, 0, inputY);

            anim.SetFloat("Locomotion", Vector3.ClampMagnitude(Direction, maxValue).magnitude, smoothValue, Time.deltaTime);
            Vector3 Rot = cam.transform.TransformDirection(Direction);
            Rot.y = 0;

            transform.forward = Vector3.Slerp(transform.forward, Rot, Time.deltaTime * movementSpeed);
        }
    }
}
