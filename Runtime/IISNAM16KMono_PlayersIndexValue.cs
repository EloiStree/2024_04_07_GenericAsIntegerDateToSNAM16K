using UnityEngine;
using UnityEngine.Events;

public class IISNAM16KMono_PlayersIndexValue : MonoBehaviour
{

    public IISNAM16KMono_PlayersInGameRegister m_register;
    public UnityEvent<SNAM16KIIArrayAction> m_onInGamePlayerActions;
    public UnityEvent<SNAM16KIIPlayerIdEvent> m_onNewPlayerInGame;
    public UnityEvent<int, int> m_arrayIdValue;



    [Header("Debug Value")]
    public int m_lastIndex;
    public int m_lastValue;
    public int m_firstTwoDigits;
    public bool m_playerInGame;
    public SNAM16KIIArrayAction m_lastPlayerAction;
    public int m_claimLeft;
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
        if (!playerInGame)
        {
            m_claimLeft = r.GetClaimableCount();
            if (m_claimLeft > 0)
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
            SNAM16KIIArrayAction action = new SNAM16KIIArrayAction() { m_integerIndex = index, m_integerValue = value, m_snamArrayIndex = arrayIndex };
            m_lastPlayerAction = action;
            m_onInGamePlayerActions.Invoke(m_lastPlayerAction);
            m_arrayIdValue.Invoke(arrayIndex, value);
        }
    }
}


