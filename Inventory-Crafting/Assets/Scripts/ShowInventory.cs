using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowInventory : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            OpenClose();
        }
    }

    public void OpenClose()
    {
        if (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
        }
        else
        {
            canvasGroup.interactable = true;
            canvasGroup.alpha = 1;
        }
    }
}
