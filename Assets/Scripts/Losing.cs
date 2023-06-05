using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Losing : MonoBehaviour
{
    // Start is called before the first frame update
    public void GameExit()
    {
        SceneManager.LoadScene(0);
    }
}
