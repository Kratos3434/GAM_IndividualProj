using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TooltipController : MonoBehaviour
{
    public static TooltipController instance;
    public TextMeshProUGUI text;
    // Start is called before the first frame update

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        } else
        {
            instance = this;
        }
    }

    void Start()
    {
        Cursor.visible = true;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Input.mousePosition;
    }

    public void setToolTipText(string message)
    {
        gameObject.SetActive (true);
        text.text = message;
    }

    public void HideToolTip()
    {
        gameObject.SetActive(false);
        text.text = string.Empty;
    }
}
