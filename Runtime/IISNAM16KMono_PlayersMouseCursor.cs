using UnityEngine;

public class IISNAM16KMono_PlayersMouseCursor : MonoBehaviour
{

    public IISNAM16KMono_PlayersInGameRegister m_register;
    public SNAM16K_CursorPosition2020 m_playerMouseCursor;
    public int m_startDigitOfGamepad = 15;


    [Header("Debug Value")]
    public int m_lastIndex;
    public int m_lastValue;
    public int m_firstTwoDigits;
    public bool m_playerInGame;
    public STRUCT_CursorPosition2020 m_lastMouseCursor;
    public int m_playerInGameCount;


    public void PushIn(int index, int value)
    {
        m_lastIndex = index;
        m_lastValue = value;
        IntegerToGamepad2020Utility.GetTwoFirstDigits(value, out int first);
        m_firstTwoDigits = first;

        IISNAM16KPlayersInGameRegister r = m_register.R();

        bool playerInGame = r.IsPlayerInGame(index);
        m_playerInGame = playerInGame;
        if (r.IsPlayerInGame(index))
        {
            int arrayIndex = r.GetArrayIndexFromPlayerIndex(index);
            m_firstTwoDigits = first;
            if (first == m_startDigitOfGamepad)
            {
                IntegerToMousePosition2020Utility.ParseMousePosition2020FromInteger(value, out STRUCT_CursorPosition2020 pad);
                m_lastMouseCursor = pad;
                m_playerMouseCursor.Set(arrayIndex, pad);
            }
        }
    }
}


