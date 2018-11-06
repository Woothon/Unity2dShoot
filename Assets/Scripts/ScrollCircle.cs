using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScrollCircle : UnityEngine.UI.ScrollRect {

    // 半径
    private float radius = 0f;
    
    // 距离
    private float dis = 0.5f;

    // 运动
    private Vector2 movement = Vector2.zero;

    protected override void Start()
    {
        base.Start();

        // 能移动的半径 = 摇杆的宽 * dis;

        radius = content.sizeDelta.x * dis;
    }

    public override void OnDrag(PointerEventData eventData)
    {
        base.OnDrag(eventData);

        // 获取摇杆， 根据锚点的位置。
        var contentPosion = content.anchoredPosition;

        // 判断摇杆的位置 是否大于 半径
        if (contentPosion.magnitude > radius)
        {
            // 设置摇杆最远的位置
            contentPosion = contentPosion.normalized * radius;
            SetContentAnchoredPosition(contentPosion);
        }
      

        // 最后v2.x/y 就跟Input中的 Horizontal Vertical 获取的值一样
        movement = content.anchoredPosition.normalized;

    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);
        //松开鼠标虚拟摇杆回到原点,不再移动
        movement = Vector2.zero;
    }

    public Vector2 GetMovement()
    {
        return movement;
    }


}
