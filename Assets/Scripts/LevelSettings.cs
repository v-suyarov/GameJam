using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Borders
{
    LEFT,
    TOP,
    RIGHT,
    BOTTOM,
}
public class LevelSettings : MonoBehaviour
{
   
    public static LevelSettings Instance { get; private set; }
    [SerializeField] private int levelSize =100;
    [SerializeField] private int enemysCount = 90;
    [SerializeField] private int vegetationCount = 90;
    [SerializeField] private Transform backGround;
    public PolygonCollider2D CameraConfiner { get; private set; }
    public Dictionary<Borders,float> borders { get; private set; } = new Dictionary<Borders,float>();
    void Awake()
    {
        if (!Instance)
        {
            
            Instance = this;
           
            Initialize();
        }
        else
        {
            Destroy(gameObject);          
        }

        
    }
    private void Initialize()
    {

        InitializeBorders();
        InitializeBackground();
       

    }
     public int GetLevelSize()
    {
        return levelSize;
    }
    public int GetEnemysCount()
    {
        return enemysCount;
    }
    public int GetVegetationCount()
    {
        return vegetationCount;
    }
    private void InitializeBorders()
    {
        CameraConfiner = transform.gameObject.GetComponent<PolygonCollider2D>();
        
        borders.Add(Borders.LEFT, -levelSize / 2);
        borders.Add(Borders.TOP, levelSize / 2);
        borders.Add(Borders.RIGHT, levelSize / 2);
        borders.Add(Borders.BOTTOM, -levelSize / 2);


        Vector2[] posPoint = new Vector2[CameraConfiner.points.Length];

        posPoint[0] = new Vector3(borders[Borders.LEFT], borders[Borders.BOTTOM], 0);
        posPoint[1] = new Vector3(borders[Borders.LEFT], borders[Borders.TOP], 0);
        posPoint[2] = new Vector3(borders[Borders.RIGHT], borders[Borders.TOP], 0);
        posPoint[3] = new Vector3(borders[Borders.RIGHT], borders[Borders.BOTTOM], 0);

       
        CameraConfiner.SetPath(0, posPoint);
    }
    private void InitializeBackground()
    {
        backGround.localScale = new Vector3(levelSize, levelSize, 1);
    }
    public bool isInsideBorders(Vector3 target)
    {
        bool result = true;

            if (target.x < LevelSettings.Instance.borders[Borders.LEFT]
            || target.x > LevelSettings.Instance.borders[Borders.RIGHT]
            || target.y < LevelSettings.Instance.borders[Borders.BOTTOM]
            || target.y > LevelSettings.Instance.borders[Borders.TOP])
            {
                result = false;
            }
        return result;
    }
}
