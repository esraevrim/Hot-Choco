using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public GameObject mainMenuPanel,timePanel;
    public GameObject startButton;
    public Image targetMainMenu, note;
    public Sprite[] mainMenus;
    public Player player;

    public void ButtonPressed()
    {
        Scene CurrentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(CurrentScene.buildIndex);
    }

    public void StartGame()
    {
        startButton.SetActive(false);
        StartCoroutine(MainMenuAnim());
    }

    IEnumerator MainMenuAnim()
    {
        for (int i = 0; i < mainMenus.Length; i++)
        {
            ShowImage(i);
            yield return new WaitForSeconds(0.3f);
        }

        float timer = 0f;
        float duration = 5.0f; 

        while (timer < duration)
        {
            note.transform.Translate(Vector2.up * 2f * Time.deltaTime);
            timer += Time.deltaTime;
            yield return null;
        }

        StopAnimation();
        timePanel.SetActive(true);
    }

    public void StopAnimation()
    {
        player.canMove = true;
        mainMenuPanel.SetActive(false);
        player.notedGrabbed = true;
    }

    public void ShowImage(int index)
    {
        targetMainMenu.sprite = mainMenus[index];
    }
}