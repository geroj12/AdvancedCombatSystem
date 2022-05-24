using UnityEngine;
using FMOD.Studio;

public class FMODEnemySFX : MonoBehaviour
{
    private EventInstance instance;


    [SerializeField, FMODUnity.EventRef]
    private string audioZombieDying;

    [SerializeField, FMODUnity.EventRef]
    private string audioZombieGettingHit;

    public void PlayZombieDyingAudio()
    {
        instance = FMODUnity.RuntimeManager.CreateInstance(audioZombieDying);
        instance.start();
    }

    public void PlayerZombieHitAudio()
    {
        instance = FMODUnity.RuntimeManager.CreateInstance(audioZombieGettingHit);
        instance.start();

    }

    private void OnDestroy()
    {
        instance.release();
    }
}
