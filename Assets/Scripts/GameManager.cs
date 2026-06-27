using UnityEngine;
using UnityEngine.Splines;

namespace DefaultNamespace
{
    public class GameManager : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private SplineAnimate m_PlayerSpline;
        [SerializeField] private GameUIHandler m_GameUIHandler;
        
        private void Start()
        {
            InitializeComponents();
            CrashHandler.OnCrashed += HandleCrash;
        }

        private void InitializeComponents()
        {
            if(m_PlayerSpline == null)
            {
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                m_PlayerSpline = player.GetComponent<SplineAnimate>();
            }
            if(m_GameUIHandler == null) m_GameUIHandler = GameObject.FindAnyObjectByType<GameUIHandler>();
        }

        private void Update()
        {
            if (m_PlayerSpline != null)
            {
                if(m_GameUIHandler != null)
                {
                    float progression = m_PlayerSpline.NormalizedTime;
                    m_GameUIHandler.UpdateCompletionProgress(progression);
                    
                    if (progression >= 1f)
                    {
                        StopControls();
                        m_GameUIHandler.SetPopupUIState(true, false);
                    }
                }
            }
        }
        
        private void HandleCrash()
        {
            StopControls();
            if(m_GameUIHandler != null) m_GameUIHandler.SetPopupUIState(true, true);
            
            // Add Impact
        }

        private void StopControls()
        {
            if(m_PlayerSpline != null)
            {
                m_PlayerSpline.Pause();
                m_PlayerSpline.enabled = false;
            }
        }
        
        private void OnDestroy()
        {
            CrashHandler.OnCrashed -= HandleCrash;
        }
    }
}