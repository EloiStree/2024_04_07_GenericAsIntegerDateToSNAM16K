using UnityEngine;
using UnityEngine.Events;

public class IIMono_GamepadByteId2020Percent11 : MonoBehaviour
{
    
    public UnityEvent<int, int> m_onIntegerIndexChanged;
    public int [] m_index = new int[] { 2501};

    [Header("Debug")]
    public STRUCT_GamepadByteId2020Percent11 m_gamepad;
    public int m_currentValue;
    public int m_previousValue;

    public void PushIfChanged() { 
    
        IntegerToGamepad2020Utility.ParseGamepadByteId2020ToInteger(out m_currentValue, m_gamepad);
        if(m_currentValue!=m_previousValue)
        {
            m_previousValue = m_currentValue;
            foreach (int i in m_index)
                m_onIntegerIndexChanged.Invoke(i, m_currentValue);
        }
    }

    public void SetLeftHorizontal(float value) => m_gamepad.m_joystickLeftHorizontal = (value);
    public void SetLeftVertical(float value) => m_gamepad.m_joystickLeftVertical = (value);
    public void SetRightHorizontal(float value) => m_gamepad.m_joystickRightHorizontal = (value);
    public void SetRightVertical(float value) => m_gamepad.m_joystickRightVertical = (value);


    public void Update()
    {
        PushIfChanged();
    }
}

