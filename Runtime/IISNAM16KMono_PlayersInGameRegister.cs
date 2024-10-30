using UnityEngine;

public class IISNAM16KMono_PlayersInGameRegister : MonoBehaviour {
    public IISNAM16KPlayersInGameRegister m_playerInGame;

    public IISNAM16KPlayersInGameRegister R()
    {
        return m_playerInGame; 
    }

    private void Awake()
    {
        m_playerInGame.ResetToStartState();
    }
}
