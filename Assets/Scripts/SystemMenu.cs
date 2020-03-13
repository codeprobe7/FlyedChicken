using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemMenu : MonoBehaviour
{
    public GameObject systemMenu;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                systemMenu.SetActive(true);
            }
        }
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Back()
    {
        systemMenu.SetActive(false);
    }
}
