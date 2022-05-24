using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimHook : MonoBehaviour
{
    [SerializeField] private FMODFootsteps fmodFootstepsAudio;
    [SerializeField] private FMODPlayerSFX fmodPlayerSFX;
    [SerializeField] private GameObject damageCollider;

    public void AudioOnFootStep()
    {
        fmodFootstepsAudio.PlayFootstepWalkAudio();
    }

    public void AudioArmorOnWalking()
    {
        fmodPlayerSFX.PlayArmorWalkAudio();
    }

    public void AudioOnSwordSwing()
    {
        fmodPlayerSFX.PlaySwordSwingAudio();
    }

    public void EquipSword()
    {
        fmodPlayerSFX.PlayEquipSwordAudio();
    }

    public void UnequipSword()
    {
        fmodPlayerSFX.PlayUnequipSwordAudio();
    }

    public void SwordSwingingMoan()
    {
        fmodPlayerSFX.PlaySwingSwordMoanAudio();
    }
    public void BlockImpact()
    {
        fmodPlayerSFX.PlayBlockImpactSwordAudio();
    }

    public void OnArmorHit()
    {
        fmodPlayerSFX.PlayOnArmorHitAudio();
    }

    public void OnSwordBodySlash()
    {
        fmodPlayerSFX.PlayOnBodySwordSlash();
    }

    public void OpenDamageCollider()
    {
        damageCollider.SetActive(true);
        StartCoroutine(DeactivateDamageCollider());

    }

    IEnumerator DeactivateDamageCollider()
    {
        yield return new WaitForSeconds(0.2f);
        damageCollider.SetActive(false);
    }

  
}

