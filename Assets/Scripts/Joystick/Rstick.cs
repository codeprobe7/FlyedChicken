using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Rstick : Joystick, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    PlayerController Player;
    public static Vector3 direction;
    private LineRenderer line;

    protected override void Start()
    {
        base.Start();
        Player = targetobj.GetComponent<PlayerController>();
    }

    private void Update()
    {
    }

    public void FixedUpdate()
    {
        direction = new Vector3(Horizontal, Vertical, 0f);
        if (direction != Vector3.zero) Player.StickRightControll(direction);
    }
    public override void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public override void OnDrag(PointerEventData eventData)
    {
        base.OnDrag(eventData);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        Player.StickRightControllEnd();
    }
}