using UnityEngine;

namespace DefaultNamespace.Concept
{
    public class Door : TweenObject
    {
        [SerializeField] private CarPart m_CarPart = new CarPart{ Name = " Door"};

        private void Start()
        {
            if(m_CarPart.Part != null) OriginalRotation = m_CarPart.Part.transform.rotation.eulerAngles;
        }
        
        public override void Animate(bool stopExistingTween)
        {
            base.Animate(stopExistingTween);

            if (m_CarPart.Part != null) TweenID = LeanTween.rotateLocal(m_CarPart.Part, Rotation, Time).setOnComplete(HandleComplete).id;
        }

        public override void Reset()
        {
            base.Reset();

            if (m_CarPart.Part != null) TweenID = LeanTween.rotateLocal(m_CarPart.Part, OriginalRotation, Time).setOnComplete(HandleComplete).id;
        }

        private void HandleComplete()
        {
            IsAnimating = false;
        }
    }
}