using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints;
    int currentWaypointIndex = 0;

    [SerializeField] float speed = 1f;

    /* poruszanie sie obiektu od jednego waypoints'a do drugiego.
     * Sprawdzamy jak daleko jestesmy od waypointa. Jezeli go dotkniemy kieruje sie w strone drugiego.
     * Nastepnie Poruszamy sie ('MoveTowards') do aktywnego waypointa obliczajac aktualna pozycje do pozycji waypointa i mnoznac wartosc speed przez Time.deltaTime (niezaleznie od FPS stala wartosc)*/

    private void Update()
    {
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].transform.position) < 0.1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, speed * Time.deltaTime);
    }
}
