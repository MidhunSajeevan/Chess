using Chess.Scripts.Core;
using UnityEngine;

public class Queen : IChessPiece
{
    Cell cell;
    public void HighlightPossibleMoves(ChessPlayerPlacementHandler placementHandler)
    {
        //Size of the board
        int boardSize = 8;

        // Define the possible moves relative to the queen's position (combination of rook and bishop movements)
        int[] rowOffsets = { 1, 1, 1, -1, -1, -1, 0, 0 };
        int[] colOffsets = { 1, -1, 0, 1, -1, 0, 1, -1 };

        for (int i = 0; i < rowOffsets.Length; i++)
        {
            int newRow = placementHandler.row;
            int newCol = placementHandler.column;

            while (true)
            {
                newRow += rowOffsets[i];
                newCol += colOffsets[i];

                if (!IsWithinBounds(newRow, newCol, boardSize)) break;

                // Check if there is a player at the target position
                cell = ChessBoardPlacementHandler.Instance.GetTile(newRow, newCol).GetComponent<Cell>();

                if (cell.IsOccupied && cell.Color == placementHandler.playerColor)
                {
                    break;
                }
                else if (cell.IsOccupied)
                {

                    // Enemy player, highlight as red
                    ChessBoardPlacementHandler.Instance.Highlight(newRow, newCol, Color.red);
                    break;


                }
                else
                {
                    // Empty tile, highlight as default color
                    ChessBoardPlacementHandler.Instance.Highlight(newRow, newCol, Color.green);
                }
            }
        }
    }

    private bool IsWithinBounds(int row, int col, int boardSize)
    {
        // Check if the position is within the bounds of the chessboard
        return row >= 0 && row < boardSize && col >= 0 && col < boardSize;
    }
}
