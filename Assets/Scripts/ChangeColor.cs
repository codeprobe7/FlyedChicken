using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    [SerializeField]
    public float speed = 1f;

    private Color[] colorSet = new Color[] { Color.red, Color.green, Color.blue, Color.cyan, Color.yellow };
    private Color targetColor;
    private Renderer rend;
    private int randomNum;
    private int currentNum;

    // Start is called before the first frame update
    void Start()
    {
        rend = transform.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            while (currentNum == randomNum)
            {
                randomNum = Random.Range(0, colorSet.Length - 1);
                targetColor = colorSet[randomNum];
            }
            currentNum = randomNum;
        }
        rend.material.color = Color.Lerp(rend.material.color, targetColor, speed * Time.deltaTime);
    }
}
