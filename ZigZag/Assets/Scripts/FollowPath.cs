using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour {

    //Source of Following the Path Code and How it Works: https://www.youtube.com/watch?v=a5FlAdWVlo4&t=145s
    #region Enum
    public enum MovementType
    {
        MoveTowards,
        LerpTowards
    }
    #endregion

    #region Public Variables
    public MovementType Type = MovementType.MoveTowards;
    public MovementPath MyPath;
    public float Speed = 1;
    public float MaxDistanceToGoal = 0.1f;
    #endregion

    #region Private Variables
    private IEnumerator<Transform> pointInPath;
    #endregion

    #region Main Methods
    private void Start()
    {
        //GameManager.instance.gameOver = false;

        if (MyPath == null)
        {
            Debug.LogError("Movement Path cannot be null, I must have a path to follow", gameObject);
            return;
        }

        pointInPath = MyPath.GetNextPathPoint();

        pointInPath.MoveNext();

        if (pointInPath.Current == null)
        {
            Debug.LogError("A path must have points in it to follow", gameObject);
            return;
        }

        transform.position = pointInPath.Current.position;
    }

    private void Update()
    {
        if (pointInPath == null || pointInPath.Current == null)
            return;

        if (Type == MovementType.MoveTowards)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointInPath.Current.position, Time.deltaTime * Speed);
        }
        else if (Type == MovementType.LerpTowards)
        {
            transform.position = Vector3.Lerp(transform.position, pointInPath.Current.position, Time.deltaTime * Speed);
        }


        var distanceSquared = (transform.position - pointInPath.Current.position).sqrMagnitude;
        if (distanceSquared < MaxDistanceToGoal * MaxDistanceToGoal)
            pointInPath.MoveNext();
    }

    #endregion
}
