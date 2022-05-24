using UnityEngine;
using FMOD.Studio;

public class FMODFootsteps : MonoBehaviour
{
    private EventInstance instance;

    [SerializeField, FMODUnity.EventRef]
    private string audioPath;

    [SerializeField] private GroundCheck detectGround;
   

    [SerializeField]
    private float duration;
    private float timer = 0.0f;

    private void Update()
    {
        if (timer > duration)
        {
            timer = 0.0f;
        }
        timer += Time.deltaTime;
    }

    public void PlayFootstepWalkAudio()
    {
       
            instance = FMODUnity.RuntimeManager.CreateInstance(audioPath);
            instance.setParameterByName("Terrain", (int)detectGround.currentTerrain);
            instance.start();
    }

    private void OnDestroy()
    {
        instance.release();
    }
}
