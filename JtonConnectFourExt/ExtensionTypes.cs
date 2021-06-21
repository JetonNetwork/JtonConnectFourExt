using SubstrateNetApi.Model.Types.Base;
using SubstrateNetApi.Model.Types.Enum;
using SubstrateNetApi.Model.Types.Struct;
using System;
using System.Numerics;

namespace SubstrateNetApi.Model.Types.Custom
{
    #region BASE_TYPES

 
    #endregion

    #region ENUM_TYPES

    public enum BoardState
    {
        None,
        Running,
        Finished

    }
    public class BoardStateEnum : ExtEnumType<BoardState, NullType, NullType, AccountId, NullType, NullType, NullType, NullType, NullType, NullType> {
        public override string Name() => "BoardState<T::AccountId>";
    }

    #endregion

    #region STRUCT_TYPES

    public class Board : StructType
    {
        public override string Name() => "[[u8; 6]; 7]";

        public override int Size() => 42;

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var memory = byteArray.AsMemory();
            BoardId = memory.Span.Slice(p, Size()).ToArray();
            p += Size();
        }

        public byte[] BoardId { get; private set; }
    }

    public class BoardStruct : StructType
    {
        public override string Name() => "BoardStruct<T::Hash, T::AccountId, T::BlockNumber, BoardState<T::\nAccountId>>";

        private int _size;
        public override int Size() => _size;

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Id = new Hash();
            Id.Decode(byteArray, ref p);

            Red = new AccountId();
            Red.Decode(byteArray, ref p);

            Blue = new AccountId();
            Blue.Decode(byteArray, ref p);

            Board = new Board();
            Board.Decode(byteArray, ref p);

            LastTurn = new BlockNumber();
            LastTurn.Decode(byteArray, ref p);

            NextPlayer = new U8();
            NextPlayer.Decode(byteArray, ref p);

            BoardState = new BoardStateEnum();
            BoardState.Decode(byteArray, ref p);

            _size = p - start;
        }

        public Hash Id { get; private set; }
        public AccountId Red { get; private set; }
        public AccountId Blue { get; private set; }
        public Board Board { get; private set; }
        public BlockNumber LastTurn { get; private set; }
        public U8 NextPlayer { get; private set; }
        public BoardStateEnum BoardState { get; private set; }
    }

    #endregion

}
