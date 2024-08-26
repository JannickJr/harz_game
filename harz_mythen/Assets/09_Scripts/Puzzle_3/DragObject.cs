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

    // Adjusted values
    private Vector3 Adjusted(Vector2 point)
    {
        return new Vector3(point.x - 5.729004f, point.y + 15.414133f, 2.75391f);
    }

    // Positions for the six sprites
    private static readonly Vector2[] targetPositions = new Vector2[]
    {
        new Vector2(1.13f - 5.729004f, 3.31f + 15.414133f),
        new Vector2(-0.25f - 5.729004f, 3.468f + 15.414133f),
        new Vector2(1.51f - 5.729004f, 2.239f + 15.414133f),
        new Vector2(3.241f - 5.729004f, 1.731f + 15.414133f),
        new Vector2(2.986f - 5.729004f, 0.757f + 15.414133f),
        new Vector2(1.732f - 5.729004f, 0.521f + 15.414133f)
    };

    // Object to fade in when the condition is met
    public GameObject objectToFadeIn;
    public GameObject objectToFadeOut;
    public float fadeDuration = 1.0f;

    void Start()
    {
        mainCamera = Camera.main;
        fixedZ = transform.position.z; // Store the initial z-coordinate
        if (lines.Length > 0)
        {
            closestLine = FindClosestLine((Vector2)transform.position); // Initialize with the closest line
            sharedPoints = FindSharedPoints(); // Identify shared points
            originalPosition = transform.position;
            occupiedPositions.Add(originalPosition);
        }
        else
        {
            Debug.LogError("No lines defined in the lines array.");
        }

        // Initially set the object to be transparent
        SetObjectAlpha(objectToFadeIn, 0f);
    }

    void OnMouseDown()
    {
        offset = (Vector2)gameObject.transform.position - GetMouseWorldPosition();
        isDragging = true;
        occupiedPositions.Remove((Vector2)transform.position); // Remove from occupied positions when starting to drag

        // Ensure the sprite stays on the same sorting layer
        GetComponent<SpriteRenderer>().sortingOrder = 10; // Adjust sorting order if necessary
    }

    void OnMouseDrag()
    {
        if (isDragging && lines.Length > 0)
        {
            Vector2 mouseWorldPosition = GetMouseWorldPosition() + offset;

            Vector2 projectedPosition = ProjectOntoLine(mouseWorldPosition, closestLine);
            transform.position = new Vector3(projectedPosition.x, projectedPosition.y, fixedZ); // Maintain fixed z-coordinate

            // Calculate distances to start and end points of the closest line
            float distanceToStart = Vector2.Distance(transform.position, Adjusted(closestLine.start));
            float distanceToEnd = Vector2.Distance(transform.position, Adjusted(closestLine.end));

            // Object can only switch lines if it's near the start or end of the current line
            bool canChangeLine = (distanceToStart < snapThreshold) || (distanceToEnd < snapThreshold);

            if (canChangeLine)
            {
                // Only switch to a line that shares the start or end point with the current line
                Line newLine = FindClosestLineWithSharedPoint(mouseWorldPosition, closestLine);

                if (newLine.start != Vector2.zero || newLine.end != Vector2.zero)
                {
                    closestLine = newLine;
                }
            }
        }
    }

    void OnMouseUp()
    {
        if (isDragging && lines.Length > 0)
        {
            isDragging = false;
            float distanceToStart = Vector2.Distance(transform.position, Adjusted(closestLine.start));
            float distanceToEnd = Vector2.Distance(transform.position, Adjusted(closestLine.end));

            if (distanceToStart < snapThreshold && distanceToStart < distanceToEnd)
            {
                transform.position = Adjusted(closestLine.start);
            }
            else if (distanceToEnd < snapThreshold && distanceToEnd < distanceToStart)
            {
                transform.position = Adjusted(closestLine.end);
            }

            Vector2 newPosition = new Vector2(transform.position.x, transform.position.y);
            if (!occupiedPositions.Contains(newPosition))
            {
                occupiedPositions.Add(newPosition); // Add new position to occupied positions
            }
            else
            {
                transform.position = originalPosition; // Revert to original position if the new one is occupied
                occupiedPositions.Add(originalPosition); // Re-add original position to occupied positions
            }

            // Reset the sprite's sorting order
            GetComponent<SpriteRenderer>().sortingOrder = 0; // Reset to original sorting order

            // Check if all sprites are in the correct positions
            CheckForAllSpritesInPosition();
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
            Vector2 startAdjusted = new Vector2(Adjusted(line.start).x, Adjusted(line.start).y);
            Vector2 endAdjusted = new Vector2(Adjusted(line.end).x, Adjusted(line.end).y);

            float distanceToStart = Vector2.Distance(position, startAdjusted);
            float distanceToEnd = Vector2.Distance(position, endAdjusted);

            if (distanceToStart < minDistance)
            {
                minDistance = distanceToStart;
                closest = line;
            }

            if (distanceToEnd < minDistance)
            {
                minDistance = distanceToEnd;
                closest = line;
            }
        }

        return closest;
    }

    // Function to find the closest line that shares a start or end point with the current line
