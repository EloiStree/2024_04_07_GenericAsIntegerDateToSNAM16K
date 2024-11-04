using UnityEngine;

public class SNAM16K_ObjectGamepad2020Extra : SNAM_Generic16KMono<GamepadId2020Extra>
{

    [ContextMenu("Random Value")]
    public void RandomValue()
    {
        for (int i = 0; i < SNAM16K.ARRAY_MAX_SIZE; i++)
        {
            PushIn(i, Random.Range(int.MinValue, int.MaxValue));
        }
    }

    public void PushIn(int index16K, int value)
    {
        if (index16K < 0 || index16K >= SNAM16K.ARRAY_MAX_SIZE)
            return;
        IntegerToGamepad2020Utility.ParseGamepadExtraByteId2020FromInteger(value,
                out GamepadId2020Extra pad);
        Set(index16K, pad);
    }
    public void PushIn(int index16K, GamepadId2020Extra value)
    {
        if (index16K < 0 || index16K >= SNAM16K.ARRAY_MAX_SIZE)
            return;
        Set(index16K, value);
    }

}
