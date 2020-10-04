using UnityEngine;

public class LineModel
{
    public LineModel(float x1, float y1, float x2, float y2)
    {
        X1 = x1;
        Y1 = -y1;
        X2 = x2;
        Y2 = -y2;
    }

    public float X1 { get; set; }
    public float Y1 { get; set; }
    public float X2 { get; set; }
    public float Y2 { get; set; }
    public Vector2[] Points => new Vector2[]
    {
        new Vector2
        {
            x = X1, y = Y1
        },
        new Vector2
        {
            x = X2, y = Y2
        }        
    };
}
