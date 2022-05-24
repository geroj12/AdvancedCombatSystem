using UnityEngine;
using UnityEngine.Events;
using Cinemachine;

public class FinisherCutscene : MonoBehaviour
{
    private GameObject Cinemachine;
    [SerializeField] private Transform killCamTransform;
    [SerializeField] private GameObject killCamObj;
    [SerializeField] private Transform pivot;
    [SerializeField] private CinemachineVirtualCamera killCam;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject fmodAudio;
    public bool playerEntered = false;

    public UnityEvent playerFinishInput;
    private GameObject player;

    private void Start()
    {      
        Cinemachine = GameObject.FindGameObjectWithTag("Cinemachine");
        Cinemachine.GetComponent<GameObject>();

        killCamTransform = Cinemachine.transform.GetChild(2);
        killCamObj = Cinemachine.transform.GetChild(2).gameObject;
        killCam = killCamTransform.GetChild(0).GetComponent<CinemachineVirtualCamera>();
        fmodAudio = this.transform.GetChild(3).gameObject;
    }

    private void Update()
    {       
        if (Input.GetKeyDown(KeyCode.G) && playerEntered == true)
        {
            ActivateKillCamera();
            playerFinishInput.Invoke();
            
        }


        if (GetComponent<SphereCollider>().enabled == false)
        {
            playerEntered = false;
            Destroy(fmodAudio);
        }
    }
  
    public void ActivateKillCamera()
    {
        anim.SetTrigger("finishing");
        killCamObj.SetActive(true);
        killCamTransform.position = this.transform.position;
        killCam.m_LookAt = this.pivot.transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerEntered = true;
        }
    }
   

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerEntered = false;
        }
    }
}
