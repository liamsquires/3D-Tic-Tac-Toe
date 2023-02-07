using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseDragMovement : MonoBehaviour
{
    Vector3 oldPosition;
    Vector3 currentPosition;
    Vector3 rotationValue;
    bool dragging = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(1)) {
            if(dragging == true) {
                currentPosition = Input.mousePosition;
                rotationValue = oldPosition - currentPosition;
                transform.Rotate(-rotationValue.y, -rotationValue.x, 0);
                oldPosition=currentPosition;
            }
            if(dragging == false) {
                currentPosition = Input.mousePosition;
                oldPosition=currentPosition;
                dragging = true;
            }
            
        }
        else {
            dragging = false;
        }
    }
}
