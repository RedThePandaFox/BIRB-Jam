using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Row
{
    public List<BoardCell> cells = new List<BoardCell>();
}

public class Board : MonoBehaviour
{
    public List<Row> rows;

    private void Start()
    {
        foreach (Transform row in transform)
        {
            Row tmprow = new Row();
            foreach (Transform cell in row)
            {
                BoardCell bc = cell.GetComponent<BoardCell>();
                bc.SetisMine(this.name.Contains("Player"));
                tmprow.cells.Add(cell.GetComponent<BoardCell>());
            }

            rows.Add(tmprow);
        }
    }

    public void ResetBoard()
    {
        foreach (var row in rows)
        {
            foreach (var cell in row.cells)
            {
                cell.ResetCell();
            }
        }
    }
}
