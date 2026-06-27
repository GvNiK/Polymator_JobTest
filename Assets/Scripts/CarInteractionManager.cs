using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CarInteractionManager : MonoBehaviour
{
    [Header("Debug")] 
    [Space(5)]
    [SerializeField] private bool m_AreDoorsOpen;
    [SerializeField] private bool m_IsTrunkOpen;
    [SerializeField] private bool m_IsBonnetOpen;
    [SerializeField] private bool m_IsEngineOn;
    [SerializeField] private bool m_LogMessages = true;
    [SerializeField] private bool m_CarFound;
    [Header("Settings")] 
    [SerializeField] private float m_WaitTime = 1f;
    [Space(5)]
    [Header("Components")] 
    [SerializeField] private CarInfo m_CarInfo;
    [SerializeField] private Button m_DoorsButton;
    [SerializeField] private Button m_TrunkButton;
    [SerializeField] private Button m_BonnetButton;
    [SerializeField] private Button m_TyresButton;
    [SerializeField] private Slider m_Slider;
    
    private Coroutine m_SpawnCoroutine;
    private Coroutine m_DoorAnimCoroutine;
    private Coroutine m_TrunkAnimCoroutine;
    private Coroutine m_BonnetAnimCoroutine;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(m_SpawnCoroutine != null)
        {
            StopCoroutine(m_SpawnCoroutine);
            m_SpawnCoroutine = null;
        }
        
        m_SpawnCoroutine = StartCoroutine(WaitForSpawn());
        
        //InteractionEvents.OnCarSpawned += OnCarSpawned;
    }

    // private void OnCarSpawned(GameObject obj)
    // {
    //     LogMessage("Car Spawned!" + obj.name);
    //     Initialize();
    // }

    private void Initialize()
    {
        if(m_CarInfo == null)
        {
            m_CarInfo = GameObject.FindAnyObjectByType<CarInfo>();
            if(m_CarInfo != null) m_CarFound = true;
        }
    }

    public void HandleDoorInteraction()
    {
        if(m_CarInfo != null)
        {
            if (m_DoorAnimCoroutine != null)
            {
                StopCoroutine(m_DoorAnimCoroutine);
                m_DoorAnimCoroutine = null;
            }
            
            m_DoorAnimCoroutine = StartCoroutine(WaitForAnimation(m_CarInfo.Time, m_DoorsButton));
            
            if (m_AreDoorsOpen) m_CarInfo.CloseDoors();
            else m_CarInfo.OpenDoors();

            m_AreDoorsOpen = !m_AreDoorsOpen;
        }
    }
    
    public void HandleTrunkInteraction()
    {
        if(m_CarInfo != null)
        {
            if (m_TrunkAnimCoroutine != null)
            {
                StopCoroutine(m_TrunkAnimCoroutine);
                m_TrunkAnimCoroutine = null;
            }
            
            m_TrunkAnimCoroutine = StartCoroutine(WaitForAnimation(m_CarInfo.Time, m_TrunkButton));
            
            if (m_IsTrunkOpen) m_CarInfo.CloseTrunk();
            else m_CarInfo.OpenTrunk();

            m_IsTrunkOpen = !m_IsTrunkOpen;
        }
    }
    
    public void HandleBonnetInteraction()
    {
        if(m_CarInfo != null)
        {
            if (m_BonnetAnimCoroutine != null)
            {
                StopCoroutine(m_BonnetAnimCoroutine);
                m_BonnetAnimCoroutine = null;
            }
            
            m_BonnetAnimCoroutine = StartCoroutine(WaitForAnimation(m_CarInfo.Time, m_BonnetButton));
            
            if (m_IsBonnetOpen) m_CarInfo.CloseBonnet();
            else m_CarInfo.OpenBonnet();

            m_IsBonnetOpen = !m_IsBonnetOpen;
        }
    }

    public void HandleEngineInteraction()
    {
        if (m_CarInfo != null)
        {
            if(m_IsEngineOn) m_CarInfo.StopEngine();
            else m_CarInfo.StartEngine();
            
            m_IsEngineOn = !m_IsEngineOn;
        }
    }

    private void LogMessage(string message)
    {
        if(m_LogMessages) Debug.Log(message);
    }

    private IEnumerator WaitForAnimation(float time, Button button)
    {
        if(button != null) button.interactable = false;
        yield return new WaitForSeconds(time);
        if(button != null) button.interactable = true;
    }

    private IEnumerator WaitForSpawn()
    {
        while (m_CarInfo == null && !m_CarFound)
        {
            yield return new WaitForSeconds(m_WaitTime);
            
            Initialize();
            
            yield return null;
        }
    }

    private void OnDestroy()
    {
        //InteractionEvents.OnCarSpawned -= OnCarSpawned;
    }
}
