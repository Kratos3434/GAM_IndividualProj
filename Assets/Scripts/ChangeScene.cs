using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public static void MoveToScene(int SceneID)
    {
        SceneManager.LoadScene(SceneID);
    }

}
// https://www.youtube.com/watch?v=EMo-MaKkP9s