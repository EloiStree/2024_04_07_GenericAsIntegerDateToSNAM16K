using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Eloi.SNAM;


public class SNAM16K_ObjectGamepad2020 : SNAM_Generic16KMono<GamepadByteId2020Percent11> {

    [ContextMenu("Random Value")]
    public void RandomValue() { 

        for (int i = 0; i < SNAM16K.ARRAY_MAX_SIZE; i++)
        {
            int value = Random.Range(int.MinValue, int.MaxValue);
            GamepadByteId2020Percent11 pad = new GamepadByteId2020Percent11();
            IntegerToGamepad2020Utility.ParseGamepadByteId2020FromInteger(value,
                out pad);
            Set(i, pad);
        }
        
    
    }

    public void PushIn(int index16K, int value) {
        if(index16K<0 || index16K>=SNAM16K.ARRAY_MAX_SIZE)
            return;
        IntegerToGamepad2020Utility.ParseGamepadByteId2020FromInteger(value,
                out GamepadByteId2020Percent11 pad);
        Set(index16K, pad);
    }
    public void PushIn(int index16K, GamepadByteId2020Percent11 value) {
        if(index16K<0 || index16K>=SNAM16K.ARRAY_MAX_SIZE)
            return;
        Set(index16K, value);
    }

}

