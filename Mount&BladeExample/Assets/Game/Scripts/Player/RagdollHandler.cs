
using UnityEngine;
using UnityEngine.Events;

public class RagdollHandler : MonoBehaviour
{
    private Rigidbody[] rigidbodies;


    private void Start()
    {
        rigidbodies = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = true;
        }
    }

    
    public void RagdollON()
    {
        foreach (Rigidbody rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = false;
            GetComponent<Animator>().enabled = false;
            GetComponent<CapsuleCollider>().enabled = false;
            GetComponent<SphereCollider>().enabled = false;
        }
    }
}
