using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector2 offset;
    private Camera mainCamera;
    private float fixedZ;

    [System.Serializable]
    public struct Line
    {
        public Vector2 start;
        public Vector2 end;
    }

    public Line[] lines; // Array of lines
    public float snapThreshold = 1.0f; // Distance within which the object will snap to the start or end of a line
    public float lineChangeThreshold = 2.0f; // Distance within which the object can switch to another line
    public static HashSet<Vector2> occupiedPositions = new HashSet<Vector2>(); // Set of positions occupied by objects

    private Line closestLine; // The closest line to the object
    private bool isDragging = false;
    private HashSet<Vector2> sharedPoints; // Points that are shared between lines
    private Vector2 originalPosition;

    void Start()
    {
        mainCamera = Camera.main;
        fixedZ = transform.position.z; // Store the initial z-coordinate
        if (lines.Length > 0)
        {
            closestLine = lines[0]; // Initialize with the first line
            sharedPoints = FindSharedPoints(); // Identify shared points
            originalPosition = transform.position;
            occupiedPositions.Add(originalPosition);
        }
        else
        {
            Debug.LogError("No lines defined in the lines array.");
        }
    }

    void OnMouseDown()
    {
        offset = (Vector2)gameObject.transform.position - GetMouseWorldPosition();
        isDragging = true;
        occupiedPositions.Remove((Vector2)transform.position); // Remove from occupied positions when starting to drag
    }

    void OnMouseDrag()
    {
        if (isDragging && lines.Length > 0)
        {
            Vector2 mouseWorldPosition = GetMouseWorldPosition() + offset;

            Vector2 projectedPosition = ProjectOntoLine(mouseWorldPosition, closestLine);
            transform.position = new Vector3(projectedPosition.x, projectedPosition.y, fixedZ); // Maintain fixed z-coordinate

            float distanceToStart = Vector2.Distance(transform.position, closestLine.start);
            float distanceToEnd = Vector2.Distance(transform.position, closestLine.end);

            bool canChangeLine = (sharedPoints.Contains(closestLine.start) && distanceToStart < lineChangeThreshold) ||
                                 (sharedPoints.Contains(closestLine.end) && distanceToEnd < lineChangeThreshold);

            if (canChangeLine)
            {
                closestLine = FindClosestLine(mouseWorldPosition);
            }
        }
    }

    void OnMouseUp()
    {
        if (isDragging && lines.Length > 0)
        {
            isDragging = false;
            float distanceToStart = Vector2.Distance(transform.position, closestLine.start);
            float distanceToEnd = Vector2.Distance(transform.position, closestLine.end);

            if (distanceToStart < snapThreshold && distanceToStart < distanceToEnd)
            {
                transform.position = new Vector3(closestLine.start.x, closestLine.start.y, fixedZ);
            }
            else if (distanceToEnd < snapThreshold && distanceToEnd < distanceToStart)
            {
                transform.position = new Vector3(closestLine.end.x, closestLine.end.y, fixedZ);
            }

            Vector2 newPosition = transform.position;
            if (!occupiedPositions.Contains(newPosition))
            {
                occupiedPositions.Add(newPosition); // Add new position to occupied positions
            }
            else
            {
                transform.position = originalPosition; // Revert to original position if the new one is occupied
                occupiedPositions.Add(originalPosition); // Re-add original position to occupied positions
            }
        }
    }

    private Vector2 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = -mainCamera.transform.position.z; // Maintain the camera's z distance
        return mainCamera.ScreenToWorldPoint(mousePoint);
    }

    private Line FindClosestLine(Vector2 position)
    {
        Line closest = lines[0];
        float minDistance = Mathf.Infinity;

        foreach (Line line in lines)
        {
            Vector2 projectedPosition = ProjectOntoLine(position, line);
            float distance = Vector2.Distance(position, projectedPosition);

            if (distance < minDistance)
            {
                minDistance = distance;
                closest = line;
            }
        }

        return closest;
    }

    private Vector2 ProjectOntoLine(Vector2 position, Line line)
    {
        Vector2 lineDirection = line.end - line.start;
        lineDirection.Normalize();

        Vector2 toPosition = position - line.start;
        float projection = Vector2.Dot(toPosition, lineDirection);

        float lineLength = Vector2.Distance(line.start, line.end);
        float clampedProjection = Mathf.Clamp(projection, 0, lineLength);

        return line.start + lineDirection * clampedProjection;
    }

    private HashSet<Vector2> FindSharedPoints()
    {
        Dictionary<Vector2, int> pointCounts = new Dictionary<Vector2, int>();
        foreach (Line line in lines)
        {
            if (pointCounts.ContainsKey(line.start))
            {
                pointCounts[line.start]++;
            }
            else
            {
                pointCounts[line.start] = 1;
            }

            if (pointCounts.ContainsKey(line.end))
            {
                pointCounts[line.end]++;
            }
            else
            {
                pointCounts[line.end] = 1;
            }
        }

        HashSet<Vector2> sharedPoints = new HashSet<Vector2>();
        foreach (var pointCount in pointCounts)
        {
            if (pointCount.Value > 1)
            {
                sharedPoints.Add(pointCount.Key);
            }
        }

        return sharedPoints;
    }
}
