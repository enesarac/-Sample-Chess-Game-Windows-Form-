using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
    public class Board
    {
        //Dizi private olduğu için dışarıdan erişilemez
        //Erişim satır ve sütun alan indexer tarafından sağlanır
        private readonly Piece[,] pieces = new Piece[8, 8];

        public Piece this[int row, int col]
        {
            //Parçayı verilen konuma geri getiriyoruz
            //Pozisyon boş olursa bu değer null olacak
            get { return pieces[row, col]; }
            set { pieces[row, col] = value; }
        }
        
        public Piece this[Position pos]//İlk konumu açar ve ilk indexer çağırır
        {
            get { return this[pos.Row, pos.Column]; }
            set { this[pos.Row, pos.Column] = value; }
        }
        //Yukarıdaki indexerlar sayesinde verilen kareye satır ve sütun veya pozisyon nesnesi ile get set edilebilir
        public static Board Initial()
        {
            Board board = new Board();
            board.AddStartPieces();
            return board;
        }

        private void AddStartPieces()
        {
            this[0, 0] = new Rook(Player.Black);
            this[0, 1] = new Knight(Player.Black);
            this[0, 2] = new Bishop(Player.Black);
            this[0, 3] = new Queen(Player.Black);
            this[0, 4] = new King(Player.Black);
            this[0, 5] = new Bishop(Player.Black);
            this[0, 6] = new Knight(Player.Black);
            this[0, 7] = new Rook(Player.Black);

            this[7, 0] = new Rook(Player.White);
            this[7, 1] = new Knight(Player.White);
            this[7, 2] = new Bishop(Player.White);
            this[7, 3] = new Queen(Player.White);
            this[7, 4] = new King(Player.White);
            this[7, 5] = new Bishop(Player.White);
            this[7, 6] = new Knight(Player.White);
            this[7, 7] = new Rook(Player.White);

            for(int i = 0; i < 8; i++)
            {
                this[1, i] = new Pawn(Player.Black);
                this[6, i] = new Pawn(Player.White);
            }
        }

        public static bool IsInside(Position pos)//Pozisyonu alır ve pozisyon tahtanın içinde ise true çevirir
        {
            return pos.Row >= 0 && pos.Row < 8 && pos.Column >= 0 && pos.Column < 8;

        }

        public bool IsEmpty(Position pos)//Pozisyonu alır eğer pozisyonda taş yoksa true çevirir
        {
            return this[pos] == null;
        }
    }
}
