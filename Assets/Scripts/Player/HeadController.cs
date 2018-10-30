using UnityEngine;

public class HeadController : PartController {
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public Vector2 Move(Vector2 point, Vector2 direction, float speed, float acceleration)
    {
        point.x += direction.x * speed * acceleration;
        point.y += direction.y * speed * acceleration;
        return point;
    }
}
