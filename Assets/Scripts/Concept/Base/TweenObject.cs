using UnityEngine;
using UnityEngine.Animations;

namespace DefaultNamespace.Concept
{
    public abstract class TweenObject : MonoBehaviour, IAnimate
    {
        [SerializeField] private float m_Time = 1f;
        [SerializeField] private Axis m_Axis;
        [SerializeField] private Vector3 m_Position;
        [SerializeField] private Vector3 m_Rotation;
        
        private Vector3 m_StartPosition;
        private Vector3 m_StartRotation;

        protected LTDescr m_Tween;
        
        public bool IsAnimating { get; set; }
        
        public float Time { get => m_Time; set => m_Time = value; }
        public Axis Axis { get => m_Axis; set => m_Axis = value; }
        public Vector3 Position { get => m_Position; set => m_Position = value; }
        public Vector3 Rotation { get => m_Rotation; set => m_Rotation = value; }
        public Vector3 OriginalPosition { get => m_StartPosition; set => m_StartPosition = value; }
        public Vector3 OriginalRotation { get => m_StartRotation; set => m_StartRotation = value; }

        protected abstract LTDescr PlayAnimateTween();
        protected abstract LTDescr PlayResetTween();
        
        public virtual void Animate(bool stopExistingTween)
        {
            if (IsAnimating) return;
            if (stopExistingTween) Stop();
            
            m_Tween = PlayAnimateTween();
            if (m_Tween == null) return;
            
            IsAnimating = true;
            m_Tween.setOnComplete(HandleOnComplete);
        }

        public virtual void Pause()
        {
            if (!IsAnimating || m_Tween == null) return;
            
            LeanTween.pause(m_Tween.id);
            IsAnimating = false;
        }

        public virtual void Resume()
        {
            if (IsAnimating || m_Tween == null) return;
            
            LeanTween.resume(m_Tween.id);
            IsAnimating = true;
        }

        public virtual void Stop()
        {
            if (m_Tween == null) return;
            
            LeanTween.cancel(m_Tween.id);
            m_Tween = null;
            
            IsAnimating = false;
        }

        public virtual void Revert()
        {
            if (IsAnimating) return;
            
            m_Tween = PlayResetTween();
            if (m_Tween == null) return;
            
            IsAnimating = true;
            m_Tween.setOnComplete(HandleOnComplete);
        }

        private void HandleOnComplete()
        {
            IsAnimating = false;
        }
    }
}