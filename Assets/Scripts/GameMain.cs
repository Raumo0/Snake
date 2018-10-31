using UnityEngine;

public class GameMain{
    public int ScreenTop { get; private set; }
    public int ScreenBottom { get; private set; }
    public int ScreenLeft { get; private set; }
    public int ScreenRight { get; private set; }

    private GameMain()
    {
        Camera camera = Camera.main;
        ScreenBottom = 0;
        ScreenLeft = 0;
        ScreenTop = camera.pixelHeight;
        ScreenRight = camera.pixelWidth;
    }

    public static GameMain GetInstance()
    {
        return SingletonHolder.INSTANCE;
    }

    private static class SingletonHolder
    {
        public static readonly GameMain INSTANCE = new GameMain();
    }
}
