using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [Header("Panels")]
    public GameObject pausePanel;
    public List<GameObject> gameOverPanels;
    public bool IsPaused => pausePanel.activeSelf;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        Movement.OnFinish.AddListener(() =>
        {
            ShowGameover();
        });

        Movement.OnEnterEnemy.AddListener((enemy) =>
        {
            ShowGameover(true);
        });

        TimeCounter.OnTimeUp.AddListener(() =>
        {
            ShowGameover(true);
        });
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePausePanel();
        }
    }

    public void TogglePausePanel()
    {
        pausePanel.SetActive(!pausePanel.activeSelf);
        Time.timeScale = pausePanel.activeSelf ? 0f : 1f;
    }

    public void ResumePause()
    {
        if (!pausePanel.activeSelf) return;
        Time.timeScale = 1f;
    }

    public void ShowGameover(bool defeat = false)
    {
        if (gameOverPanels.Count != 4) throw new System.Exception("There should be a four gameover panels");

        if (defeat)
        {
            gameOverPanels[0].SetActive(true);
            Time.timeScale = 0f;
            return;
        }

        int stars = ScoreManager.Instance.GetStars();
        gameOverPanels[stars].SetActive(true);
        Time.timeScale = 0f;
    }
}
