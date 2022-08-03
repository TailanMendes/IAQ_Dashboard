using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;

namespace IAQ_Dashboard
{
    public class BCInterface
    {
        public async void getContractData()
        {
            var web3 = new Web3("https://rinkeby.infura.io/v3/ea9cd517fe4c4782a5f7ee526a578ec5");

            var contractAddress = "0x194E4A079f507208B544eB8EAd2821e3Daa6a8C5";
            var contractHandler = web3.Eth.GetContractHandler(contractAddress);

            /** Function: getMeasure**/

            var getMeasureFunctionReturn = await contractHandler.QueryAsync<GetMeasureFunction, List<string>>();

            var message = string.Join(Environment.NewLine, getMeasureFunctionReturn);
            MessageBox.Show(message);
        }

        public partial class GetMeasureFunction : GetMeasureFunctionBase { }

        [Function("getMeasure", "string[]")]
        public class GetMeasureFunctionBase : FunctionMessage
        {

        }


    }
}
