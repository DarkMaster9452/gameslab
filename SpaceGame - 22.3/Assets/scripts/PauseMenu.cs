using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System.Threading.Tasks;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] RectTransform pausePanelRect,pauseButtonRect;
    [SerializeField] float topPosY, middlePosY;
    [SerializeField] float tweenDuration;
    [SerializeField] CanvasGroup canvasGroup; //Dark panel canvas group

  public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        PausePanelIntro();
    }
    public void Home()
    {
        SceneManager.LoadScene("mainmenu");
        Time.timeScale = 1f;
    }
    public void Settings()
    {
        SceneManager.LoadScene("optionsmenu");
        Time.timeScale = 1f;
    }
    public async void Resume()
    {
        await PausePanelOutro();
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }   
    void PausePanelIntro()
    {
       canvasGroup.DOFade(1, tweenDuration).SetUpdate(true);
       pausePanelRect.DOAnchorPosY(middlePosY, tweenDuration).SetUpdate(true);
       pauseButtonRect.DOAnchorPosX(1500, tweenDuration).SetUpdate(true);
    }
    async Task PausePanelOutro()
    {
        canvasGroup.DOFade(0, tweenDuration).SetUpdate(true);
        await pausePanelRect.DOAnchorPosY(topPosY, tweenDuration).SetUpdate(true).AsyncWaitForCompletion();
        pauseButtonRect.DOAnchorPosX(1030, tweenDuration).SetUpdate(true);
    }
}
