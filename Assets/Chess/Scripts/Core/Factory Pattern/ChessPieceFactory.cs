public static class ChessPieceFactory
{
    public static IChessPiece GetChessPiece(string pieceName)
    {
        ChessBoardPlacementHandler.Instance.ClearHighlights();
        switch (pieceName)
        {
            //Return the knight product
            case "Knight":
                return new Knight();
            case "King":
                return new King();
            case "Rook":
                return new Rook();
            case "Pawn":
                return new Pawn();
            case "Bishop":
                return new Bishop();
            default:
                return null;
        }
        return null;
    }
}
