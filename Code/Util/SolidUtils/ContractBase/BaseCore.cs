using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;


namespace Liquify.Code.Util.SolidUtils.ContractBase
{


    //public class BaseV1CoreConsole
    //{
    //    public static async Task Main()
    //    {
    //        var url = "http://testchain.nethereum.com:8545";
    //        //var url = "https://mainnet.infura.io";
    //        var privateKey = "0x7580e7fb49df1c861f0050fae31c2224c6aba908e116b8da44ee8cd927b990b0";
    //        var account = new Nethereum.Web3.Accounts.Account(privateKey);
    //        var web3 = new Web3(account, url);

    //        /* Deployment 
    //       var baseV1CoreDeployment = new BaseV1CoreDeployment();

    //       var transactionReceiptDeployment = await web3.Eth.GetContractDeploymentHandler<BaseV1CoreDeployment>().SendRequestAndWaitForReceiptAsync(baseV1CoreDeployment);
    //       var contractAddress = transactionReceiptDeployment.ContractAddress;
    //        */
    //     //   var contractHandler = web3.Eth.GetContractHandler(contractAddress);

    //        /** Function: acceptPauser**/
    //        /*
    //        var acceptPauserFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync<AcceptPauserFunction>();
    //        */


    //        /** Function: allPairs**/
    //        /*
    //        var allPairsFunction = new AllPairsFunction();
    //        allPairsFunction.ReturnValue1 = returnValue1;
    //        var allPairsFunctionReturn = await contractHandler.QueryAsync<AllPairsFunction, string>(allPairsFunction);
    //        */


    //        /** Function: allPairsLength**/
    //        /*
    //        var allPairsLengthFunctionReturn = await contractHandler.QueryAsync<AllPairsLengthFunction, BigInteger>();
    //        */


    //        /** Function: createPair**/
    //        /*
    //        var createPairFunction = new CreatePairFunction();
    //        createPairFunction.TokenA = tokenA;
    //        createPairFunction.TokenB = tokenB;
    //        createPairFunction.Stable = stable;
    //        var createPairFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(createPairFunction);
    //        */


    //        /** Function: getInitializable**/
    //        /*
    //        var getInitializableOutputDTO = await contractHandler.QueryDeserializingToObjectAsync<GetInitializableFunction, GetInitializableOutputDTO>();
    //        */


    //        /** Function: getPair**/
    //        /*
    //        var getPairFunction = new GetPairFunction();
    //        getPairFunction.ReturnValue1 = returnValue1;
    //        getPairFunction.ReturnValue2 = returnValue2;
    //        getPairFunction.ReturnValue3 = returnValue3;
    //        var getPairFunctionReturn = await contractHandler.QueryAsync<GetPairFunction, string>(getPairFunction);
    //        */


    //        /** Function: isPair**/
    //        /*
    //        var isPairFunction = new IsPairFunction();
    //        isPairFunction.ReturnValue1 = returnValue1;
    //        var isPairFunctionReturn = await contractHandler.QueryAsync<IsPairFunction, bool>(isPairFunction);
    //        */


    //        /** Function: isPaused**/
    //        /*
    //        var isPausedFunctionReturn = await contractHandler.QueryAsync<IsPausedFunction, bool>();
    //        */


    //        /** Function: pairCodeHash**/
    //        /*
    //        var pairCodeHashFunctionReturn = await contractHandler.QueryAsync<PairCodeHashFunction, byte[]>();
    //        */


    //        /** Function: pauser**/
    //        /*
    //        var pauserFunctionReturn = await contractHandler.QueryAsync<PauserFunction, string>();
    //        */


    //        /** Function: pendingPauser**/
    //        /*
    //        var pendingPauserFunctionReturn = await contractHandler.QueryAsync<PendingPauserFunction, string>();
    //        */


    //        /** Function: setPause**/
    //        /*
    //        var setPauseFunction = new SetPauseFunction();
    //        setPauseFunction.State = state;
    //        var setPauseFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(setPauseFunction);
    //        */


    //        /** Function: setPauser**/
    //        /*
    //        var setPauserFunction = new SetPauserFunction();
    //        setPauserFunction.Pauser = pauser;
    //        var setPauserFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(setPauserFunction);
    //        */
    //    }

    //}

    public partial class BaseV1CoreDeployment : BaseV1CoreDeploymentBase
    {
        public BaseV1CoreDeployment() : base(BYTECODE) { }
        public BaseV1CoreDeployment(string byteCode) : base(byteCode) { }
    }

    public class BaseV1CoreDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "";
        public BaseV1CoreDeploymentBase() : base(BYTECODE) { }
        public BaseV1CoreDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class AcceptPauserFunction : AcceptPauserFunctionBase { }

    [Function("acceptPauser")]
    public class AcceptPauserFunctionBase : FunctionMessage
    {

    }

    public partial class AllPairsFunction : AllPairsFunctionBase { }

