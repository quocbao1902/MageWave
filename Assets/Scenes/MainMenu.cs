using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("Game");        
        Invoke("StartGame", 0.5f);
    }

    public void ExitGame()
    {
        Application.Quit();
        Invoke("QuitApplication", 0.5f);

#if UNITY_EDITOR
UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        animator.SetBool("isHovering", true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        animator.SetBool("isHovering", false);
    }

}
