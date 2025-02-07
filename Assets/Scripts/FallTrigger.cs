using System;
using UnityEngine;
using UnityEngine.Events;

public class FallTrigger : MonoBehaviour
{
    // adding OnPinFall public event in case any other object needs to know if the pin has fallen
    public UnityEvent OnPinFall = new();
    public bool isPinFallen = false;
    
    private void OnTriggerEnter(Collider triggeredObject)
    {
        if(triggeredObject.CompareTag("Ground") && !isPinFallen)
        {
            isPinFallen = true;
            OnPinFall?.Invoke();
            Debug.Log($"{gameObject.name} is fallen");
        }
    }
}
