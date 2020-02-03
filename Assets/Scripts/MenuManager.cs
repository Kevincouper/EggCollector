using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject panelMenuPause;
    [SerializeField] private GameObject panelGameOver;
    [SerializeField] private GameObject panelWin;
    [SerializeField] private GameObject panelCredits;
    [SerializeField] private GameObject panelMenuStartGame;


    //public void LoadScene (string sceneName)
    //{
    //    Time.timeScale = 1;
    //    SceneManager.LoadScene(sceneName);
    //}
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
        Score.score = 0;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 0;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void DesactivateMenuPause()
    {
        panelMenuPause.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void ActivateMenuPause()
    {
        panelMenuPause.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void ActivatePanelCredits()
    {
        panelCredits.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void DesactivatePanelCredits()
    {
        panelCredits.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void ActivatePanelMenuStartGame()
    {
        panelMenuStartGame.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void DesactivatePanelMenuStartGame()
    {
        panelMenuStartGame.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

 
}
