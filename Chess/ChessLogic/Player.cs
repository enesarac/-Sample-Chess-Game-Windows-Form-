namespace ChessLogic
{
    //Kimin kazandığı
    //Satranç parçalarının rengini gösterme
    public enum Player
    {
        None,   //Berabere
        White,
        Black
    }

    public static class PlayerExtensions
    {
        public static Player Opponent(this Player player)
        {
            return player switch
            {
                Player.White => Player.Black,
                Player.Black => Player.White,
                _ => Player.None,
            };
        }
    }
}
