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
	rb = GetComponent<Rigidbody2D>();
	// get the references to your audio sources here !        
    }

    // FixedUpdate is called whenever the physics engine updates
    void FixedUpdate()
    {
	    float v = rb.velocity.magnitude;
    if (v > 1 && !isMoving){
    movementsource.Play();
    isMoving = true;
}
    else if(v < 1 && isMoving){
    movementsource.Stop();
    isMoving = false;
}
    while (isJumping == true){
        movementsource.Stop();
    }
//else (!isJumping){
   // movementsource.Stop();
    //}
    }
    
    // trigger your landing sound here !
    public void OnLanding() {
        landsource.Play();
         isJumping = false;
        print("the fox has landed");
	// to keep things cleaner, you might want to
	// play this sound only when the fox actually jumoed ...
    }

    // trigger your crouching sound here
    public void OnCrouching() {
        crouchsource.Play();
        print("the fox is crouching");
    }
 
    // trigger your jumping sound here !
    public void OnJump() {
        jumpsource.Play();
    isJumping = true;
      print("the fox has jumped");
}
   
    // trigger your cherry collection sound here !
    public void OnCherryCollect() {
        cherrycollectsource.Play();
        print("the fox has collected a cherry");
    }
}
