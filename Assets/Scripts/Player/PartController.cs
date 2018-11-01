using UnityEngine;

public class PartController : MonoBehaviour, Advance {
    [HideInInspector]
    public Entity values;
    [HideInInspector]
    public Rigidbody2D rgb2d;

    protected virtual void Awake()
    {
        rgb2d = GetComponent<Rigidbody2D>();
        values = new Entity(rgb2d.position);
    }

    public virtual Entity Advance(Entity entity)
    {
        Entity lastValue = values;
        values = entity;
        return lastValue;
    }

    protected virtual void FixedUpdate()
    {
        rgb2d.position = values.position;
    }

    public Entity FillValues(Entity entity)
    {
        if (entity == null)
            entity = new Entity(new Vector2());
        if (entity.position == null)
            entity.position = new Vector2();
        entity.position.x = rgb2d.position.x;
        entity.position.y = rgb2d.position.y;
        return entity;
    }
}
