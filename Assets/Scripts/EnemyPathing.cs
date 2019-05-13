using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyPathing : MonoBehaviour
{
    // Establishes pathing for enemies follow.
    // Pathing is based on a list of target waypoints set in the game engine.

    // Configuration parameters.
    WaveConfig waveConfig;
    List<Transform> waypoints;

    // Declare variables.
    int waypointsIndex = 0;
    bool didPlayerDie;

    void Start() // Set enemy position to first waypoint position.
    {
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointsIndex].transform.position;
    }

    void Update()
    {
        Move();
    }

    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
    }

    private void Move() // Creates a function to move enemy to target waypoint.
    {
        if (waypointsIndex <= waypoints.Count - 1) // If there are any waipoints left:
        {
            var targetPosition = waypoints[waypointsIndex].transform.position; // Target position = current waypoint position.
            var movementThisFrame = waveConfig.GetMovementSpeed() * Time.deltaTime; // Makes movement time-independent.
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame); // Moves towards target position.

            if (transform.position == targetPosition) // Checking if target waypoint's position has been reached.
            {
                waypointsIndex++;
            }
        }
        else // Destroy object if no more waypoints left.
        {
            Destroy(gameObject);
        }
    }
}
