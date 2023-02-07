using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class globals
{
    public static bool zoomedOut = false;
    public static int[,] BoardArray = {{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0}};
    public static bool SomeoneWon = true;
    public static int pieceTurn = 2;

    public static bool playingForSecond = false;
    public static int pieceThatWon;
}
