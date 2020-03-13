using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Lstick : Joystick, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    PlayerController Player;
    protected override void Start()
    {
        base.Start();
        Player = targetobj.GetComponent<PlayerController>();
    }

    public void FixedUpdate()
    {
        if (Horizontal != 0f) Player.StickLeftContorll(Horizontal);
        
    }
    public override void OnPointerDown(PointerEventData eventData)
    {
        if (PlayerController.isStickControlling) return;
        OnDrag(eventData);
    }

    public override void OnDrag(PointerEventData eventData)
    {
        base.OnDrag(eventData);
        ;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        Player.StickleftControllEnd();
    }
}