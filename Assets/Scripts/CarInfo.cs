using System;
using UnityEngine;
using System.Collections.Generic;

public class CarInfo : MonoBehaviour
{
    [Header("Debug")] [SerializeField] private bool m_DoorAnimInProgress;
    [Space(5)]
    [Header("Settings")]
    [SerializeField] private float m_Time = 0.5f;
    [SerializeField] private float m_LeftDoorOpen = 90f;
    [SerializeField] private float m_RightDoorOpen = -90f;
    [SerializeField] private float m_TrunkOpen = 45f;
    [SerializeField] private float m_BootOpen = 45f;
    [Space(5)]
    [Header("Components")]
    [SerializeField] private GameObject m_LeftDoor;
    [SerializeField] private GameObject m_RightDoor;
    [SerializeField] private GameObject m_Trunk;
    [SerializeField] private GameObject m_Bonnet;
    [SerializeField] private GameObject[] m_Tyres;
    public float Time => m_Time;
    
    public void OpenDoors()
    {
        if (m_LeftDoor != null) LeanTween.rotateLocal(m_LeftDoor, new Vector3(0, m_LeftDoorOpen, 0), m_Time);
        if (m_RightDoor != null) LeanTween.rotateLocal(m_RightDoor, new Vector3(0, m_RightDoorOpen, 0), m_Time);
    }

    public void CloseDoors()
    {
        if (m_LeftDoor != null) LeanTween.rotateLocal(m_LeftDoor, Vector3.zero, m_Time);
        if (m_RightDoor != null) LeanTween.rotateLocal(m_RightDoor, Vector3.zero, m_Time);
    }

    public void OpenTrunk()
    {
        if (m_Trunk != null) LeanTween.rotateX(m_Trunk, m_TrunkOpen, m_Time);
    }

    public void CloseTrunk()
    {
        if (m_Trunk != null) LeanTween.rotateX(m_Trunk, 0f, m_Time);
    }

    public void OpenBonnet()
    {
        if (m_Bonnet != null) LeanTween.rotateX(m_Bonnet, m_BootOpen, m_Time);
    }

    public void CloseBonnet()
    {
        if (m_Bonnet != null) LeanTween.rotateX(m_Bonnet, 0f, m_Time);
    }

    public void StartEngine()
    {
        foreach (GameObject tyre in m_Tyres)
        {
            LeanTween.cancel(tyre);
            
            LeanTween.rotateAroundLocal(tyre, Vector3.right, 360f, m_Time).setEase(LeanTweenType.linear).setLoopClamp().setRepeat(-1);
        }
    }

    public void StopEngine()
    {
        foreach (GameObject tyre in m_Tyres)
        {
            LeanTween.cancel(tyre);
        }
    }
}