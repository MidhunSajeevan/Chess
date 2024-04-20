using Chess.Scripts.Core;
using UnityEngine;

public class Pawn : IChessPiece
{
    Cell cell;
    public void HighlightPossibleMoves(ChessPlayerPlacementHandler placementHandler)
    {
        //Size of the board
        int boardSize = 8;

        // Define the possible moves relative to the pawn's position (forwards and captures)
        int[] rowOffsets = { 1, 1 }; // Forwards movement for white pawns
        int[] colOffsets = { 0, 1 }; // Left and right movement for captures

        if (placementHandler.playerColor ==  Color.black)
        {
            // Adjust offsets for black pawns (moving downwards and capturing left and right)
            rowOffsets[0] = -1;
            colOffsets[1] = -1;
        }

        for (int i = 0; i < rowOffsets.Length; i++)
        {
            int newRow = placementHandler.row + rowOffsets[i];
            int newCol = placementHandler.column + colOffsets[i];

            if (!IsWithinBounds(newRow, newCol, boardSize)) continue;

            // Check if there is a player at the target position
            cell = ChessBoardPlacementHandler.Instance.GetTile(newRow, newCol).GetComponent<Cell>();

            if (cell.IsOccupied)
            {
                // Enemy player, highlight as red
                ChessBoardPlacementHandler.Instance.Highlight(newRow, newCol, Color.red);
            }
            else
            {
                // Empty tile, highlight as default color
                ChessBoardPlacementHandler.Instance.Highlight(newRow, newCol, Color.green);
            }
        }
    }

    private bool IsWithinBounds(int row, int col, int boardSize)
    {
        // Check if the position is within the bounds of the chessboard
        return row >= 0 && row < boardSize && col >= 0 && col < boardSize;
    }
}
