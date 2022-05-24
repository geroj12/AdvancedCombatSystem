using UnityEngine;
using FMOD.Studio;

public class FMODPlayerSFX : MonoBehaviour
{
    private EventInstance instance;

    [SerializeField, FMODUnity.EventRef]
    private string audioArmorOnWalk;
    [SerializeField, FMODUnity.EventRef]
    private string audioSwordSwing;
    [SerializeField, FMODUnity.EventRef]
    private string audioEquipSword;
    [SerializeField, FMODUnity.EventRef]
    private string audioUnequipSword;
    [SerializeField, FMODUnity.EventRef]
    private string audioSwingingSwordMoan;
    [SerializeField, FMODUnity.EventRef]
    private string audioBlockSwordImpact;
    [SerializeField, FMODUnity.EventRef]
    private string audioArmorHit;
    [SerializeField, FMODUnity.EventRef]
    private string audioSwordBodySlash;

    public void PlayArmorWalkAudio()
    {
        instance = FMODUnity.RuntimeManager.CreateInstance(audioArmorOnWalk);
        instance.start();
    }

    public void PlaySwordSwingAudio()
    {
        instance = FMODUnity.RuntimeManager.CreateInstance(audioSwordSwing);
        instance.start();
    }
    public void PlayEquipSwordAudio()
    {
        instance = FMODUnity.RuntimeManager.CreateInstance(audioEquipSword);
        instance.start();
    }
    public void PlayUnequipSwordAudio()
    {
        instance = FMODUnity.RuntimeManager.CreateInstance(audioUnequipSword);
        instance.start();
    }
    public void PlaySwingSwordMoanAudio()
    {
        instance = FMODUnity.RuntimeManager.CreateInstance(audioSwingingSwordMoan);
        instance.start();
    }
    public void PlayBlockImpactSwordAudio()
    {
        instance = FMODUnity.RuntimeManager.CreateInstance(audioBlockSwordImpact);
        instance.start();
    }
    public void PlayOnArmorHitAudio()
    {
        instance = FMODUnity.RuntimeManager.CreateInstance(audioArmorHit);
        instance.start();
    }

    public void PlayOnBodySwordSlash()
    {
        instance = FMODUnity.RuntimeManager.CreateInstance(audioSwordBodySlash);
        instance.start();
    }

    private void OnDestroy()
    {
        instance.release();
    }
}
