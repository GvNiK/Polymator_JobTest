using UnityEngine;

namespace DefaultNamespace.Concept
{
    public class Trunk : TweenObject
    {
        [SerializeField] private CarPart m_CarPart = new CarPart { Name = "Trunk" };

        private void Start()
        {
            if(m_CarPart.Part != null) OriginalRotation = m_CarPart.Part.transform.rotation.eulerAngles;
        }

        protected override LTDescr PlayAnimateTween()
        {
            if(m_CarPart.Part == null) return null;
            
            return LeanTween.rotateLocal(m_CarPart.Part, Rotation, Time);
        }

        protected override LTDescr PlayResetTween()
        {
            if(m_CarPart.Part == null) return null;
            
            return  LeanTween.rotateLocal(m_CarPart.Part, OriginalPosition, Time);
        }
    }
}