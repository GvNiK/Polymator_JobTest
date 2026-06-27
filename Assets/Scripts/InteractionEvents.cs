using System;
using UnityEngine;

public class InteractionEvents : MonoBehaviour
{
    public static event Action<GameObject> OnCarSpawned;

    public void RaiseCarSpawned(GameObject car)
    {
        OnCarSpawned?.Invoke(car);
    }
}
