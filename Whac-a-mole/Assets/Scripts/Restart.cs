using UnityEngine.SceneManagement;
using UnityEngine;

public class Restart : MonoBehaviour
{
    //Restart the level
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
