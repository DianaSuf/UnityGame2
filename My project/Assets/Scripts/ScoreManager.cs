using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    private int _score = 0;
    public int Score
    {
        get { return _score; }
        set
        {
            _score = value;
            OnScoreChange.Invoke(value);
            scoreTextUI.ForEach((item) => {
                item.text = string.Format("{0} / {1}", value, MaxScore);
            });
            scoreImageUI.fillAmount = (float)Score / MaxScore;
        }
    }

    public List<TextMeshProUGUI> scoreTextUI = null;
    public Image scoreImageUI = null;
    public static UnityEvent<int> OnScoreChange = new();

    public List<int> starsThreshold = new List<int>() { 0, 0, 0 };
    public int MaxScore => starsThreshold.LastOrDefault();

    public static ScoreManager Instance = null;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // TimeCounter.OnTimeUp.AddListener(ProccessStarsAndSnow);

        Movement.OnFinish.AddListener(ProccessStarsAndSnow);

        // Movement.OnEnterEnemy.AddListener((enemy) => ProccessStarsAndSnow());
    }

    public int GetStars()
    {
        int stars = 0;
        starsThreshold.ForEach((threshold) =>
        {
            if (Score >= threshold) stars += 1;
        });
        if (stars > 3) throw new System.Exception("There should be exactly 3 star thresholds");
        return stars;
    }

    public void ProccessStarsAndSnow()
    {
        int stars = GetStars();

        LevelManager.Instance.saveStars(stars);

        LevelManager.Instance.addSnow(5 * stars);
    }
}
