using System;
using UnityEngine;

namespace Chess.Scripts.Core {
    public class ChessPlayerPlacementHandler : MonoBehaviour {
        [SerializeField] public int row, column;
        [SerializeField] public Color playerColor;
        private Cell cell;
       
        private void Start() {
            transform.position = ChessBoardPlacementHandler.Instance.GetTile(row, column).transform.position;
            cell = ChessBoardPlacementHandler.Instance.GetTile(row,column).gameObject.GetComponent<Cell>();
            cell.IsOccupied = true;
            cell.Color = playerColor;
            cell.PiceName = this.gameObject.name;
        }
    }
}