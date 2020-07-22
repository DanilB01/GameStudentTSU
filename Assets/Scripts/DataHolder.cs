using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataHolder
{
    public static int coinsCount = 0;
    public static int[] itemID = new int[6] { -1, -1, -1, -1, -1, -1 };
    public static bool[] isFoodNeed = new bool[8] { false, false, false, false, false, false, false, false };
    public static bool[] isFirstGame = new bool[8] { true, true, true, true, true, true, true, true };
}
