using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UserInterfaceController : MonoBehaviour
{
    // Start is called before the first frame update
    public void Quit()
    {
        Application.Quit();
    }
    public void Restart()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainScene");
        
    }
}
