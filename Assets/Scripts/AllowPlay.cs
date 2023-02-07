using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllowPlay : MonoBehaviour
{
    public void StartPlay()
    {
        globals.SomeoneWon = false;
        globals.playingForSecond=false;
        changePieceIndicator.gameStartEvent.Invoke();
    }

    public void StartPlayForSecond()
    {
        globals.SomeoneWon = false;
        globals.playingForSecond=true;
    }
}
