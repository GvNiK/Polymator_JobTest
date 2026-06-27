using System;
using UnityEngine;

public class CrashHandler : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private string m_VehicleTag = "Vehicle";

    public static Action OnCrashed;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(m_VehicleTag))
        {
            OnCrashed?.Invoke();
        }
    }
}
