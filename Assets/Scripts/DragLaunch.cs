using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Ball))]
public class DragLaunch : MonoBehaviour
{
    private Ball ball;
    private float startTime, endTime;
    private Vector3 startPosition;
    private Vector3 endPosition;
    
	// Use this for initialization
	void Start ()
    {
        ball = GetComponent<Ball>();
	}
    public void DragStart()
    {
        if (!ball.inPlay)
        {
            startTime = Time.time;
            startPosition = Input.mousePosition;
        }
    }
    public void DragEnd()
    {
        if (!ball.inPlay)
        {
            endPosition = Input.mousePosition;
            endTime = Time.time;
            float dragDuration = endTime - startTime;
            float launchSpeedX = (endPosition.x - startPosition.x) / dragDuration;
            float launchSpeedY = (endPosition.y - startPosition.y) / dragDuration;
            Vector3 launchVelocity = new Vector3(launchSpeedX, 0.0f, launchSpeedY);
            ball.Launch(launchVelocity);
        }
        
    }
    public void MoveStart(float movex)
    {
        if (!ball.inPlay)
        {
            float yPos = ball.transform.position.y;
            float xPos = Mathf.Clamp(ball.transform.position.x + movex, -50, 50);
            float zPos = ball.transform.position.z;
            ball.transform.position = new Vector3(xPos, yPos, zPos);
        }
    }
}
