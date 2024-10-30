
using Eloi.SNAM;
using System.Collections.Generic;
/// <summary>
/// I am class that keep a register of available array index for player that are arriving in the game.
/// </summary>
[System.Serializable]
public class IISNAM16KPlayersInGameRegister
{

    public Dictionary<int, int> m_playerIndexToArrayIndex = new Dictionary<int, int>();
    public SNAM16K_ObjectInt m_playerIndexOwner;
    public SNAM16K_ObjectBool m_isPlayerPlaying;
    public Queue<int> m_claimableArrayIndex = new Queue<int>();
    public int m_nullValueInNativeArray = int.MinValue;

    public int GetClaimableCount()
    {
        return m_claimableArrayIndex.Count;
    }
    public int GetPeekOfNextClaimable()
    {
        return m_claimableArrayIndex.Peek();
    }

    public void ResetToStartState()
    {
        m_playerIndexToArrayIndex.Clear();
        m_claimableArrayIndex.Clear();
        for (int i = 0; i < SNAM16K.ARRAY_MAX_SIZE; i++)
        {
            m_claimableArrayIndex.Enqueue(i);
            m_playerIndexOwner.Set(i, m_nullValueInNativeArray);
            m_isPlayerPlaying.Set(i, false);
        }
    }


    public bool IsPlayerInGame(int playerIndex)
    {
        return m_playerIndexToArrayIndex.ContainsKey(playerIndex);
    }
    public int GetArrayIndexFromPlayerIndex(int playerIndex)
    {
        if (m_playerIndexToArrayIndex.ContainsKey(playerIndex))
            return m_playerIndexToArrayIndex[playerIndex];
        return -1;
    }
    public int GetPlayerIndexFromArrayIndex(int arrayIndex)
    {
        if (arrayIndex < 0 || arrayIndex >= SNAM16K.ARRAY_MAX_SIZE)
        {
            throw new System.ArgumentOutOfRangeException("Array is 16k max");
        }
        return m_playerIndexOwner.Get(arrayIndex);
    }


    public void Claim(int playerIndex)
    {

        if (m_playerIndexToArrayIndex.ContainsKey(playerIndex))
            return;
        int arrayIndex = m_claimableArrayIndex.Dequeue();
        m_playerIndexToArrayIndex.Add(playerIndex, arrayIndex);
        m_playerIndexOwner.Set(arrayIndex, playerIndex);
        m_isPlayerPlaying.Set(arrayIndex, true);
    }
    public void Unclaim(int playerIndex)
    {
        if (!m_playerIndexToArrayIndex.ContainsKey(playerIndex))
            return;

        int arrayIndex = m_playerIndexToArrayIndex[playerIndex];
        m_playerIndexToArrayIndex.Remove(playerIndex);
        m_playerIndexOwner.Set(arrayIndex, m_nullValueInNativeArray);
        m_claimableArrayIndex.Enqueue(arrayIndex);
        m_isPlayerPlaying.Set(arrayIndex, false);
    }

    public int GetPlayersInGame()
    {
       return m_playerIndexToArrayIndex.Keys.Count;
    }
}
