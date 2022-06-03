using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    #region Variables    
    [Header("States")]
    public bool Strafe;
    public bool blockedAttack;
    public bool equiped = false;
    public bool blocking = false;
    public bool mouseOnLeftSide = false;
    public bool mouseOnRightSide = false;
    public bool mouseOnTopSide = false;
    public bool mouseOnDownSide = false;
    #endregion

    float inputX;
    float inputY;
    [Header("Controller Values")]
    [SerializeField] private float movementSpeed = 2f;
    [SerializeField] private float smoothValue = 0.2f;
    [SerializeField] private float mouseXSmooth = 0f;
    Vector3 Direction;
    float maxValue;
    

    #region References
    [Header("References")]
    Camera cam;
    public GameObject BlockCollider;
    public GameObject hurtBoxPlayer;
    public Animator anim;
    [SerializeField] private GameObject sword;
    [SerializeField] private GameObject swordSheelth;
    [SerializeField] private GameObject damageCollider;
    public GroundCheck groundCheck;
    [SerializeField] private HandleAttackImageDirectionsVar2 handleAttackImageDir;
    #endregion

    void Start()
    {
        cam = Camera.main;
        sword.SetActive(false);
        swordSheelth.SetActive(true);
        equiped = false;
    }

    private void Update()
    {      
        if (groundCheck.isGrounded)
        {        
            Attacking();
            Movement();         
        }
    }

    public void FinishEnemy()
    {
          anim.SetTrigger("finisher");
    }

    //private void FixedUpdate()
    //{
    //    handleAttackImageDir.DirectionImages();      
    //}

    void LateUpdate()
    {
        Equip();
        Unequip();
    }

    private void Attacking()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if (blocking == true)
        {
            mouseOnRightSide = false;
            mouseOnLeftSide = false;
            mouseOnTopSide = false;
            mouseOnDownSide = false;
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (mouseOnRightSide == true)
            {
                anim.SetBool("attackRight", true);
                StartCoroutine(AttackTimer());
            }
            if (mouseOnLeftSide == true)
            {
                anim.SetBool("attackLeft", true);
                StartCoroutine(AttackTimer());
            }
            if (mouseOnDownSide == true)
            {
                anim.SetBool("attackThrust", true);
                StartCoroutine(AttackTimer());
            }
            if (mouseOnTopSide == true)
            {
                anim.SetBool("attackUp", true);
                StartCoroutine(AttackTimer());
            }
            handleAttackImageDir.DeactivateAttackDirectionImages();
        }
    }

    void Movement()
    {
        anim.SetBool("Strafe", Strafe);
        if (Input.GetKeyDown(KeyCode.V))
        {
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

            if (Input.GetKey(KeyCode.LeftShift) && equiped == false)
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
   
   

   

   

    void Equip()
    {
        if (Input.GetKeyDown(KeyCode.E) && equiped == false)
        {
            anim.SetBool("Equip", true);
            equiped = true;
            StartCoroutine(EquipTimer());
        }
    }

    void Unequip()
    {
        if (Input.GetKeyDown(KeyCode.F) && equiped)
        {
            anim.SetBool("Unequip", true);
            StartCoroutine(UnequipTimer());
        }
    }

    #region IENumerators
    IEnumerator AttackTimer()
    {
        yield return new WaitForSeconds(1f);
        anim.SetBool("attackLeft", false);
        anim.SetBool("attackThrust", false);
        anim.SetBool("attackRight", false);
        anim.SetBool("attackUp", false);

        mouseOnRightSide = false;
        mouseOnLeftSide = false;
        mouseOnTopSide = false;
        mouseOnDownSide = false;
    }

    IEnumerator EquipTimer()
    {
        swordSheelth.SetActive(false);
        sword.SetActive(true);
        yield return new WaitForSeconds(1f);
        anim.SetBool("Equip", false);
    }

    IEnumerator UnequipTimer()
    {
        yield return new WaitForSeconds(1f);
        anim.SetBool("Unequip", false);
        sword.SetActive(false);
        swordSheelth.SetActive(true);
        equiped = false;
    }
    #endregion
}


