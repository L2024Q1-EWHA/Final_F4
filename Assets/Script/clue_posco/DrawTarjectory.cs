using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawTarjectory : MonoBehaviour
{
    [SerializeField]
    private LineRenderer _lineRenderer;

    [SerializeField]
    [Range(3, 50)]
    private int _lineSegmentCount = 20;

    private List<Vector3> _linePoints = new List<Vector3>();

    #region Singleton

    public static DrawTarjectory Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    public void UpdataTarjectory(Vector3 forceVector, Rigidbody rigidbody, Vector3 startingPoint) {
        Vector3 velocity = (forceVector / rigidbody.mass) * Time.fixedDeltaTime;
        float FlightDuration = (2*velocity.y)/Physics.gravity.y;
        float stopTIme = FlightDuration / _lineSegmentCount;
        _linePoints.Clear();

        for (int i = 0; i < _lineSegmentCount; i++) 
        {
            float stopTimePassed = stopTIme * i;
            Vector3 MovementVector = new Vector3(
                    velocity.x*stopTimePassed,
                    velocity.y*stopTimePassed - 0.5f*Physics.gravity.y*stopTimePassed*stopTimePassed,
                    velocity.z*stopTimePassed
                );

            RaycastHit hit;
            if (Physics.Raycast(startingPoint, -MovementVector, out hit, MovementVector.magnitude)) {
                break;
            }
            _linePoints.Add( -MovementVector + startingPoint );
        }

        _lineRenderer.positionCount = _linePoints.Count;
        _lineRenderer.SetPositions(_linePoints.ToArray());
    }

    public void HideLine() {
        _lineRenderer.positionCount = 0;
    }
}
