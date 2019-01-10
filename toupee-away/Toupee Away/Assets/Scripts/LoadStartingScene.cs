using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadStartingScene : MonoBehaviour {

    private void Start()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
