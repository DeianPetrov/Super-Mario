using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadNextLevel()
    {
        GameManager.Instance.LoadNextLevel();
    }
}
