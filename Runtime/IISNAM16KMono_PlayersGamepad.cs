
using Eloi.SNAM;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IISNAM16KMono_PlayersGamepad : MonoBehaviour
{

    public IISNAM16KMono_PlayersInGameRegister m_register;
    public SNAM16K_ObjectGamepad2020 m_player;
    public int m_startDigitOfGamepad = 18;

    public UnityEvent<SNAM16KIIArrayAction> m_onInGamePlayerActions;
    public UnityEvent<SNAM16KIIPlayerIdEvent> m_onNewPlayerInGame;


    [Header("Debug Value")]
    public int m_lastIndex;
    public int m_lastValue;
    public int m_firstTwoDigits;
    public bool m_playerInGame;
    public GamepadByteId2020Percent11 m_lastGamepad;
    public SNAM16KIIArrayAction m_lastPlayerAction;
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
        if (!playerInGame)
        {
            m_claimLeft = r.GetClaimableCount();
            if(m_claimLeft>0)
            {
                r.Claim(index);
            }
            m_claimLeft = r.GetClaimableCount();
            m_playerInGameCount = r.GetPlayersInGame();
            m_onNewPlayerInGame.Invoke(new SNAM16KIIPlayerIdEvent() { m_integerIndex = index, m_snamArrayIndex = r.GetArrayIndexFromPlayerIndex(index) });

        }
        playerInGame = r.IsPlayerInGame(index);
        m_playerInGame = playerInGame;
        if (r.IsPlayerInGame(index))
        {
            int arrayIndex = r.GetArrayIndexFromPlayerIndex(index);
            m_firstTwoDigits = first;
            if (first == m_startDigitOfGamepad)
            {
                IntegerToGamepad2020Utility.ParseGamepadByteId2020FromInteger(value, out GamepadByteId2020Percent11 pad);
                m_lastGamepad = pad;
                m_player.Set(arrayIndex, pad);
            }
            else { 
            
                m_lastPlayerAction = new SNAM16KIIArrayAction() { m_integerIndex = index, m_integerValue = value, m_snamArrayIndex = arrayIndex };
                m_onInGamePlayerActions.Invoke(m_lastPlayerAction);
            }

        }
    }
}

