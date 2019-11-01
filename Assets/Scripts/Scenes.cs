using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public Animator transitionAnim;
    public GameObject player;
    public string sceneName;
    private SceneController sc;

    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(LoadScene());
        print(other);
        sc = player.GetComponent<SceneController>();

    }

    IEnumerator LoadScene()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);

    }
}
