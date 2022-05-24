using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimHookEnemy : MonoBehaviour
{
    [SerializeField] private FMODEnemySFX fmodEnemySFX;
   
    public void AudioOnDeath()
    {
        fmodEnemySFX.PlayZombieDyingAudio();
    }

    public void OnArmorHit()
    {
        fmodEnemySFX.PlayerZombieHitAudio();
    }
   
}
