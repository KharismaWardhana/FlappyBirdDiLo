using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Openning : MonoBehaviour
{
    private Animator m_animator;
    public Image GetReady;
    public Text counterDown;

    private void Start() {
        m_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            GetReady.gameObject.SetActive(true);
            counterDown.gameObject.SetActive(true);
            StartCoroutine(playGame());
        }    
    }

    IEnumerator playGame()
    {
        int count = -1;
        for(int i = 0; i < 4; i ++)
        {
            count++;
            counterDown.text = count.ToString();
            yield return new WaitForSeconds(1);
        }

        GetReady.gameObject.SetActive(false);
        SceneManager.LoadScene("Main");
        yield return null;
    }
}
