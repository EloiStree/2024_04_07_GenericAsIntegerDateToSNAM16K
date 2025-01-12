using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SNAM16K_CursorPosition2020 : SNAM_Generic16KMono<STRUCT_CursorPosition2020>
{

    [ContextMenu("Random Value")]
    public void RandomValue()
    {
        for (int i = 0; i < SNAM16K.ARRAY_MAX_SIZE; i++)
        {
            int value = Random.Range(int.MinValue, int.MaxValue);
            PushIn(i, value);
        }
    }
    public void PushIn(int index16K, int value)
    {
        if (index16K < 0 || index16K >= SNAM16K.ARRAY_MAX_SIZE)
            return;
        STRUCT_CursorPosition2020 pad = new STRUCT_CursorPosition2020();
        IntegerToMousePosition2020Utility.ParseMousePosition2020FromInteger(value,
            out pad);
        Set(index16K, pad);
    }
    public void PushIn(int index16K, STRUCT_CursorPosition2020 value)
    {
        if (index16K < 0 || index16K >= SNAM16K.ARRAY_MAX_SIZE)
            return;
        Set(index16K, value);
    }
}
