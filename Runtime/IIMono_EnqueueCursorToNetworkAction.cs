using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IIMono_EnqueueCursorToNetworkAction : MonoBehaviour
{
    public Queue<STRUCT_CursorPositionNetworkPlayerAction> m_waitingAction = new Queue<STRUCT_CursorPositionNetworkPlayerAction>();

}
