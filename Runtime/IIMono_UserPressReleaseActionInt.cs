using UnityEngine;
using UnityEngine.Events;

public class IIMono_UserPressReleaseActionInt : MonoBehaviour {

    public int m_actionOnPress;
    public int m_actionOnRelease;
    public int[] m_index = new int[] { 2501 };
    public UnityEvent<int, int> m_onIntegerIndexChanged;

    [ContextMenu("Press")]
    public void PressAction() {
        foreach (int i in m_index)
            m_onIntegerIndexChanged.Invoke(i, m_actionOnPress);
    }

    [ContextMenu("Release")]
    public void ReleaseAction() {
        foreach (int i in m_index)
            m_onIntegerIndexChanged.Invoke(i, m_actionOnRelease);
    }

}

