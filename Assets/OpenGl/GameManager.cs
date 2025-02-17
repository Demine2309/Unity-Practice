using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("reset.....");
            Enemy.enemiesDestroyed = 0;
            ResetGame();
        }
    }

    private void ResetGame()
    {
        // Tải lại scene hiện tại
        SceneManager.LoadScene(0);
    }
}
