using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class SoundControler : MonoBehaviour
{
    [SerializeField] private AudioSource playerFootSteps;
    [SerializeField] private AudioSource shoot_Sound;
    [SerializeField] private AudioSource enemySound;
    [SerializeField] private AudioSource questComplet;
    
    private void Awake()
    {
        playerFootSteps = GetComponent<AudioSource>();
        shoot_Sound = GetComponent<AudioSource>();
        enemySound = GetComponent<AudioSource>();
    }


    public void SoundPlayFootSteps() => playerFootSteps.Play();
    public void SoundShoot() => shoot_Sound.Play();
    public void enemySoundEffect() => enemySound.Play();
    public void Sound_QuestComplet() => questComplet.Play();

}
