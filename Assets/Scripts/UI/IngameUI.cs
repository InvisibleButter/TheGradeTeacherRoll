using UnityEngine;

public class IngameUI : MonoBehaviour
{
    public GameObject IngamePanel;

    private bool _isOpen;
    private void Awake()
    {
        IngamePanel.gameObject.SetActive(false);
        _isOpen = false;
    }

    private void Update()
    {
        if (_isOpen)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Resume();
            }
            return;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.Instance.PauseGame(true);
            _isOpen = true;
            IngamePanel.gameObject.SetActive(true);
        }
    }

    public void CloseGame()
    {
        Application.Quit(0);
    }

    public void Resume()
    {
        GameManager.Instance.PauseGame(false);
        IngamePanel.gameObject.SetActive(false);
        _isOpen = false;
    }
}
