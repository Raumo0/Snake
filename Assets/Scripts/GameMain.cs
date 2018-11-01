using System.Collections.Generic;
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

    public T GetByIndex<T>(LinkedList<T> list, int index)
    {
        if (list == null || list.Count == 0 || index < 0 || index >= list.Count)
            return default(T);
        int i = 0;
        foreach (var value in list)
        {
            if (i == index)
                return value;
            i++;
        }
        return default(T);
    }

    private static class SingletonHolder
    {
        public static readonly GameMain INSTANCE = new GameMain();
    }
}
