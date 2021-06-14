using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public int sceneIndex;
    GameManager gameManager;
    private void Start()
    {
        gameManager = GameManager.Instance;
    }
    public void LoadSceneWithIndex()
    {
        gameManager.Reset();
        SceneManager.LoadScene(sceneIndex);
    }
}
