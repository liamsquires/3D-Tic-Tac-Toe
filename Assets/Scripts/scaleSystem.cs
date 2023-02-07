using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleSystem : MonoBehaviour
{

    static public float scaleFactor = 1.5f;
    
    bool zoomedOut = globals.zoomedOut;
    void Update()
    {
        /*
        
        zoomedOut = binary
        scaleFactor = ~1.6

        If mouse if scrolled out and zoomedOut ~= true then
         zoomedOut = true
         
         Everything with leg tag scales z by 2, all pos value multiplied by 2

         Everything with box tag gets pos moved

         Everything with piece tag gets pos moved

         end

         Vice versa for shrinking again.

        If changed to true, multiply */
       

        if (Input.GetAxis("Mouse ScrollWheel") > 0f && zoomedOut == false) //forward
        {

            zoomedOut = true;
            globals.zoomedOut = true;

            if (gameObject.tag == "Grid leg")
            {
                transform.localScale *= scaleFactor;
            }

            /* if (gameObject.tag == "Piece")
            {
                transform.position *= scaleFactor;
            } */

            if (gameObject.tag == "Grid box")
            {

                transform.localScale /= scaleFactor;
                
            }

        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f && zoomedOut == true) //backward
        {

            zoomedOut = false;
            globals.zoomedOut = false;

             if (gameObject.tag == "Grid leg")
            {
                transform.localScale /= scaleFactor;
            }

            /* if (gameObject.tag == "Piece")
            {
                transform.position /= scaleFactor;
            } */

            if (gameObject.tag == "Grid box")
            {
                transform.localScale *= scaleFactor;
            }


        }

    }
}
