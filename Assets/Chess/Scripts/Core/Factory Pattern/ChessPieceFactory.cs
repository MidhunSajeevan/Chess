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
            // Add cases for other chess pieces as needed
            default:
                return null;
        }
        return null;
    }
}
