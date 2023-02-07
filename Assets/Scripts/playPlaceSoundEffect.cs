using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playPlaceSoundEffect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        changePieceIndicator.piecePlacedEvent.AddListener(placeSound);
    }

    // Update is called once per frame
    void placeSound()
    {
        GetComponent<AudioSource>().Play();
    }

}
