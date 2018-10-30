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

    void Start()
    {
        direction = new Vector2(1, 0);
        entity = new Entity(new Vector2());
    }

    void Awake()
    {
        move = true;
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.CompareTag("PlayerHead"))
            {
                head = transform.GetChild(i).gameObject.GetComponent<HeadController>();
            }
        }
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
        entity = head.Advance(entity);
    }
}