private Line FindClosestLineWithSharedPoint(Vector2 position, Line currentLine)
{
    Line closest = new Line();
    float minDistance = Mathf.Infinity;

    foreach (Line line in lines)
    {
        // Check if the line shares a start or end point with the current line
        bool sharesPoint = (line.start == currentLine.start || line.start == currentLine.end ||
                            line.end == currentLine.start || line.end == currentLine.end);

        if (sharesPoint)
        {
            Vector2 startAdjusted = new Vector2(Adjusted(line.start).x, Adjusted(line.start).y);
            Vector2 endAdjusted = new Vector2(Adjusted(line.end).x, Adjusted(line.end).y);

            float distanceToStart = Vector2.Distance(position, startAdjusted);
            float distanceToEnd = Vector2.Distance(position, endAdjusted);

            if (distanceToStart < minDistance)
            {
                minDistance = distanceToStart;
                closest = line;
            }

            if (distanceToEnd < minDistance)
            {
                minDistance = distanceToEnd;
                closest = line;
            }
        }
    }

    return closest;
}
    private Vector2 ProjectOntoLine(Vector2 position, Line line)
    {
        Vector3 adjustedStart = Adjusted(line.start);
        Vector3 adjustedEnd = Adjusted(line.end);

        Vector2 lineDirection = new Vector2(adjustedEnd.x, adjustedEnd.y) - new Vector2(adjustedStart.x, adjustedStart.y);
        lineDirection.Normalize();

        Vector2 toPosition = position - new Vector2(adjustedStart.x, adjustedStart.y);
        float projection = Vector2.Dot(toPosition, lineDirection);

        float lineLength = Vector2.Distance(new Vector2(adjustedStart.x, adjustedStart.y), new Vector2(adjustedEnd.x, adjustedEnd.y));
        float clampedProjection = Mathf.Clamp(projection, 0, lineLength);

        return new Vector3(adjustedStart.x, adjustedStart.y, adjustedStart.z) + new Vector3(lineDirection.x, lineDirection.y, 0) * clampedProjection;
    }

    private HashSet<Vector2> FindSharedPoints()
    {
        Dictionary<Vector2, int> pointCounts = new Dictionary<Vector2, int>();
        foreach (Line line in lines)
        {
            Vector3 adjustedStart = Adjusted(line.start);
            Vector3 adjustedEnd = Adjusted(line.end);

            Vector2 start2D = new Vector2(adjustedStart.x, adjustedStart.y);
            Vector2 end2D = new Vector2(adjustedEnd.x, adjustedEnd.y);

            if (pointCounts.ContainsKey(start2D))
            {
                pointCounts[start2D]++;
            }
            else
            {
                pointCounts[start2D] = 1;
            }

            if (pointCounts.ContainsKey(end2D))
            {
                pointCounts[end2D]++;
            }
            else
            {
                pointCounts[end2D] = 1;
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

    private void CheckForAllSpritesInPosition()
    {
        // Find all instances of DragObject in the scene
        DragObject[] allDragObjects = FindObjectsOfType<DragObject>();

        bool allInPosition = true;
        for (int i = 0; i < targetPositions.Length; i++)
        {
            bool positionMatched = false;
            foreach (DragObject dragObject in allDragObjects)
            {
                Vector2 currentPosition = new Vector2(dragObject.transform.position.x, dragObject.transform.position.y);
                if (Vector2.Distance(currentPosition, targetPositions[i]) < snapThreshold)
                {
                    positionMatched = true;
                    break;
                }
            }

            if (!positionMatched)
            {
                allInPosition = false;
                break;
            }
        }

        if (allInPosition)
        {
            StopCoroutine("FadeOutObject");
            StopCoroutine("FadeInObject");

            StartCoroutine(FadeOutObject(objectToFadeOut, fadeDuration));
            StartCoroutine(FadeInObject(objectToFadeIn, fadeDuration));
        }
    }

    private IEnumerator FadeInObject(GameObject obj, float duration)
    {
        float currentAlpha = obj.GetComponent<SpriteRenderer>().color.a;
        float startAlpha = currentAlpha;
        float endAlpha = 1.0f;

        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime / duration;
            float newAlpha = Mathf.Lerp(startAlpha, endAlpha, t);
            SetObjectAlpha(obj, newAlpha);
            yield return null;
        }

    }

    private IEnumerator FadeOutObject(GameObject obj, float duration)
    {
        obj.gameObject.SetActive(false);
        // Ensure object is fully visible at the start
        SetObjectAlpha(obj, 1.0f);

        float startAlpha = obj.GetComponent<SpriteRenderer>().color.a;
        float endAlpha = 0f;

        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime / duration;
            float newAlpha = Mathf.Lerp(startAlpha, endAlpha, t);
            SetObjectAlpha(obj, newAlpha);
            yield return null;
        }

        // Just to be sure, set the alpha to 0 at the end
        SetObjectAlpha(obj, 0f);
    }

    private void SetObjectAlpha(GameObject obj, float alpha)
    {
        SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            Color newColor = sr.color;
            newColor.a = alpha;
            sr.color = newColor;
        }
    }
}
