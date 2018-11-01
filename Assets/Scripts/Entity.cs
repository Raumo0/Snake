using UnityEngine;

public class Entity {
    public Vector2 position;

    public Entity(Vector2 position)
    {
        this.position = position;
    }

    public Entity GetClone(Entity entity)
    {
        if (entity == null)
            entity = new Entity(new Vector2());
        if (entity.position == null)
            entity.position = new Vector2();
        entity.position.x = position.x;
        entity.position.y = position.y;
        return entity;
    }
}
