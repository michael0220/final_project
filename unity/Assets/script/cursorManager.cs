using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public Texture2D customCursor;
    Vector2 hotspot = Vector2.zero;
    public CursorMode cursorMode = CursorMode.Auto;

    private static CursorManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            Cursor.SetCursor(customCursor, hotspot, cursorMode);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
{
    if (customCursor != null)
    {
        Vector2 hotspot = new Vector2(420, 100);
        Cursor.SetCursor(customCursor, hotspot, CursorMode.Auto);
    }
}

}
