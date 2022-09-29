using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionArrow : MonoBehaviour
{
    [SerializeField] private RectTransform[] options;
    private RectTransform rect;
    private int currentPostion;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    private void Update()
    {
        // dieu khien len xuong SelectionArrow
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            ChangePostion(-1);
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            ChangePostion(1);
        }

        // chon option
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Interact();
        }
    }


    private void ChangePostion(int _change)
    {
        currentPostion += _change;

        // dam bao currentPostion = [0, length - 1]
        if(currentPostion < 0)
        {
            currentPostion = options.Length - 1;
        }else if(currentPostion >= options.Length)
        {
            currentPostion = 0;
        }

        // thay doi vi tri mui ten khi dieu khien len/xuong
        rect.position = new Vector3(rect.position.x, options[currentPostion].position.y, 0);
    }

    private void Interact()
    {
        // bat su kien onClick vao cac Button
        options[currentPostion].GetComponent<Button>().onClick.Invoke();
    }
}
