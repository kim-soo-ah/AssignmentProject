using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerExtention : SingletonHandler<SceneManagerExtention>
{
    public void LoadScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