    [Function("allPairs", "address")]
    public class AllPairsFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class AllPairsLengthFunction : AllPairsLengthFunctionBase { }

    [Function("allPairsLength", "uint256")]
    public class AllPairsLengthFunctionBase : FunctionMessage
    {

    }

    public partial class CreatePairFunction : CreatePairFunctionBase { }

    [Function("createPair", "address")]
    public class CreatePairFunctionBase : FunctionMessage
    {
        [Parameter("address", "tokenA", 1)]
        public virtual string TokenA { get; set; }
        [Parameter("address", "tokenB", 2)]
        public virtual string TokenB { get; set; }
        [Parameter("bool", "stable", 3)]
        public virtual bool Stable { get; set; }
    }

    public partial class GetInitializableFunction : GetInitializableFunctionBase { }

    [Function("getInitializable", typeof(GetInitializableOutputDTO))]
    public class GetInitializableFunctionBase : FunctionMessage
    {

    }

    public partial class GetPairFunction : GetPairFunctionBase { }

    [Function("getPair", "address")]
    public class GetPairFunctionBase : FunctionMessage
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
        [Parameter("address", "", 2)]
        public virtual string ReturnValue2 { get; set; }
        [Parameter("bool", "", 3)]
        public virtual bool ReturnValue3 { get; set; }
    }

    public partial class IsPairFunction : IsPairFunctionBase { }

    [Function("isPair", "bool")]
    public class IsPairFunctionBase : FunctionMessage
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class IsPausedFunction : IsPausedFunctionBase { }

    [Function("isPaused", "bool")]
    public class IsPausedFunctionBase : FunctionMessage
    {

    }

    public partial class PairCodeHashFunction : PairCodeHashFunctionBase { }

    [Function("pairCodeHash", "bytes32")]
    public class PairCodeHashFunctionBase : FunctionMessage
    {

    }

    public partial class PauserFunction : PauserFunctionBase { }

    [Function("pauser", "address")]
    public class PauserFunctionBase : FunctionMessage
    {

    }

    public partial class PendingPauserFunction : PendingPauserFunctionBase { }

    [Function("pendingPauser", "address")]
    public class PendingPauserFunctionBase : FunctionMessage
    {

    }

    public partial class SetPauseFunction : SetPauseFunctionBase { }

    [Function("setPause")]
    public class SetPauseFunctionBase : FunctionMessage
    {
        [Parameter("bool", "_state", 1)]
        public virtual bool State { get; set; }
    }

    public partial class SetPauserFunction : SetPauserFunctionBase { }

    [Function("setPauser")]
    public class SetPauserFunctionBase : FunctionMessage
    {
        [Parameter("address", "_pauser", 1)]
        public virtual string Pauser { get; set; }
    }

    public partial class PairCreatedEventDTO : PairCreatedEventDTOBase { }

    [Event("PairCreated")]
    public class PairCreatedEventDTOBase : IEventDTO
    {
        [Parameter("address", "token0", 1, true)]
        public virtual string Token0 { get; set; }
        [Parameter("address", "token1", 2, true)]
        public virtual string Token1 { get; set; }
        [Parameter("bool", "stable", 3, false)]
        public virtual bool Stable { get; set; }
        [Parameter("address", "pair", 4, false)]
        public virtual string Pair { get; set; }
        [Parameter("uint256", "", 5, false)]
        public virtual BigInteger ReturnValue5 { get; set; }
    }



    public partial class AllPairsOutputDTO : AllPairsOutputDTOBase { }

    [FunctionOutput]
    public class AllPairsOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class AllPairsLengthOutputDTO : AllPairsLengthOutputDTOBase { }

    [FunctionOutput]
    public class AllPairsLengthOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }



    public partial class GetInitializableOutputDTO : GetInitializableOutputDTOBase { }

    [FunctionOutput]
    public class GetInitializableOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
        [Parameter("address", "", 2)]
        public virtual string ReturnValue2 { get; set; }
        [Parameter("bool", "", 3)]
        public virtual bool ReturnValue3 { get; set; }
    }

    public partial class GetPairOutputDTO : GetPairOutputDTOBase { }

    [FunctionOutput]
    public class GetPairOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class IsPairOutputDTO : IsPairOutputDTOBase { }

    [FunctionOutput]
    public class IsPairOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class IsPausedOutputDTO : IsPausedOutputDTOBase { }

    [FunctionOutput]
    public class IsPausedOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class PairCodeHashOutputDTO : PairCodeHashOutputDTOBase { }

    [FunctionOutput]
    public class PairCodeHashOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("bytes32", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
    }

    public partial class PauserOutputDTO : PauserOutputDTOBase { }

    [FunctionOutput]
    public class PauserOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class PendingPauserOutputDTO : PendingPauserOutputDTOBase { }

    [FunctionOutput]
    public class PendingPauserOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }
}
