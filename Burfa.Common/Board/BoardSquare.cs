using Burfa.Common.Engine.Types;

namespace Burfa.Common.Board
{
    public class BoardSquare
    {
        #region Logic Testing

        public int X { get; set; }
        public int Y { get; set; }

        #endregion

        public Player? State { get; private set; }

        public void SetBlack()
        {
            State = Player.Black;
        }

        public void SetWhite()
        {
            State = Player.White;
        }

        public void Set(Player player)
        {
            State = player;
        }

        public void Clear()
        {
            State = default(Player);
        }

        public bool BelongsTo(Player player)
        {
            return (State == player);
        }

        public bool DoesNotBelongTo(Player player)
        {
            return (State != player);
        }

        public bool DoesNotBelongToAndIsNotEmpty(Player player)
        {
            return (State != null && State != player);
        }

        public bool IsEmpty()
        {
            return (State == null);
        }

        public override string ToString()
        {
            return State + "x" + X + " y" + Y;
        }
    }
}