using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipSetter : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string Text;
    private bool UIMoused;
    private bool ScreenMoused;
    private bool wasScreenMoused = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (wasScreenMoused)
            wasScreenMoused = false;
        else
            ScreenMoused = false;
        //var mpos = new Vector2(Mouse.current.position.x.ReadValue(), Mouse.current.position.y.ReadValue());
        //var rect = GetComponent<RectTransform>().rect;
      // if (rect.Contains(mpos))
     /* if (moused)
        {
            Tooltip.Text = Text;
        } else if (Tooltip.Text == Text)
        {
            Tooltip.Text = "";
        }*/
    }

    public bool GetMoused()
    {
        return UIMoused || ScreenMoused;
    }

    public void ResetMoused()
    {
        UIMoused = ScreenMoused = false;
    }

    // UI
    public void OnPointerEnter(PointerEventData eventData)
    {
        UIMoused = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UIMoused = false;
    }
    
    // screenspace

    private void OnMouseOver()
    {
        ScreenMoused = wasScreenMoused = true;
    }

    private void OnMouseExit()
    {
        ScreenMoused = false;
    }
}
