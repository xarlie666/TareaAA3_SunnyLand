using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{
    AudioSource [] allSources;
    AudioSource jumpsource;
    AudioSource landsource;
    AudioSource crouchsource;
    AudioSource cherrycollectsource;
    AudioSource movementsource;
    //AudioSource woodimpactsource;
    // keep track of the jumping state ... 
    bool isJumping = false;
    bool isMoving = false;
  
    Rigidbody2D rb; // note the "2D" prefix 
    
    // Start is called before the first frame update
    void Start()
    {
        allSources = GetComponents<AudioSource>();
        jumpsource = allSources[0];
        landsource = allSources[1];
        crouchsource = allSources[2];
        cherrycollectsource = allSources[3];
        movementsource = allSources[4];
      //  woodimpactsource = allSources[5];
	rb = GetComponent<Rigidbody2D>();
    
    }

    // FixedUpdate is called whenever the physics engine updates
    void FixedUpdate()
    {
	    float v = rb.velocity.magnitude;
   
   if(v > 1 && !isMoving && !isJumping){
          movementsource.Play();
        isMoving = true;
        }
    if(v < 1 && isMoving  && !isJumping){
    movementsource.Stop();
           isMoving = false;
        }   
        
   }
   

    
    // trigger your landing sound here !
    public void OnLanding() {
     
        landsource.Play();
       
         movementsource.Stop();
         isJumping = false;
        print("the fox has landed");
	
    }

    // trigger your crouching sound here
    public void OnCrouching() {
        crouchsource.Play();
        
        print("the fox is crouching");
    }
 
    // trigger your jumping sound here !
    public void OnJump() {
      
        jumpsource.Play();
        
       movementsource.Stop();
       isJumping = true;
      print("the fox has jumped");
    }

   
    // trigger your cherry collection sound here !
    public void OnCherryCollect() {
        cherrycollectsource.Play();
   
        print("the fox has collected a cherry");
    }
    //public void OnCollisionEnter2D
}
