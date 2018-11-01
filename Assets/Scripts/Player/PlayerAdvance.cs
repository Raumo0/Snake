using UnityEngine;

public class PlayerAdvance : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private bool move;
    private Vector2 direction;
    private Entity entity;
    private HeadController head;
    private BodyController tail;
    private Transform bodies;

    void Start()
    {
        direction = new Vector2(1, 0);
        entity = new Entity(new Vector2());
    }

    void Awake()
    {
        move = true;
        if (speed == 0f)
            speed = 5f;
        for (int i = 0; i < transform.childCount; i++)
            if (transform.GetChild(i).gameObject.CompareTag("PlayerHead"))
                head = transform.GetChild(i).gameObject.GetComponent<HeadController>();
            else if (transform.GetChild(i).gameObject.CompareTag("PlayerBody"))
                bodies = gameObject.transform.GetChild(i);
            else if (transform.GetChild(i).gameObject.CompareTag("PlayerTail"))
                tail = gameObject.transform.GetChild(i).gameObject.GetComponent<BodyController>();
    }

    private void FixedUpdate()
    {
        if (move)
        {
            entity = head.FillValues(entity);
            entity.position = head.Move(
                entity.position,
                direction,
                speed,
                1);
        }
        var variable = AdvanceBodies(head.values);
        AdvanceTail(variable);//todo:set last body
        entity = head.Advance(entity);
    }

    private Entity AdvanceBodies(Entity entity)
    {
        for (int i = 0; i < bodies.childCount; i++)
        {
            entity = bodies.GetChild(i).
                gameObject.GetComponent<BodyController>().Advance(entity);
            //todo: optimization
        }
        return entity;
    }

    private Entity AdvanceTail(Entity entity)
    {
        entity = tail.Advance(entity);
        return entity;
    }
}
