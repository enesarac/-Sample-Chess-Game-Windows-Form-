using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Bu sınıfı Pieces klasörü içinde açtığımız için
//namespace ChessLogic.Pieces ismini aldı ve değiştik
namespace ChessLogic
{
    public abstract class Piece
    {
        //Tüm parçaların override etmesi gereken iki özellik
        public abstract PieceType Type { get; }
        public abstract Player Color { get; }//Player enum tarafından temsil edilen renkler
        public bool HasMoved { get; set; } = false;//Bazı hareketler taş daha hareket etmediği zaman mümkündür

        public abstract Piece Copy();

        public abstract IEnumerable<Move> GetMoves(Position from, Board board);//Bu parametreler sayesinde taş yapabileceği tüm hamleleri return edebilir
        //Pozisyon parametresi taşlar kendi pozisyonlarını tahtada depolamadığı için gereklidir

        //Verilen yöne ulaşabilen tüm pozisyonları return eden helper methodu
        //İstenilen pozisyona kadar taşın gideceği noktaları kontrol edecek
        //Tahtanın sonuna ulaştığında veya önüne herhangi bir taş çıktığı zamana kadar bunu yapacak
        //Karşıya çıkan taş rakibin taşı ise yiyebilecek (ulaşılabilir)
        //Kendi renginde ise ulaşılamaz
        protected IEnumerable<Position> MovePositionsInDir(Position from, Board board, Direction dir)
        {
            //Döngü position from + (verilen yön) dir den başlayacak
            //Pozisyon tahta içinde olduğu sürece devam edecek
            //Her yinelemeden sonra bir adım atacak
            for(Position pos = from + dir; Board.IsInside(pos); pos += dir)
            {
                //Döngü içinde mevcut pozisyon boş mu kontrol eder
                if (board.IsEmpty(pos))
                {
                    yield return pos;
                    continue;
                }

                Piece piece = board[pos];

                if (piece.Color != Color)//Rakibin taşı olduğu zaman
                {
                    yield return pos;
                }

                //Rakibin taşı olmadığı zaman erişilemez Bishop, Rook, Queen zıplayamadığı için daha fazla pozisyon incelememize gerek yok
                yield break;
            }
        }

        //Yönlerin dizilerini alan method
        protected IEnumerable<Position> MovePositionsInDirs(Position from, Board board, Direction[] dirs)
        {
            //Tüm verilen yönlerden ulaşılabilenleri toplayacak
            return dirs.SelectMany(dir => MovePositionsInDir(from, board, dir));
        }
    }
}
