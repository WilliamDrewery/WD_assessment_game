using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManagerController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    public int score;
    private void Update()
    {
        scoreText.text=score.ToString();
    }
}
