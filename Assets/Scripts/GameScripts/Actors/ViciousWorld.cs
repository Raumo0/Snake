using UnityEngine;

public class ViciousWorld : MonoBehaviour {
    private Rigidbody2D rgb2d;
    private Vector2 point;

	void Awake () {
        rgb2d = GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate()
    {
        point = rgb2d.position;
        TransferFromBorders();
        rgb2d.position = point;
    }

    private void TransferFromBorders()
    {
        GameMain gameMain = GameMain.GetInstance();
        if (point.x > gameMain.ScreenRight)
            point.x = gameMain.ScreenLeft;
        else if (point.x < gameMain.ScreenLeft)
            point.x = gameMain.ScreenRight;
        if (point.y > gameMain.ScreenTop)
            point.y = gameMain.ScreenBottom;
        else if (point.y < gameMain.ScreenBottom)
            point.y = gameMain.ScreenTop;
    }
}
