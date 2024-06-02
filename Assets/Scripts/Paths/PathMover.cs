using AYellowpaper;
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

    public InterfaceReference<IEnemyPath> path;
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

        isMoving = true;
    }
    #endregion

    void Move(float distance)
    {
        Vector2 newPosition = path.Value.GetPosition((distanceTravelled += distance)/path.Value.GetLength());
        currentPosition = new Vector3(newPosition.x, newPosition.y, currentPosition.z);
    }

    IEnumerator movementCoroutine()
    {
        while (isMoving)
        {
            Move(speed * Time.deltaTime);

            yield return null;
        }
        coroutineRunning = false;
    }
}
