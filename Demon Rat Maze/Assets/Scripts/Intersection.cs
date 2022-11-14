using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction { North, West, East, South };

public class Intersection
{
    int id = 0;
    Direction approached_direction;
    Intersection north_intersection;
    Intersection west_intersection;
    Intersection east_intersection;
    Intersection south_intersection;
    Intersection forward_intersection;
    Intersection left_intersection;
    Intersection right_intersection;
    Intersection back_intersection;

    bool is_goal = false;
    bool seen_before = false;
    public int goal_number = 0;

    Sprite landmark;


    public void initialize(int n_id, Intersection n_north_intersection, Intersection n_west_intersection, 
                           Intersection n_east_intersection, Intersection n_south_intersection, Sprite n_landmark)
    {
        id = n_id;
        north_intersection = n_north_intersection;
        west_intersection = n_west_intersection;
        east_intersection = n_east_intersection;
        south_intersection = n_south_intersection;
        approached_direction = Direction.South;

        forward_intersection = north_intersection;
        left_intersection = west_intersection;
        right_intersection = east_intersection;
        back_intersection = south_intersection;

        int num_available_directions = 0;
        if (forward_intersection != null)
            num_available_directions++;
        if (left_intersection != null)
            num_available_directions++;
        if (right_intersection != null)
            num_available_directions++;
        if (back_intersection != null)
            num_available_directions++;
        if (num_available_directions == 1 && id != 51)
            is_goal = true;

        landmark = n_landmark;
    }

    public void moveToIntersection(Direction n_approached_direction)
    {
        approached_direction = n_approached_direction;

        if (is_goal)
        {
            landmark = Navigator.S.getGoalSprite();
            Navigator.S.foundMeat(seen_before, goal_number);
        }
        if (!seen_before)
        {
            seen_before = true;
        }

        // Update the relative directional intersections
        if (approached_direction == Direction.South)
        {
            forward_intersection = north_intersection;
            left_intersection = west_intersection;
            right_intersection = east_intersection;
            back_intersection = south_intersection;
        }
        else if (approached_direction == Direction.East)
        {
            forward_intersection = west_intersection;
            left_intersection = south_intersection;
            right_intersection = north_intersection;
            back_intersection = east_intersection;
        }
        else if (approached_direction == Direction.West)
        {
            forward_intersection = east_intersection;
            left_intersection = north_intersection;
            right_intersection = south_intersection;
            back_intersection = west_intersection;
        }
        else if (approached_direction == Direction.North)
        {
            forward_intersection = south_intersection;
            left_intersection = east_intersection;
            right_intersection = west_intersection;
            back_intersection = north_intersection;
        }
    }

    public bool isGoal()
    {
        return is_goal;
    }

    // Get the relative intersections based off of how the player approached the intersection
    public Intersection getForward()
    {
        return forward_intersection;
    }

    public Intersection getLeft()
    {
        return left_intersection;
    }

    public Intersection getRight()
    {
        return right_intersection;
    }

    public Intersection getBack()
    {
        return back_intersection;
    }

    public int getID()
    {
        return id;
    }

    public Direction getForwardDirection()
    {
        if (approached_direction == Direction.South)
            return Direction.North;
        if (approached_direction == Direction.West)
            return Direction.East;
        if (approached_direction == Direction.East)
            return Direction.West;
        return Direction.South;
    }

    public Direction getLeftDirection()
    {
        if (approached_direction == Direction.South)
            return Direction.West;
        if (approached_direction == Direction.West)
            return Direction.North;
        if (approached_direction == Direction.East)
            return Direction.South;
        return Direction.East;
    }

    public Direction getRightDirection()
    {
        if (approached_direction == Direction.South)
            return Direction.East;
        if (approached_direction == Direction.West)
            return Direction.South;
        if (approached_direction == Direction.East)
            return Direction.North;
        return Direction.West;
    }

    public Direction getBackDirection()
    {
        if (approached_direction == Direction.South)
            return Direction.South;
        if (approached_direction == Direction.West)
            return Direction.West;
        if (approached_direction == Direction.East)
            return Direction.East;
        return Direction.North;
    }

    public Sprite getLandmarkSprite()
    {
        return landmark;
    }
}
