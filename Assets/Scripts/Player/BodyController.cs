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
        updateDistanceBetweenParts();
    }

    private void updateDistanceBetweenParts()
    {
        if (distance > parts.Count)
            for (int i = parts.Count; i < distance; i++)
                parts.AddLast(values.GetClone(new Entity(new Vector2())));
        else if (distance < parts.Count)
            for (int i = distance; i < parts.Count; i++)
                parts.RemoveLast();
    }

    public override Entity Advance(Entity entity)
    {
        if (entity == null || entity.position == null || parts == null)
            return entity;
        Entity lastElement = values;
        if (parts.Count == 0)
        {
            values = entity;
            return lastElement;
        }
        values = GameMain.GetInstance().GetByIndex(parts, parts.Count - 1);
        UpdateBodyWithoutFirst();
        UpdateBodyFirst(entity);
        return lastElement;
    }

    private void UpdateBodyFirst(Entity entity)
    {
        parts.First.Value.CopyPosition(entity.position);
    }

    private void UpdateBodyWithoutFirst()
    {
        Entity before;
        Entity part;
        for (int i = parts.Count - 1; i > 0; i--)
        {
            before = GameMain.GetInstance().GetByIndex(parts, i - 1);
            part = GameMain.GetInstance().GetByIndex(parts, i);
            if (part.position.Equals(before.position))
                continue;
            part.CopyPosition(before.position);
        }
    }
}
