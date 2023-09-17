using UnityEngine;

public static class Bezie
{
    public static Vector2 GetPoint(Vector2 p0, Vector2 p1, Vector2 p2, float t)
    {
        Vector2 p01 = Vector2.Lerp(p0, p1, t);
        Vector2 p12 = Vector2.Lerp(p1, p2, t);

        Vector2 p012 = Vector2.Lerp(p01, p12, t);

        return p012;
    }
}
