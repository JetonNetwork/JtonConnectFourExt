using SubstrateNetApi.Model.Types.Base;
using SubstrateNetApi.Model.Types.Custom;
using System;

namespace SubstrateNetApi.Model.Calls
{
    public class JtonConnectFourCall
    {
        /*
         * {
         *   "Name": "new_game",
         *   "Arguments": [
         *     {
         *       "Name": "opponent",
         *       "Type": "T::AccountId"
         *     }
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
        public static GenericExtrinsicCall NewGame(string opponentAddress)
        {
            var rawAccountId = new RawAccountId();
            rawAccountId.Create(Utils.GetPublicKeyFrom(opponentAddress));
            return new GenericExtrinsicCall("ConnectFour", "new_game", rawAccountId);
        }

    }
}
