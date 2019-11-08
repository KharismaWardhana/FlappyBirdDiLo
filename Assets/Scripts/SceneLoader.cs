using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string name)
    {
        if (!string.IsNullOrEmpty(name))
        {
          SceneManager.LoadScene(name);
        }
    }

    private void Update() 
    {
      if(Input.GetKeyDown(KeyCode.Escape))
      {
        Application.Quit();
      }

      if(Input.GetKeyDown(KeyCode.P))
      {
        LoadScene("Main");
      }
    }
}