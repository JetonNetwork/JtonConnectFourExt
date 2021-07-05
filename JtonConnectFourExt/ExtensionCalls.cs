using SubstrateNetApi.Model.Types.Base;
using SubstrateNetApi.Model.Types.Custom;
using System;

namespace SubstrateNetApi.Model.Calls
{
    public class JtonConnectFourCall
    {
        /* {
         *   "Name": "new_game",
         *   "Arguments": [
         *    {
         *      "Name": "opponent",
         *      "Type": "T::AccountId"
         *    }
         *   ],
         *   "Documentations": [
         *     " Create game for two players"
         *   ]
         * }
         */
        public static GenericExtrinsicCall NewGame(RawAccountId opponent)
        {
            return new GenericExtrinsicCall("ConnectFour", "new_game", opponent);
        }
        public static GenericExtrinsicCall NewGame(string opponent)
        {
            var rawAccountId = new RawAccountId();
            rawAccountId.Create(Utils.GetPublicKeyFrom(opponent));
            return new GenericExtrinsicCall("ConnectFour", "new_game", rawAccountId);
        }

        /* {
         *   "Name": "play_turn",
         *   "Arguments": [
         *    {
         *      "Name": "column",
         *      "Type": "u8"
         *    }
         *  ],
         *  "Documentations": [
         *    " Create game for two players"
         *  ]
         * }
         */
        public static GenericExtrinsicCall PlayTurn(U8 column)
        {
            return new GenericExtrinsicCall("ConnectFour", "play_turn", column);
        }
        public static GenericExtrinsicCall PlayTurn(byte column)
        {
            var u8 = new U8();
            u8.Create(column);
            return new GenericExtrinsicCall("ConnectFour", "play_turn", u8);
        }

        /* {
         *   "Name": "queue",
         *   "Arguments": [
         *    {
         *
         *    }
         *  ],
         *  "Documentations": [
         *    " Queue sender up for a game, ranking brackets."
         *  ]
         * }
         */
        public static GenericExtrinsicCall Queue()
        {
            return new GenericExtrinsicCall("ConnectFour", "queue");
        }

        /* {
         *   "Name": "empty_queue",
         *   "Arguments": [
         *    {
         *
         *    }
         *  ],
         *  "Documentations": [
         *    " Empty all brackets, this is a founder only extrinsic."
         *  ]
         * }
         */
        public static GenericExtrinsicCall EmptyQueue()
        {
            return new GenericExtrinsicCall("ConnectFour", "empty_queue");
        }
    }
}
