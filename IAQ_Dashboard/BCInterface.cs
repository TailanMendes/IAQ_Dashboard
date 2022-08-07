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

            storeDataIntoFile(getMeasureFunctionReturn);

            var message = string.Join(Environment.NewLine, getMeasureFunctionReturn);
            //MessageBox.Show(message);
        }

        private void storeDataIntoFile(List<string> getMeasureFunctionReturn)
        {            
            string data_path = @"c:\\iaq_data.ms";

            // If file doesnt exists insert all data
            if (!File.Exists(data_path))
            {
                File.AppendAllLines(data_path, getMeasureFunctionReturn);
            }
            else
            {
                StreamReader sr = new StreamReader(data_path);
                var last_line = File.ReadLines(data_path).Last();
                sr.Close();

                UInt32 last_epoch_time = Convert.ToUInt32(getEpochTime(last_line));

                foreach (string s in getMeasureFunctionReturn)
                {
                    UInt32 epoch = Convert.ToUInt32(getEpochTime(s));

                    if (epoch > last_epoch_time)
                    {
                        File.AppendAllText(data_path, s + Environment.NewLine);

                    }

                }
            }

            //File.AppendAllLines(data_path, getMeasureFunctionReturn);                 
        }

        private string getEpochTime(string s)
        {
            string[] subs = s.Split('|', 3);
            var epochtime = subs[2];
            return epochtime;
        }

        public partial class GetMeasureFunction : GetMeasureFunctionBase { }

        [Function("getMeasure", "string[]")]
        public class GetMeasureFunctionBase : FunctionMessage
        {

        }


    }
}
