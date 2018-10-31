using System.Collections.Generic;
using UnityEngine;

public class BodyController : PartController {
    private LinkedList<Entity> parts;
    public int distance;

    protected override void Awake()
    {
        base.Awake();
        parts = new LinkedList<Entity>();
        if (distance == 0)
            distance = 5;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if (distance > parts.Count)
            for (int i = parts.Count; i < distance; i++)
                parts.AddLast(values.GetClone(new Entity(new Vector2())));
        else if (distance < parts.Count)
            for (int i = distance; i < parts.Count; i++)
                parts.RemoveLast();
    }
}
