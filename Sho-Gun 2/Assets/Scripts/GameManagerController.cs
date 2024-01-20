using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    public int score;
    private void Start()
    {
        
    }
    private void Update()
    {
        scoreText.text=score.ToString();
    }
}
