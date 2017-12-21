using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class ArrowController: MonoBehaviour
{
    public GameObject Arrow;
    public GameObject Source;
    public float MaxFlyDistance;
    private void Start()
    {
        
    }

    private void Update()
    {
        if (!Arrow)
            return;
        if (Input.GetMouseButtonDown(0))
        {
            var targetPos = GameSystem.Current.MainCamera.ScreenToWorldPoint(Input.mousePosition);
            var src = new Vector3(0, 0, 0);
            if (Source)
                src = Source.transform.position;
            var dir = targetPos.ToVector2() - src.ToVector2();
            var arrow = Instantiate(Arrow, src, Quaternion.identity) as GameObject;
            arrow.GetComponent<Arrow>().Target = dir.normalized.ToVector3() * MaxFlyDistance + src;
        }
    }

}