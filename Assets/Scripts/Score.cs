using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public static int score;
    int starPoint1 = 100;
    int starPoint2 = 500;
    int starPoint3 = 1000;

    [SerializeField] GameObject star1;
    [SerializeField] GameObject star2;
    [SerializeField] GameObject star3;

    [SerializeField] private TextMeshProUGUI scoreText;
    void Update()
    {
        scoreText.text = score.ToString();

        if (score >= starPoint1)
        {
            star1.SetActive(true);
        }
        if (score >= starPoint2)
        {
            star2.SetActive(true);
        }
        if (score >= starPoint3)
        {
            star3.SetActive(true);
        }
    }
  
}
