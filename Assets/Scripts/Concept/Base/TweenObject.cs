using UnityEngine;
using UnityEngine.Animations;

namespace DefaultNamespace.Concept
{
    public class TweenObject : MonoBehaviour, IAnimate
    {
        [SerializeField] private float m_Time = 1f;
        [SerializeField] private Axis m_Axis;
        [SerializeField] private Vector3 m_Position;
        [SerializeField] private Vector3 m_Rotation;
        
        private int m_TweenID;
        private Vector3 m_StartPosition;
        private Vector3 m_StartRotation;
        
        public bool IsAnimating { get; set; }
        
        public float Time { get => m_Time; set => m_Time = value; }
        public int TweenID { get => m_TweenID; set => m_TweenID = value; }
        public Axis Axis { get => m_Axis; set => m_Axis = value; }
        public Vector3 Position { get => m_Position; set => m_Position = value; }
        public Vector3 Rotation { get => m_Rotation; set => m_Rotation = value; }
        public Vector3 OriginalPosition { get => m_StartPosition; set => m_StartPosition = value; }
        public Vector3 OriginalRotation { get => m_StartRotation; set => m_StartRotation = value; }
        
        public virtual void Animate(bool stopExistingTween)
        {
            if (IsAnimating) return;
            
            if (stopExistingTween) Stop();
            
            IsAnimating = true;
        }

        public virtual void Pause()
        {
            if (!IsAnimating) return;
            
            LeanTween.pause(m_TweenID);
            IsAnimating = false;
        }

        public virtual void Resume()
        {
            if (IsAnimating) return;
            
            LeanTween.resume(m_TweenID);
            IsAnimating = true;
        }

        public virtual void Stop()
        {
            if(LeanTween.descr(m_TweenID) != null)
            {
                LeanTween.cancel(m_TweenID);
                IsAnimating = false;
            }
        }

        public virtual void Reset()
        {
            if (IsAnimating) return;
            
            IsAnimating = true;
        }
    }
}