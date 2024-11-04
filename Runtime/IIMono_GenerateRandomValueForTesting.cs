using UnityEngine;
using UnityEngine.Events;

public class IIMono_GenerateRandomValueForTesting: MonoBehaviour
{
    public UnityEvent<int, int> m_onIndexIntegerGenerated;
    public UnityEvent< int> m_onIntegerGenerated;
    public int m_indexMin = 0;
    public int m_indexMax = 12;
    public int m_valueMin = 1200000000;
    public int m_valueMax = 1299999999;

    [ContextMenu("Generate Random")]
    public void GenerateRandom()
    {
        int index = Random.Range(m_indexMin, m_indexMax+1);
        int value = Random.Range(m_valueMin, m_valueMax+1);

        m_onIndexIntegerGenerated.Invoke(index, value);
        m_onIntegerGenerated.Invoke(value);
    }
}

