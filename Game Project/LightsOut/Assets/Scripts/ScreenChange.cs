using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenChange : MonoBehaviour {
    public void LoadScene(int level)
    {
        Application.LoadLevel(level);
    }

}
