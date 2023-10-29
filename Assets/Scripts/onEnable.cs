using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class onEnable : MonoBehaviour
{
    public UnityEvent actions;
    void OnEnable()
    {
        actions?.Invoke();
    }
}
