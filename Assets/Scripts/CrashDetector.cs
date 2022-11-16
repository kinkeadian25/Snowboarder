using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float sceneDelay = 1f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashFX;
    private bool groundFX = true;
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Ground" && groundFX)
        {
            FindObjectOfType<PlayerController>().DisableControls();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashFX);
            Invoke("ReloadScene", sceneDelay);
            groundFX = false;
        }      
    }
    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    } 
}
