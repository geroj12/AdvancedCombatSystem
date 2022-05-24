using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HandleEnemyHurtbox : MonoBehaviour
{
    public Animator enemyAnim;
    public bool LeftArmGetsHit, RightArmGetsHit, BodyGetsHit, HeadGetsHit = false;

    private BoxCollider[] boxColliders;

    IEnumerator DeactivateDirectionBools()
    {
        yield return new WaitForSeconds(0.5f);
        enemyAnim.SetBool("leftArmGetHit", false);
        LeftArmGetsHit = false;
        enemyAnim.SetBool("rightArmGetHit", false);
        RightArmGetsHit = false;
        enemyAnim.SetBool("bodyGetHit", false);
        BodyGetsHit = false;
        enemyAnim.SetBool("headHit", false);
        HeadGetsHit = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SwordCollider"))
        {
            boxColliders = GetComponentsInChildren<BoxCollider>();
            foreach (BoxCollider boxCollider in boxColliders)
            {
                if (boxCollider.CompareTag("LeftArmEnemyCollider"))
                {
                    LeftArmGetsHit = true;
                    if (LeftArmGetsHit == true)
                    {
                        enemyAnim.SetBool("leftArmGetHit", true);
                        StartCoroutine(DeactivateDirectionBools());
                    }
                }

                if (boxCollider.CompareTag("RightArmEnemyCollider"))
                {
                    RightArmGetsHit = true;
                    if (RightArmGetsHit == true)
                    {
                        enemyAnim.SetBool("rightArmGetHit", true);
                        StartCoroutine(DeactivateDirectionBools());
                    }
                }

                if (boxCollider.CompareTag("BodyEnemyCollider"))
                {
                    BodyGetsHit = true;
                    if (BodyGetsHit == true)
                    {
                        enemyAnim.SetBool("bodyGetHit", true);
                        StartCoroutine(DeactivateDirectionBools());
                    }
                }

                if (boxCollider.CompareTag("HeadEnemyCollider"))
                {
                    HeadGetsHit = true;
                    if (HeadGetsHit == true)
                    {
                        enemyAnim.SetBool("headHit", true);
                        StartCoroutine(DeactivateDirectionBools());
                    }
                }
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("SwordCollider"))
        {
            StartCoroutine(DeactivateDirectionBools());
        }
    }
}
