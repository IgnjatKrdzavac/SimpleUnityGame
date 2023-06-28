using UnityEngine.SceneManagement;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public void ReplayGame(){
        SceneManager.LoadScene("Level4");
    }

    public void QuitGame(){
        Application.Quit();
    }
}
