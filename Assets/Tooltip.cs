using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class Tooltip : MonoBehaviour
{
    private string Text = " ";
    private HashSet<TooltipSetter> setters = new HashSet<TooltipSetter>();

    // Start is called before the first frame update
    void Start()
    {
        setters.UnionWith(Resources.FindObjectsOfTypeAll<TooltipSetter>());
    }

    public void Reset()
    {
        Text = " ";
    }

    public void AddSetters(GameObject o)
    {
        foreach (var ts in o.GetComponentsInChildren<TooltipSetter>())
            setters.Add(ts);
    }

    public void RemoveSetters(GameObject o)
    {
        foreach (var ts in o.GetComponentsInChildren<TooltipSetter>())
            setters.Remove(ts);
    }

    const int xPadding = 15;
    const int yPadding = 10;

    // Update is called once per frame
    void Update()
    {
        var lastText = Text;
        Text = " ";
        foreach (var obj in setters)
        {
            if (obj == null) continue; // when does this happen?
            if (!obj.enabled || !obj.gameObject.activeInHierarchy)
                obj.ResetMoused();
            else if (obj.GetMoused() && obj.Text != "")
            {
                Text = obj.Text;
                break;
            }
        }

        var textObj = transform.GetChild(1);
        var bgObj = transform.GetChild(0);

        var textText = textObj.GetComponent<TextMeshProUGUI>();
        textText.text = Text;

        bool active = Text != "";
        textObj.gameObject.SetActive(active);
        bgObj.gameObject.SetActive(active);
        if (!active)
        {
            return;
        }

        if (lastText != Text)
        {
            // Force the text to regenerate itself now so that we can
            // put an appropriately sized background behind it.
            textText.ForceMeshUpdate();
        }

        
        var mPos = Mouse.current.position.ReadValue();
        var bgRect = bgObj.GetComponent<RectTransform>();
        bgRect.sizeDelta = new Vector2(textText.renderedWidth + xPadding, textText.renderedHeight + yPadding);

        var bgBounds = bgRect.rect;


        var pos = new Vector2(mPos.x - bgBounds.width / 2 - 2, mPos.y + bgBounds.height/2 + 3);
        const int buffer = 10;
        var w = bgBounds.width / 2 + buffer;
        var h = bgBounds.height / 2 + buffer;
        if (pos.x < w)
        {
            // bound left
            pos.x = w;
        } else if (pos.x > Screen.width - w)
        {
            // bound right
            pos.x = Screen.width - w;
        }
        if (pos.y < h)
        {
            // bound bottom
            pos.y = h;
        } else if (pos.y > Screen.height - h)
        {
            // bound top
            pos.y = Screen.height - h;
        }
        transform.position = pos;

        var textRect = textObj.GetComponent<RectTransform>();
        textObj.localPosition = new Vector2((textRect.rect.width - bgRect.sizeDelta.x + xPadding) / 2,
                                           -(textRect.rect.height - bgRect.sizeDelta.y + yPadding) / 2);
    }
}
