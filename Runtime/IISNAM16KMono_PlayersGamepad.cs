
using Eloi.SNAM;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IISNAM16KMono_PlayersGamepad : MonoBehaviour
{

    public IISNAM16KMono_PlayersInGameRegister m_register;
    public SNAM16K_ObjectGamepad2020 m_playerGamepad;
    public SNAM16K_ObjectGamepad2020Extra m_playerGamepadExtra;
    public int m_startDigitOfGamepad = 18;
    public int m_startDigitOfGamepadExtra = 17;


    [Header("Debug Value")]
    public int m_lastIndex;
    public int m_lastValue;
    public int m_firstTwoDigits;
    public bool m_playerInGame;
    public GamepadByteId2020Percent11 m_lastGamepad;
    public GamepadId2020Extra m_lastGamepadExtra;
    public int m_claimLeft;
    public int m_playerInGameCount;


    public void PushIn(int index, int value)
    {
        m_lastIndex = index;
        m_lastValue = value;
        IntegerToGamepad2020Utility.GetTwoFirstDigits(value, out int first);
        m_firstTwoDigits=first;

        IISNAM16KPlayersInGameRegister r = m_register.R();

        bool playerInGame = r.IsPlayerInGame(index);
        m_playerInGame = playerInGame;
        if (r.IsPlayerInGame(index))
        {
            int arrayIndex = r.GetArrayIndexFromPlayerIndex(index);
            m_firstTwoDigits = first;
            if (first == m_startDigitOfGamepad)
            {
                IntegerToGamepad2020Utility.ParseGamepadByteId2020FromInteger(value, out GamepadByteId2020Percent11 pad);
                m_lastGamepad = pad;
                m_playerGamepad.Set(arrayIndex, pad);
            }
            else if(first == m_startDigitOfGamepadExtra)
            {
                IntegerToGamepad2020Utility.ParseGamepadExtraByteId2020FromInteger(value, out GamepadId2020Extra pad);
                m_lastGamepadExtra = pad;
                m_playerGamepadExtra.Set(arrayIndex, pad);
            }
           
        }
    }
}


