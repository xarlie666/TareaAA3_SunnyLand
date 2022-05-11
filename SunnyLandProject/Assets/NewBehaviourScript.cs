using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    AudioSource[] allSources;
    AudioSource impactsource;
    AudioSource movesource;

    bool isSliding = false;
    Rigidbody2D rb;
   
    // Start is called before the first frame update
    void Start()
    {
        allSources = GetComponents<AudioSource>();
        impactsource = allSources[0];
        movesource = allSources[1];

        rb = GetComponent<Rigidbody2D>();
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        impactsource.Play();
        movesource.Play();
        
    }

    void FixedUpdate()
    {
	
   float v = rb.velocity.magnitude;
   if( v>1 && !isSliding ){
          movesource.Play();
        isSliding = true;
        }
    if(v<1 && isSliding ){
        movesource.Stop();
           isSliding = false;
        }   
        
   }
}
//'UnityEngine.Rigidbody2D[]' 