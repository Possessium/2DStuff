using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case : MonoBehaviour
{
    public Vector2Int Positions = new Vector2Int();
    public Vector2 playerSpawnPosition = new Vector2();

    [SerializeField] private CaseType currentCaseType;
    public CaseType CurrentCaseType { get { return currentCaseType; } }

    private void Awake()
    {
        Positions = new Vector2Int((int)transform.position.x, (int)transform.position.y);
        transform.name = "Case : " + Positions.x + ", " + Positions.y;

        playerSpawnPosition = Positions;
    }
}

public enum CaseType
{
    Ground,
    Wall
}
