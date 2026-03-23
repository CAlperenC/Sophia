using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void LoadGameScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
