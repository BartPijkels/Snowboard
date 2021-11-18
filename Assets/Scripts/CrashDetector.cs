using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float dieDelay = 1f;
    [SerializeField] ParticleSystem deathEffect;
    [SerializeField] AudioClip deathSFX;

    
    CircleCollider2D playerHead;

    bool hasCrashed = false;

    void Start()
    {
        playerHead = GetComponent<CircleCollider2D>();
    }
   
   void OnCollisionEnter2D(Collision2D other) 
   {
      if(other.gameObject.tag == "Ground" && playerHead.IsTouching(other.collider) && !hasCrashed)
      {
          hasCrashed = true;
          FindObjectOfType<PlayerController>().DisableControls();
          deathEffect.Play();
          GetComponent<AudioSource>().PlayOneShot(deathSFX);
          Invoke("ReloadScene", dieDelay);
      }
   }

   void ReloadScene()
   {
       SceneManager.LoadScene(0);
   }
}
