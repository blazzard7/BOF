using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public Direction direction;
    private RoomVariants variants; 
    private int rand;
    private bool spawned = false;

    public static RoomSpawner mainRoom;

    private static List<Vector2> occupiedPositions = new List<Vector2>();

    private void Start()
    {
        variants = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomVariants>();

        if (mainRoom == null)
        {
            mainRoom = this;
        }

        Invoke("Spawn", 1f);
    }

    public void Spawn()
    {
        if (!spawned)
        {
            Vector2 markerPosition = new Vector2(transform.position.x, transform.position.y);

            if (occupiedPositions.Contains(markerPosition))
            {
                
                return;
            }

            SetRoomDirection();

            if (direction == Direction.Top)
            {
                rand = Random.Range(0, variants.topRooms.Length);
                Instantiate(variants.topRooms[rand], transform.position, variants.topRooms[rand].transform.rotation);
            }
            else if (direction == Direction.Bottom)
            {
                rand = Random.Range(0, variants.bottomRooms.Length);
                Instantiate(variants.bottomRooms[rand], transform.position, variants.bottomRooms[rand].transform.rotation);
            }
            else if (direction == Direction.Right)
            {
                rand = Random.Range(0, variants.rightRooms.Length);
                Instantiate(variants.rightRooms[rand], transform.position, variants.rightRooms[rand].transform.rotation);
            }
            else if (direction == Direction.Left)
            {
                rand = Random.Range(0, variants.leftRooms.Length);
                Instantiate(variants.leftRooms[rand], transform.position, variants.leftRooms[rand].transform.rotation);
            }

            occupiedPositions.Add(markerPosition);

            spawned = true;
        }
    }

    private void SetRoomDirection()
    {
        if (mainRoom != null)
        {
            if (transform.position.x < mainRoom.transform.position.x)
            {
                direction = Direction.Right;
            }
            else if (transform.position.x > mainRoom.transform.position.x)
            {
                direction = Direction.Left;
            }
            else if (transform.position.y > mainRoom.transform.position.y)
            {
                direction = Direction.Bottom;
            }
            else if (transform.position.y < mainRoom.transform.position.y)
            {
                direction = Direction.Top; 
            }
            else
            {
                direction = Direction.None; 
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("RoomPoint"))
        {
            RoomSpawner otherSpawner = other.GetComponent<RoomSpawner>();
            if (otherSpawner != null && otherSpawner.spawned)
            {
                return;
            }
        }
    }
}

public enum Direction
{
    Top,
    Bottom,
    Left,
    Right,
    None
}
