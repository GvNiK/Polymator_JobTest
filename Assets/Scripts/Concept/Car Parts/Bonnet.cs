using System;
using UnityEngine;

namespace DefaultNamespace.Concept
{
    public class Bonnet : TweenObject
    {
        [SerializeField] private CarPart m_CarPart = new CarPart { Name = "Bonnet" };

        private void Start()
        {
            if(m_CarPart.Part != null) OriginalRotation = m_CarPart.Part.transform.rotation.eulerAngles;
        }

        public override void Animate(bool stopExistingTween)
        {
            base.Animate(stopExistingTween);

            // Rotate 45 Degrees around Y-axis.
            if (m_CarPart.Part != null) TweenID = LeanTween.rotateX(m_CarPart.Part, Rotation.x, Time).setOnComplete(HandleComplete).id;
        }

        public override void Reset()
        {
            base.Reset();
            
            // Rotate to it's default around Y-axis.
            if (m_CarPart.Part != null) TweenID = LeanTween.rotateX(m_CarPart.Part, OriginalRotation.x, Time).setOnComplete(HandleComplete).id;
        }

        private void HandleComplete()
        {
            IsAnimating = false;
        }
    }
}