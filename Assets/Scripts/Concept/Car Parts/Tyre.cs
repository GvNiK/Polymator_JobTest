using UnityEngine;

namespace DefaultNamespace.Concept
{
    public class Tyre : TweenObject
    {
        [SerializeField] private CarPart[] m_CarPart = new CarPart[4];

        protected override LTDescr PlayAnimateTween() => null;

        protected override LTDescr PlayResetTween() => null;

        public override void Animate(bool stopExistingTween)
        {
            stopExistingTween = true;
            
            base.Animate(stopExistingTween);

            foreach (CarPart part in m_CarPart)
            {
                GameObject tyre = part.Part;
                if(tyre != null)
                {
                    LeanTween.rotateAroundLocal(tyre, Vector3.right, 360f, Time).setEase(LeanTweenType.linear).setOnComplete(HandleComplete).setLoopClamp().setRepeat(-1);
                }
            }
        }

        public override void Revert()
        {
            base.Revert();

            foreach (CarPart part in m_CarPart)
            {
                if(part != null) if(part.Part != null)
                {
                    LeanTween.cancel(part.Part);
                }
            }
            
            base.Stop();
        }

        private void HandleComplete()
        {
            IsAnimating = false;
        }
    }
}