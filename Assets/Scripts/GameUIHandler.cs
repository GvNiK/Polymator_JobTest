using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class GameUIHandler : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private GameObject m_PopupUI;
        [SerializeField] private Slider m_CompletionSlider;
        [SerializeField] private TMP_Text m_PercentageText;
        [SerializeField] private TMP_Text m_CompletionText;
        [SerializeField] private TMP_Text m_TitleText;
        [SerializeField] private Button m_MainMenuButton;
        [SerializeField] private Button m_NextLevelButton;

        private string m_Progress;
        
        public void SetPopupUIState(bool state, bool hasCrashed)
        {
            if(m_TitleText != null) m_TitleText.text = hasCrashed ? "You Crashed!" : "Level Completed!";
            if(m_CompletionText != null) m_CompletionText.text = m_Progress;
            if(m_PopupUI != null) m_PopupUI.SetActive(state);
            
            SwitchButtons(hasCrashed);
        }

        public void SwitchButtons(bool hasCrashed)
        {
            if (hasCrashed)
            {
                if(m_MainMenuButton != null) m_MainMenuButton.gameObject.SetActive(true);
                if(m_NextLevelButton != null) m_NextLevelButton.gameObject.SetActive(false);
            }
            else
            {
                if(m_MainMenuButton != null) m_MainMenuButton.gameObject.SetActive(false);
                if(m_NextLevelButton != null) m_NextLevelButton.gameObject.SetActive(true);
            }
        }
        
        public void UpdateCompletionProgress(float progress)
        {
            m_CompletionSlider.value = progress;
            
            if(m_PercentageText != null)
            {
                m_Progress = (progress * 100).ToString("0") + "%";
                m_PercentageText.text = m_Progress;
            }
            
            if(m_CompletionSlider != null) m_CompletionSlider.value = progress;
        }
    }
}