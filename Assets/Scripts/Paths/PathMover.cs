using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Attach this component to anything if you want it to move along a path
/// The main way of interacting with this component is by setting the isMoving boolean, or by changing the speed float
/// </summary>
public class PathMover : MonoBehaviour
{
    
    
    [SerializeField] float baseSpeed = 1; //how many units per second this thing moves along the path
    private bool IsMoving = false; //has a public setter/getter
    public IEnemyPath parentPath; //the path that this object is set to move along
    [HideInInspector] public float speed; // the actual speed this object is moving, we might want to apply slow effects or freeze effects. Changing this will slow them down


    #region private data
    float distanceTravelled = 0;
    Coroutine movementRoutine;
    bool coroutineRunning = false;
    #endregion

    #region getters/setters
    public bool isMoving
    {
        get { return IsMoving; }
        set { IsMoving = value; 
            if (isMoving && !coroutineRunning)
            {
                movementRoutine = StartCoroutine("movementCoroutine");
            }
        
        }
    }

    Vector3 currentPosition
    {
        get { return transform.position; }
        set
        {
            transform.position = value;
        }
    }
    #endregion

    #region Monobehavior Callbacks
    void OnEnable()
    {
        speed = baseSpeed;
    }
    #endregion

    void Move(float amount)
    {
        Vector2 newPosition = parentPath.GetPosition(distanceTravelled += amount);
        currentPosition = new Vector3(newPosition.x, newPosition.y, currentPosition.z);
    }

    IEnumerator movementCoroutine()
    {
        while (isMoving)
        {
            Move(speed);

            yield return null;
        }
        coroutineRunning = false;
    }
}
