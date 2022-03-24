using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Behaviour h = (Behaviour) GetComponent("Halo");
        h.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)  //Plays Sound Whenever collision detected
     {
         Debug.Log(collision.gameObject.name);
         if(collision.gameObject.name == "Player")
         {
             
         }
     }
}
