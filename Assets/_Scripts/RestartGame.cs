using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public void MoveToStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 10);
    }
}
