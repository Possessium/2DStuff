using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public static MapManager Instance { get; private set; }

    [SerializeField] private Case[,] map;
    [SerializeField] private Vector2Int mapSize;
    [SerializeField] private Case currentCase;
    [SerializeField] private GameObject player;


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        InitMap();
    }

    private void InitMap()
    {
        Case[] _allCases = FindObjectsOfType<Case>();

        map = new Case[mapSize.x, mapSize.y];

        foreach (Case _case in _allCases)
        {
            map[_case.Positions.x, _case.Positions.y] = _case;
        }
    }

    public void MovePlayer(Direction _direction)
    {
        Case _nextCase = null;

        switch (_direction)
        {
            case Direction.Up:
                _nextCase = map[currentCase.Positions.x, currentCase.Positions.y + 1];
                break;
            case Direction.Down:
                _nextCase = map[currentCase.Positions.x, currentCase.Positions.y - 1];
                break;
            case Direction.Left:
                _nextCase = map[currentCase.Positions.x - 1, currentCase.Positions.y];
                break;
            case Direction.Right:
                _nextCase = map[currentCase.Positions.x + 1, currentCase.Positions.y];
                break;
        }

        if (_nextCase == null)
        {
            switch (_direction)
            {
                case Direction.Up:
                    Debug.LogWarning($"No case found at x: {currentCase.Positions.x} ; y: {currentCase.Positions.y + 1}");
                    break;
                case Direction.Down:
                    Debug.LogWarning($"No case found at x: {currentCase.Positions.x} ; y: {currentCase.Positions.y - 1}");
                    break;
                case Direction.Left:
                    Debug.LogWarning($"No case found at x: {currentCase.Positions.x - 1} ; y: {currentCase.Positions.y}");
                    break;
                case Direction.Right:
                    Debug.LogWarning($"No case found at x: {currentCase.Positions.x + 1} ; y: {currentCase.Positions.y}");
                    break;
            }
            return;
        }

        if (_nextCase.CurrentCaseType == CaseType.Ground)
        {
            player.transform.position = _nextCase.playerSpawnPosition;

            currentCase = _nextCase;
        }
    }
}

public enum Direction
{
    Up,
    Down,
    Left,
    Right
}
