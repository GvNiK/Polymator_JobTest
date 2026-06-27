using UnityEngine;

public class HomeScreenUI : MonoBehaviour
{
    [Header("Debug")] 
    [SerializeField] private bool m_IsLevelSelectionActive;
    [Space(5)]
    [Header("Components")]
    [SerializeField] private GameObject m_HomeUI;
    [SerializeField] private GameObject m_LevelUI;
    
    public void ToggleLevelSelection()
    {
        if (m_LevelUI != null)
        {
            m_LevelUI.SetActive(m_IsLevelSelectionActive);
            m_IsLevelSelectionActive = !m_IsLevelSelectionActive;
        }
    }

    public void Exit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
