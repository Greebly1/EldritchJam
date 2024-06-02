using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this is just a debug class I connect to unity events in inspectors to make sure my events are beign fired off properly
public class DebugNotifier : MonoBehaviour
{
    public void PrintMessage(string message = "event occurred")
    {
        Debug.Log(message);
    }
}
