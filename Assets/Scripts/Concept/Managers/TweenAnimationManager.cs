using UnityEngine;

namespace DefaultNamespace.Concept.Managers
{
    public class TweenAnimationManager : MonoBehaviour
    {
        //[SerializeField] private TweenObject[] m_TweenObjects;

        [SerializeField] private bool m_IsBonnetOpen = false;
        [SerializeField] private bool m_IsTrunkOpen = false;
        [SerializeField] private bool m_IsLeftDoorOpen = false;
        [SerializeField] private bool m_IsRightDoorOpen = false;
        [SerializeField] private bool m_IsEngineOn = false;
        
        [SerializeField] private Bonnet m_Bonnet;
        [SerializeField] private Trunk m_Trunk;
        [SerializeField] private Door m_LeftDoor;
        [SerializeField] private Door m_RightDoor;
        [SerializeField] private Tyre m_Tyres;
        
        public void HandleBonnet()
        {
            if (m_Bonnet != null)
            {
                //Bonnet bonnet = m_TweenObjects.GetValue(0) as Bonnet;
                
                if(m_IsBonnetOpen) m_Bonnet.Revert();
                else m_Bonnet.Animate(true);
                
                m_IsBonnetOpen = !m_IsBonnetOpen;
            }
        }

        public void HandleTrunk()
        {
            if (m_Trunk != null)
            {
                if(m_IsTrunkOpen) m_Trunk.Revert();
                else m_Trunk.Animate(true);
                
                m_IsTrunkOpen = !m_IsTrunkOpen;
            }
        }

        public void HandleDoors()
        {
            HandleLeftDoor();
            HandleRightDoor();
        }

        public void HandleTyres()
        {
            if (m_Tyres != null)
            {
                if(m_IsEngineOn) m_Tyres.Revert();
                else m_Tyres.Animate(true);
                
                m_IsEngineOn = !m_IsEngineOn;
            }
        }

        public void HandleLeftDoor()
        {
            if (m_LeftDoor != null)
            {
                if(m_IsLeftDoorOpen) m_LeftDoor.Revert();
                else m_LeftDoor.Animate(true);
                
                m_IsLeftDoorOpen = !m_IsLeftDoorOpen;
            }
        }

        public void HandleRightDoor()
        {
            if (m_RightDoor != null)
            {
                if(m_IsRightDoorOpen) m_RightDoor.Revert();
                else m_RightDoor.Animate(true);
                
                m_IsRightDoorOpen = !m_IsRightDoorOpen;
            }
        }
    }
}