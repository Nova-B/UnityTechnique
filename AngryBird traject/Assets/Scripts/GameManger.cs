using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    #region Singleton class : GameManager
    public static GameManger Instance;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    #endregion

    Camera cam;

    public Ball ball;
    public Trajectory trajectory;
    [SerializeField] float pushForce = 4f;

    bool isDragging = false;

    Vector2 startPoint;
    Vector2 endPoint;
    Vector2 direction;
    Vector2 force;
    float distance;

    private void Start()
    {
        cam = Camera.main;
        ball.DeActivateRb();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            OnDragStart();
        }
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            OnDragEnd();
        }
        if (Input.GetMouseButton(0))
        {
            OnDrag();
        }

    }

    #region Drag
    private void OnDragStart()
    {
        ball.DeActivateRb();
        startPoint = cam.ScreenToViewportPoint(Input.mousePosition);

        Time.timeScale = 0.05f;
        trajectory.Show();
    }
    private void OnDrag()
    {
        endPoint = cam.ScreenToViewportPoint(Input.mousePosition);
        distance = Vector2.Distance(startPoint, endPoint);
        direction = (startPoint - endPoint).normalized;
        force = direction * distance * pushForce;

        trajectory.UpdateDots(ball.pos, force);

        //dirction Debug
        Debug.DrawLine(startPoint, endPoint);
    }
    private void OnDragEnd()
    {
        ball.ActivateRb();
        ball.Push(force);

        trajectory.Hide();
        Time.timeScale = 1f;

    }
    #endregion
}
