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

    //public class BaseVoterConsole
    //{
    //    public static async Task Main()
    //    {
    //        var url = "http://testchain.nethereum.com:8545";
    //        //var url = "https://mainnet.infura.io";
    //        var privateKey = "0x7580e7fb49df1c861f0050fae31c2224c6aba908e116b8da44ee8cd927b990b0";
    //        var account = new Nethereum.Web3.Accounts.Account(privateKey);
    //        var web3 = new Web3(account, url);

    //        /* Deployment 
    //       var baseVoterDeployment = new BaseVoterDeployment();
    //           baseVoterDeployment.Ve = ve;
    //           baseVoterDeployment.Factory = factory;
    //           baseVoterDeployment.Gauges = gauges;
    //           baseVoterDeployment.Bribes = bribes;
    //       var transactionReceiptDeployment = await web3.Eth.GetContractDeploymentHandler<BaseVoterDeployment>().SendRequestAndWaitForReceiptAsync(baseVoterDeployment);
    //       var contractAddress = transactionReceiptDeployment.ContractAddress;
    //        */
    //      //  var contractHandler = web3.Eth.GetContractHandler(contractAddress);

    //        /** Function: _ve**/
    //        /*
    //        var veFunctionReturn = await contractHandler.QueryAsync<VeFunction, string>();
    //        */


    //        /** Function: attachTokenToGauge**/
    //        /*
    //        var attachTokenToGaugeFunction = new AttachTokenToGaugeFunction();
    //        attachTokenToGaugeFunction.TokenId = tokenId;
    //        attachTokenToGaugeFunction.Account = account;
    //        var attachTokenToGaugeFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(attachTokenToGaugeFunction);
    //        */


    //        /** Function: bribefactory**/
    //        /*
    //        var bribefactoryFunctionReturn = await contractHandler.QueryAsync<BribefactoryFunction, string>();
    //        */


    //        /** Function: bribes**/
    //        /*
    //        var bribesFunction = new BribesFunction();
    //        bribesFunction.ReturnValue1 = returnValue1;
    //        var bribesFunctionReturn = await contractHandler.QueryAsync<BribesFunction, string>(bribesFunction);
    //        */


    //        /** Function: claimBribes**/
    //        /*
    //        var claimBribesFunction = new ClaimBribesFunction();
    //        claimBribesFunction.Bribes = bribes;
    //        claimBribesFunction.Tokens = tokens;
    //        claimBribesFunction.TokenId = tokenId;
    //        var claimBribesFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(claimBribesFunction);
    //        */


    //        /** Function: claimFees**/
    //        /*
    //        var claimFeesFunction = new ClaimFeesFunction();
    //        claimFeesFunction.Fees = fees;
    //        claimFeesFunction.Tokens = tokens;
    //        claimFeesFunction.TokenId = tokenId;
    //        var claimFeesFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(claimFeesFunction);
    //        */


    //        /** Function: claimRewards**/
    //        /*
    //        var claimRewardsFunction = new ClaimRewardsFunction();
    //        claimRewardsFunction.Gauges = gauges;
    //        claimRewardsFunction.Tokens = tokens;
    //        var claimRewardsFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(claimRewardsFunction);
    //        */


    //        /** Function: claimable**/
    //        /*
    //        var claimableFunction = new ClaimableFunction();
    //        claimableFunction.ReturnValue1 = returnValue1;
    //        var claimableFunctionReturn = await contractHandler.QueryAsync<ClaimableFunction, BigInteger>(claimableFunction);
    //        */


    //        /** Function: createGauge**/
    //        /*
    //        var createGaugeFunction = new CreateGaugeFunction();
    //        createGaugeFunction.Pool = pool;
    //        var createGaugeFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(createGaugeFunction);
    //        */


    //        /** Function: detachTokenFromGauge**/
    //        /*
    //        var detachTokenFromGaugeFunction = new DetachTokenFromGaugeFunction();
    //        detachTokenFromGaugeFunction.TokenId = tokenId;
    //        detachTokenFromGaugeFunction.Account = account;
    //        var detachTokenFromGaugeFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(detachTokenFromGaugeFunction);
    //        */


    //        /** Function: distribute**/
    //        /*
    //        var distributeFunction = new DistributeFunction();
    //        distributeFunction.Gauges = gauges;
    //        var distributeFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(distributeFunction);
    //        */


    //        /** Function: distribute**/
    //        /*
    //        var distributeFunction = new DistributeFunction();
    //        distributeFunction.Gauge = gauge;
    //        var distributeFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(distributeFunction);
    //        */


    //        /** Function: distribute**/
    //        /*
    //        var distributeFunction = new DistributeFunction();
    //        distributeFunction.Start = start;
    //        distributeFunction.Finish = finish;
    //        var distributeFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(distributeFunction);
    //        */


    //        /** Function: distribute**/
    //        /*
    //        var distributeFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync<DistributeFunction>();
    //        */


    //        /** Function: distributeFees**/
    //        /*
    //        var distributeFeesFunction = new DistributeFeesFunction();
    //        distributeFeesFunction.Gauges = gauges;
    //        var distributeFeesFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(distributeFeesFunction);
    //        */


    //        /** Function: distro**/
    //        /*
    //        var distroFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync<DistroFunction>();
    //        */


    //        /** Function: emitDeposit**/
    //        /*
    //        var emitDepositFunction = new EmitDepositFunction();
    //        emitDepositFunction.TokenId = tokenId;
    //        emitDepositFunction.Account = account;
    //        emitDepositFunction.Amount = amount;
    //        var emitDepositFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(emitDepositFunction);
    //        */


    //        /** Function: emitWithdraw**/
    //        /*
    //        var emitWithdrawFunction = new EmitWithdrawFunction();
    //        emitWithdrawFunction.TokenId = tokenId;
    //        emitWithdrawFunction.Account = account;
    //        emitWithdrawFunction.Amount = amount;
    //        var emitWithdrawFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(emitWithdrawFunction);
    //        */


    //        /** Function: factory**/
    //        /*
    //        var factoryFunctionReturn = await contractHandler.QueryAsync<FactoryFunction, string>();
    //        */


    //        /** Function: gaugefactory**/
    //        /*
    //        var gaugefactoryFunctionReturn = await contractHandler.QueryAsync<GaugefactoryFunction, string>();
    //        */


    //        /** Function: gauges**/
    //        /*
    //        var gaugesFunction = new GaugesFunction();
    //        gaugesFunction.ReturnValue1 = returnValue1;
    //        var gaugesFunctionReturn = await contractHandler.QueryAsync<GaugesFunction, string>(gaugesFunction);
    //        */


    //        /** Function: initialize**/
    //        /*
    //        var initializeFunction = new InitializeFunction();
    //        initializeFunction.Tokens = tokens;
    //        initializeFunction.Minter = minter;
    //        var initializeFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(initializeFunction);
    //        */


    //        /** Function: isGauge**/
    //        /*
    //        var isGaugeFunction = new IsGaugeFunction();
    //        isGaugeFunction.ReturnValue1 = returnValue1;
    //        var isGaugeFunctionReturn = await contractHandler.QueryAsync<IsGaugeFunction, bool>(isGaugeFunction);
    //        */


    //        /** Function: isWhitelisted**/
    //        /*
    //        var isWhitelistedFunction = new IsWhitelistedFunction();
    //        isWhitelistedFunction.ReturnValue1 = returnValue1;
    //        var isWhitelistedFunctionReturn = await contractHandler.QueryAsync<IsWhitelistedFunction, bool>(isWhitelistedFunction);
    //        */


    //        /** Function: length**/
    //        /*
    //        var lengthFunctionReturn = await contractHandler.QueryAsync<LengthFunction, BigInteger>();
    //        */


    //        /** Function: listing_fee**/
    //        /*
    //        var listing_feeFunctionReturn = await contractHandler.QueryAsync<Listing_feeFunction, BigInteger>();
    //        */


    //        /** Function: minter**/
    //        /*
    //        var minterFunctionReturn = await contractHandler.QueryAsync<MinterFunction, string>();
    //        */


    //        /** Function: notifyRewardAmount**/
    //        /*
    //        var notifyRewardAmountFunction = new NotifyRewardAmountFunction();
    //        notifyRewardAmountFunction.Amount = amount;
    //        var notifyRewardAmountFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(notifyRewardAmountFunction);
    //        */


    //        /** Function: poke**/
    //        /*
    //        var pokeFunction = new PokeFunction();
    //        pokeFunction.TokenId = tokenId;
    //        var pokeFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(pokeFunction);
    //        */


    //        /** Function: poolForGauge**/
    //        /*
    //        var poolForGaugeFunction = new PoolForGaugeFunction();
    //        poolForGaugeFunction.ReturnValue1 = returnValue1;
    //        var poolForGaugeFunctionReturn = await contractHandler.QueryAsync<PoolForGaugeFunction, string>(poolForGaugeFunction);
    //        */


    //        /** Function: poolVote**/
    //        /*
    //        var poolVoteFunction = new PoolVoteFunction();
    //        poolVoteFunction.ReturnValue1 = returnValue1;
    //        poolVoteFunction.ReturnValue2 = returnValue2;
    //        var poolVoteFunctionReturn = await contractHandler.QueryAsync<PoolVoteFunction, string>(poolVoteFunction);
    //        */


    //        /** Function: pools**/
    //        /*
    //        var poolsFunction = new PoolsFunction();
    //        poolsFunction.ReturnValue1 = returnValue1;
    //        var poolsFunctionReturn = await contractHandler.QueryAsync<PoolsFunction, string>(poolsFunction);
    //        */


    //        /** Function: reset**/
    //        /*
    //        var resetFunction = new ResetFunction();
    //        resetFunction.TokenId = tokenId;
    //        var resetFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(resetFunction);
    //        */


    //        /** Function: totalWeight**/
    //        /*
    //        var totalWeightFunctionReturn = await contractHandler.QueryAsync<TotalWeightFunction, BigInteger>();
    //        */


    //        /** Function: updateAll**/
    //        /*
    //        var updateAllFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync<UpdateAllFunction>();
    //        */


    //        /** Function: updateFor**/
    //        /*
    //        var updateForFunction = new UpdateForFunction();
    //        updateForFunction.Gauges = gauges;
    //        var updateForFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(updateForFunction);
    //        */


    //        /** Function: updateForRange**/
    //        /*
    //        var updateForRangeFunction = new UpdateForRangeFunction();
    //        updateForRangeFunction.Start = start;
    //        updateForRangeFunction.End = end;
    //        var updateForRangeFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(updateForRangeFunction);
    //        */


    //        /** Function: updateGauge**/
    //        /*
    //        var updateGaugeFunction = new UpdateGaugeFunction();
    //        updateGaugeFunction.Gauge = gauge;
    //        var updateGaugeFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(updateGaugeFunction);
    //        */


    //        /** Function: usedWeights**/
    //        /*
    //        var usedWeightsFunction = new UsedWeightsFunction();
    //        usedWeightsFunction.ReturnValue1 = returnValue1;
    //        var usedWeightsFunctionReturn = await contractHandler.QueryAsync<UsedWeightsFunction, BigInteger>(usedWeightsFunction);
    //        */


    //        /** Function: vote**/
    //        /*
    //        var voteFunction = new VoteFunction();
    //        voteFunction.TokenId = tokenId;
    //        voteFunction.PoolVote = poolVote;
    //        voteFunction.Weights = weights;
    //        var voteFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(voteFunction);
    //        */


    //        /** Function: votes**/
    //        /*
    //        var votesFunction = new VotesFunction();
    //        votesFunction.ReturnValue1 = returnValue1;
    //        votesFunction.ReturnValue2 = returnValue2;
    //        var votesFunctionReturn = await contractHandler.QueryAsync<VotesFunction, BigInteger>(votesFunction);
    //        */


    //        /** Function: weights**/
    //        /*
    //        var weightsFunction = new WeightsFunction();
    //        weightsFunction.ReturnValue1 = returnValue1;
    //        var weightsFunctionReturn = await contractHandler.QueryAsync<WeightsFunction, BigInteger>(weightsFunction);
    //        */


    //        /** Function: whitelist**/
    //        /*
    //        var whitelistFunction = new WhitelistFunction();
    //        whitelistFunction.Token = token;
    //        whitelistFunction.TokenId = tokenId;
    //        var whitelistFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(whitelistFunction);
    //        */
    //    }

    //}

    public partial class BaseVoterDeployment : BaseVoterDeploymentBase
    {
        public BaseVoterDeployment() : base(BYTECODE) { }
        public BaseVoterDeployment(string byteCode) : base(byteCode) { }
    }

    public class BaseVoterDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "6101206040526001600c553480156200001757600080fd5b5060405162004e8838038062004e8883398181016040528101906200003d919062000267565b8373ffffffffffffffffffffffffffffffffffffffff1660808173ffffffffffffffffffffffffffffffffffffffff16815250508273ffffffffffffffffffffffffffffffffffffffff1660a08173ffffffffffffffffffffffffffffffffffffffff16815250508373ffffffffffffffffffffffffffffffffffffffff1663fc0c546a6040518163ffffffff1660e01b8152600401602060405180830381865afa158015620000f1573d6000803e3d6000fd5b505050506040513d601f19601f82011682018060405250810190620001179190620002d9565b73ffffffffffffffffffffffffffffffffffffffff1660c08173ffffffffffffffffffffffffffffffffffffffff16815250508173ffffffffffffffffffffffffffffffffffffffff1660e08173ffffffffffffffffffffffffffffffffffffffff16815250508073ffffffffffffffffffffffffffffffffffffffff166101008173ffffffffffffffffffffffffffffffffffffffff1681525050336000806101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff160217905550505050506200030b565b600080fd5b600073ffffffffffffffffffffffffffffffffffffffff82169050919050565b60006200022f8262000202565b9050919050565b620002418162000222565b81146200024d57600080fd5b50565b600081519050620002618162000236565b92915050565b60008060008060808587031215620002845762000283620001fd565b5b6000620002948782880162000250565b9450506020620002a78782880162000250565b9350506040620002ba8782880162000250565b9250506060620002cd8782880162000250565b91505092959194509250565b600060208284031215620002f257620002f1620001fd565b5b6000620003028482850162000250565b91505092915050565b60805160a05160c05160e05161010051614a9e620003ea60003960008181610bfc0152611e090152600081816114520152611e9e015260008181610c4301528181610cb40152818161110401528181611204015281816119dd01528181611f600152612532015260008181611bd6015261260d015260008181610917015281816109c501528181610db4015281816112e7015281816114d5015281816116a201528181611825015281816118580152818161193101528181611edc015281816124a30152818161281f01528181612d6801526132c90152614a9e6000f3fe608060405234801561001057600080fd5b50600436106102695760003560e01c80637715ee7511610151578063aa79979b116100c3578063c527ee1f11610087578063c527ee1f14610742578063d23254b41461075e578063d560b0d71461078e578063e4fc6b6d146107aa578063ea94ee44146107b4578063fecdad60146107d057610269565b8063aa79979b14610676578063ac4afa38146106a6578063b980777a146106d6578063b9a09fd5146106f4578063c45a01551461072457610269565b80639b6a9d72116101155780639b6a9d721461057e578063a5f4301e1461059a578063a61c713a146105ca578063a7cac846146105e6578063a86a366d14610616578063a8c5d95a1461064657610269565b80637715ee75146104da57806379e93824146104f65780638dd598fb1461052657806396c82e571461054457806398fc55d81461056257610269565b8063411b1f77116101ea57806363453ae1116101ae57806363453ae114610430578063666256aa1461044c57806368c3acb314610468578063698473e3146104865780636ecbe38a146104a25780637625391a146104be57610269565b8063411b1f77146103c8578063462d0b2e146103e457806347b3c6ba1461040057806353d786931461040a5780636138889b1461041457610269565b806332145f901161023157806332145f901461031257806338752a9d1461032e5780633af32abf1461034c5780633c6b16ab1461037c578063402914f51461039857610269565b806306d6a1b21461026e578063075461721461029e5780631f7b6d32146102bc57806320b1cb6f146102da578063310bd74b146102f6575b600080fd5b610288600480360381019061028391906138b8565b6107ec565b60405161029591906138f4565b60405180910390f35b6102a661081f565b6040516102b391906138f4565b60405180910390f35b6102c4610843565b6040516102d19190613928565b60405180910390f35b6102f460048036038101906102ef9190613b7d565b610850565b005b610310600480360381019061030b9190613c21565b610915565b005b61032c60048036038101906103279190613c21565b610a51565b005b610336610bfa565b60405161034391906138f4565b60405180910390f35b610366600480360381019061036191906138b8565b610c1e565b6040516103739190613c69565b60405180910390f35b61039660048036038101906103919190613c21565b610c3e565b005b6103b260048036038101906103ad91906138b8565b610d3b565b6040516103bf9190613928565b60405180910390f35b6103e260048036038101906103dd9190613c84565b610d53565b005b6103fe60048036038101906103f99190613cc4565b610ea7565b005b610408610f86565b005b610412610f98565b005b61042e60048036038101906104299190613d20565b610faa565b005b61044a600480360381019061044591906138b8565b610ff0565b005b61046660048036038101906104619190613d69565b6112e5565b005b610470611450565b60405161047d91906138f4565b60405180910390f35b6104a0600480360381019061049b9190613c84565b611474565b005b6104bc60048036038101906104b791906138b8565b6115c8565b005b6104d860048036038101906104d39190613df4565b6115d4565b005b6104f460048036038101906104ef9190613d69565b6116a0565b005b610510600480360381019061050b9190613c21565b61180b565b60405161051d9190613928565b60405180910390f35b61052e611823565b60405161053b91906138f4565b60405180910390f35b61054c611847565b6040516105599190613928565b60405180910390f35b61057c60048036038101906105779190613e34565b61184d565b005b61059860048036038101906105939190613df4565b611a39565b005b6105b460048036038101906105af91906138b8565b611b05565b6040516105c191906138f4565b60405180910390f35b6105e460048036038101906105df9190613e74565b6122e3565b005b61060060048036038101906105fb91906138b8565b6123a5565b60405161060d9190613ee0565b60405180910390f35b610630600480360381019061062b9190613df4565b6123bd565b60405161063d91906138f4565b60405180910390f35b610660600480360381019061065b91906138b8565b61240b565b60405161066d91906138f4565b60405180910390f35b610690600480360381019061068b91906138b8565b61243e565b60405161069d9190613c69565b60405180910390f35b6106c060048036038101906106bb9190613c21565b61245e565b6040516106cd91906138f4565b60405180910390f35b6106de61249d565b6040516106eb9190613928565b60405180910390f35b61070e600480360381019061070991906138b8565b6125d8565b60405161071b91906138f4565b60405180910390f35b61072c61260b565b60405161073991906138f4565b60405180910390f35b61075c60048036038101906107579190613d20565b61262f565b005b61077860048036038101906107739190613c84565b6126de565b6040516107859190613ee0565b60405180910390f35b6107a860048036038101906107a39190613d20565b612703565b005b6107b2612749565b005b6107ce60048036038101906107c99190613e74565b61275b565b005b6107ea60048036038101906107e59190613fac565b61281d565b005b60046020528060005260406000206000915054906101000a900473ffffffffffffffffffffffffffffffffffffffff1681565b60008054906101000a900473ffffffffffffffffffffffffffffffffffffffff1681565b6000600280549050905090565b60005b82518110156109105782818151811061086f5761086e614041565b5b602002602001015173ffffffffffffffffffffffffffffffffffffffff166331279d3d338484815181106108a6576108a5614041565b5b60200260200101516040518363ffffffff1660e01b81526004016108cb92919061412e565b600060405180830381600087803b1580156108e557600080fd5b505af11580156108f9573d6000803e3d6000fd5b5050505080806109089061418d565b915050610853565b505050565b7f000000000000000000000000000000000000000000000000000000000000000073ffffffffffffffffffffffffffffffffffffffff1663430c208133836040518363ffffffff1660e01b81526004016109709291906141d6565b602060405180830381865afa15801561098d573d6000803e3d6000fd5b505050506040513d601f19601f820116820180604052508101906109b1919061422b565b6109ba57600080fd5b6109c381612968565b7f000000000000000000000000000000000000000000000000000000000000000073ffffffffffffffffffffffffffffffffffffffff1663c1f0fb9f826040518263ffffffff1660e01b8152600401610a1c9190613928565b600060405180830381600087803b158015610a3657600080fd5b505af1158015610a4a573d6000803e3d6000fd5b5050505050565b600060086000838152602001908152602001600020805480602002602001604051908101604052809291908181526020018280548015610ae657602002820191906000526020600020905b8160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1681526020019060010190808311610a9c575b5050505050905060008151905060008167ffffffffffffffff811115610b0f57610b0e613959565b5b604051908082528060200260200182016040528015610b3d5781602001602082028036833780820191505090505b50905060005b82811015610be857600760008681526020019081526020016000206000858381518110610b7357610b72614041565b5b602002602001015173ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002054828281518110610bc957610bc8614041565b5b6020026020010181815250508080610be09061418d565b915050610b43565b50610bf4848483612d55565b50505050565b7f000000000000000000000000000000000000000000000000000000000000000081565b600b6020528060005260406000206000915054906101000a900460ff1681565b610c6a7f000000000000000000000000000000000000000000000000000000000000000033308461338e565b6000600154670de0b6b3a764000083610c839190614258565b610c8d91906142e1565b90506000811115610cb25780600d6000828254610caa9190614312565b925050819055505b7f000000000000000000000000000000000000000000000000000000000000000073ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff167ff70d5c697de7ea828df48e5c4573cb2194c659f1901f70110c52b066dcf5082684604051610d2f9190613928565b60405180910390a35050565b600f6020528060005260406000206000915090505481565b600a60003373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060009054906101000a900460ff16610da957600080fd5b6000821115610e3e577f000000000000000000000000000000000000000000000000000000000000000073ffffffffffffffffffffffffffffffffffffffff1663986b7d8a836040518263ffffffff1660e01b8152600401610e0b9190613928565b600060405180830381600087803b158015610e2557600080fd5b505af1158015610e39573d6000803e3d6000fd5b505050505b3373ffffffffffffffffffffffffffffffffffffffff168173ffffffffffffffffffffffffffffffffffffffff167fae268d9aab12f3605f58efd74fd3801fa812b03fdb44317eb70f46dff0e19e2284604051610e9b9190613928565b60405180910390a35050565b60008054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff1614610eff57600080fd5b60005b8251811015610f4157610f2e838281518110610f2157610f20614041565b5b60200260200101516134d4565b8080610f399061418d565b915050610f02565b50806000806101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff1602179055505050565b610f9660006002805490506115d4565b565b610fa86000600280549050611a39565b565b60005b8151811015610fec57610fd9828281518110610fcc57610fcb614041565b5b6020026020010151610ff0565b8080610fe49061418d565b915050610fad565b5050565b6001600c5414610fff57600080fd5b6002600c8190555060008054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1663ed29fc116040518163ffffffff1660e01b81526004016020604051808303816000875af1158015611074573d6000803e3d6000fd5b505050506040513d601f19601f82011682018060405250810190611098919061437d565b506110a2816135e0565b6000600f60008373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1681526020019081526020016000205490508173ffffffffffffffffffffffffffffffffffffffff166399bcc0527f00000000000000000000000000000000000000000000000000000000000000006040518263ffffffff1660e01b815260040161113f91906138f4565b602060405180830381865afa15801561115c573d6000803e3d6000fd5b505050506040513d601f19601f82011682018060405250810190611180919061437d565b8111801561119c5750600062093a808261119a91906142e1565b115b156112d9576000600f60008473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff168152602001908152602001600020819055508173ffffffffffffffffffffffffffffffffffffffff1663b66503cf7f0000000000000000000000000000000000000000000000000000000000000000836040518363ffffffff1660e01b81526004016112419291906141d6565b600060405180830381600087803b15801561125b57600080fd5b505af115801561126f573d6000803e3d6000fd5b505050508173ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff167f4fa9693cae526341d334e2862ca2413b2e503f1266255f9e0869fb36e6d89b17836040516112d09190613928565b60405180910390a35b506001600c8190555050565b7f000000000000000000000000000000000000000000000000000000000000000073ffffffffffffffffffffffffffffffffffffffff1663430c208133836040518363ffffffff1660e01b81526004016113409291906141d6565b602060405180830381865afa15801561135d573d6000803e3d6000fd5b505050506040513d601f19601f82011682018060405250810190611381919061422b565b61138a57600080fd5b60005b835181101561144a578381815181106113a9576113a8614041565b5b602002602001015173ffffffffffffffffffffffffffffffffffffffff1663a7852afa838584815181106113e0576113df614041565b5b60200260200101516040518363ffffffff1660e01b81526004016114059291906143aa565b600060405180830381600087803b15801561141f57600080fd5b505af1158015611433573d6000803e3d6000fd5b5050505080806114429061418d565b91505061138d565b50505050565b7f000000000000000000000000000000000000000000000000000000000000000081565b600a60003373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060009054906101000a900460ff166114ca57600080fd5b600082111561155f577f000000000000000000000000000000000000000000000000000000000000000073ffffffffffffffffffffffffffffffffffffffff1663fbd3a29d836040518263ffffffff1660e01b815260040161152c9190613928565b600060405180830381600087803b15801561154657600080fd5b505af115801561155a573d6000803e3d6000fd5b505050505b3373ffffffffffffffffffffffffffffffffffffffff168173ffffffffffffffffffffffffffffffffffffffff167f60940192810a6fb3bce3fd3e2e3a13fd6ccc7605e963fb87ee971aba829989bd846040516115bc9190613928565b60405180910390a35050565b6115d1816135e0565b50565b60008290505b8181101561169b5761168860036000600284815481106115fd576115fc614041565b5b9060005260206000200160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060009054906101000a900473ffffffffffffffffffffffffffffffffffffffff16610ff0565b80806116939061418d565b9150506115da565b505050565b7f000000000000000000000000000000000000000000000000000000000000000073ffffffffffffffffffffffffffffffffffffffff1663430c208133836040518363ffffffff1660e01b81526004016116fb9291906141d6565b602060405180830381865afa158015611718573d6000803e3d6000fd5b505050506040513d601f19601f8201168201806040525081019061173c919061422b565b61174557600080fd5b60005b83518110156118055783818151811061176457611763614041565b5b602002602001015173ffffffffffffffffffffffffffffffffffffffff1663a7852afa8385848151811061179b5761179a614041565b5b60200260200101516040518363ffffffff1660e01b81526004016117c09291906143aa565b600060405180830381600087803b1580156117da57600080fd5b505af11580156117ee573d6000803e3d6000fd5b5050505080806117fd9061418d565b915050611748565b50505050565b60096020528060005260406000206000915090505481565b7f000000000000000000000000000000000000000000000000000000000000000081565b60015481565b60008111156119d8577f000000000000000000000000000000000000000000000000000000000000000073ffffffffffffffffffffffffffffffffffffffff16636352211e826040518263ffffffff1660e01b81526004016118af9190613928565b602060405180830381865afa1580156118cc573d6000803e3d6000fd5b505050506040513d601f19601f820116820180604052508101906118f091906143ef565b73ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff161461192757600080fd5b61192f61249d565b7f000000000000000000000000000000000000000000000000000000000000000073ffffffffffffffffffffffffffffffffffffffff1663e7e242d4836040518263ffffffff1660e01b81526004016119889190613928565b602060405180830381865afa1580156119a5573d6000803e3d6000fd5b505050506040513d601f19601f820116820180604052508101906119c9919061437d565b116119d357600080fd5b611a2c565b611a2b7f00000000000000000000000000000000000000000000000000000000000000003360008054906101000a900473ffffffffffffffffffffffffffffffffffffffff16611a2661249d565b61338e565b5b611a35826134d4565b5050565b60008290505b81811015611b0057611aed6003600060028481548110611a6257611a61614041565b5b9060005260206000200160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060009054906101000a900473ffffffffffffffffffffffffffffffffffffffff166135e0565b8080611af89061418d565b915050611a3f565b505050565b60008073ffffffffffffffffffffffffffffffffffffffff16600360008473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1614611bd4576040517f08c379a0000000000000000000000000000000000000000000000000000000008152600401611bcb90614479565b60405180910390fd5b7f000000000000000000000000000000000000000000000000000000000000000073ffffffffffffffffffffffffffffffffffffffff1663e5e31b13836040518263ffffffff1660e01b8152600401611c2d91906138f4565b602060405180830381865afa158015611c4a573d6000803e3d6000fd5b505050506040513d601f19601f82011682018060405250810190611c6e919061422b565b611cad576040517f08c379a0000000000000000000000000000000000000000000000000000000008152600401611ca4906144e5565b60405180910390fd5b6000808373ffffffffffffffffffffffffffffffffffffffff16639d63848a6040518163ffffffff1660e01b815260040160408051808303816000875af1158015611cfc573d6000803e3d6000fd5b505050506040513d601f19601f82011682018060405250810190611d209190614505565b91509150600b60008373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060009054906101000a900460ff168015611dc65750600b60008273ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060009054906101000a900460ff165b611e05576040517f08c379a0000000000000000000000000000000000000000000000000000000008152600401611dfc90614591565b60405180910390fd5b60007f000000000000000000000000000000000000000000000000000000000000000073ffffffffffffffffffffffffffffffffffffffff1663d27b9a786040518163ffffffff1660e01b81526004016020604051808303816000875af1158015611e74573d6000803e3d6000fd5b505050506040513d601f19601f82011682018060405250810190611e9891906143ef565b905060007f000000000000000000000000000000000000000000000000000000000000000073ffffffffffffffffffffffffffffffffffffffff16631c48e0fa87847f00000000000000000000000000000000000000000000000000000000000000006040518463ffffffff1660e01b8152600401611f19939291906145b1565b6020604051808303816000875af1158015611f38573d6000803e3d6000fd5b505050506040513d601f19601f82011682018060405250810190611f5c91906143ef565b90507f000000000000000000000000000000000000000000000000000000000000000073ffffffffffffffffffffffffffffffffffffffff1663095ea7b3827fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff6040518363ffffffff1660e01b8152600401611fd99291906141d6565b6020604051808303816000875af1158015611ff8573d6000803e3d6000fd5b505050506040513d601f19601f8201168201806040525081019061201c919061422b565b5081600560008373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff16021790555080600360008873ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff16021790555085600460008373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff1602179055506001600a60008373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060006101000a81548160ff0219169083151502179055506121f8816135e0565b6002869080600181540180825580915050600190039060005260206000200160009091909190916101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff1602179055508573ffffffffffffffffffffffffffffffffffffffff168273ffffffffffffffffffffffffffffffffffffffff168273ffffffffffffffffffffffffffffffffffffffff167f48d3c521fd0d5541640f58c6d6381eed7cb2e8c9df421ae165a4f4c2d221ee0d336040516122cf91906138f4565b60405180910390a480945050505050919050565b600a60003373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060009054906101000a900460ff1661233957600080fd5b3373ffffffffffffffffffffffffffffffffffffffff168273ffffffffffffffffffffffffffffffffffffffff167fdcbc1c05240f31ff3ad067ef1ee35ce4997762752e3a095284754544f4c709d785846040516123989291906145e8565b60405180910390a3505050565b60066020528060005260406000206000915090505481565b600860205281600052604060002081815481106123d957600080fd5b906000526020600020016000915091509054906101000a900473ffffffffffffffffffffffffffffffffffffffff1681565b60056020528060005260406000206000915054906101000a900473ffffffffffffffffffffffffffffffffffffffff1681565b600a6020528060005260406000206000915054906101000a900460ff1681565b6002818154811061246e57600080fd5b906000526020600020016000915054906101000a900473ffffffffffffffffffffffffffffffffffffffff1681565b600060c87f000000000000000000000000000000000000000000000000000000000000000073ffffffffffffffffffffffffffffffffffffffff166318160ddd6040518163ffffffff1660e01b8152600401602060405180830381865afa15801561250c573d6000803e3d6000fd5b505050506040513d601f19601f82011682018060405250810190612530919061437d565b7f000000000000000000000000000000000000000000000000000000000000000073ffffffffffffffffffffffffffffffffffffffff166318160ddd6040518163ffffffff1660e01b8152600401602060405180830381865afa15801561259b573d6000803e3d6000fd5b505050506040513d601f19601f820116820180604052508101906125bf919061437d565b6125c99190614611565b6125d391906142e1565b905090565b60036020528060005260406000206000915054906101000a900473ffffffffffffffffffffffffffffffffffffffff1681565b7f000000000000000000000000000000000000000000000000000000000000000081565b60005b81518110156126da5781818151811061264e5761264d614041565b5b602002602001015173ffffffffffffffffffffffffffffffffffffffff1663d294f0936040518163ffffffff1660e01b815260040160408051808303816000875af11580156126a1573d6000803e3d6000fd5b505050506040513d601f19601f820116820180604052508101906126c59190614645565b505080806126d29061418d565b915050612632565b5050565b6007602052816000526040600020602052806000526040600020600091509150505481565b60005b81518110156127455761273282828151811061272557612724614041565b5b60200260200101516135e0565b808061273d9061418d565b915050612706565b5050565b61275960006002805490506115d4565b565b600a60003373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060009054906101000a900460ff166127b157600080fd5b3373ffffffffffffffffffffffffffffffffffffffff168273ffffffffffffffffffffffffffffffffffffffff167ff341246adaac6f497bc2a656f546ab9e182111d630394f0c57c710a59a2cb56785846040516128109291906145e8565b60405180910390a3505050565b7f000000000000000000000000000000000000000000000000000000000000000073ffffffffffffffffffffffffffffffffffffffff1663430c208133876040518363ffffffff1660e01b81526004016128789291906141d6565b602060405180830381865afa158015612895573d6000803e3d6000fd5b505050506040513d601f19601f820116820180604052508101906128b9919061422b565b6128c257600080fd5b8181905084849050146128d457600080fd5b61296185858580806020026020016040519081016040528093929190818152602001838360200280828437600081840152601f19601f82011690508083019250505050505050848480806020026020016040519081016040528093929190818152602001838360200280828437600081840152601f19601f82011690508083019250505050505050612d55565b5050505050565b60006008600083815260200190815260200160002090506000818054905090506000805b82811015612cfd5760008482815481106129a9576129a8614041565b5b9060005260206000200160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff16905060006007600088815260200190815260200160002060008373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002054905060008114612ce857612a9b600360008473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060009054906101000a900473ffffffffffffffffffffffffffffffffffffffff166135e0565b80600660008473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1681526020019081526020016000206000828254612aea9190614685565b92505081905550806007600089815260200190815260200160002060008473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1681526020019081526020016000206000828254612b519190614685565b925050819055506000811315612c9f5760056000600360008573ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16639e2bf22c82896040518363ffffffff1660e01b8152600401612c5a9291906145e8565b600060405180830381600087803b158015612c7457600080fd5b505af1158015612c88573d6000803e3d6000fd5b505050508084612c989190614719565b9350612cae565b8084612cab9190614685565b93505b7f6b3894ce60b9bbe9d93f1a4e6fc25b6b93cd8222e73ab6348d79c596f5b51de98782604051612cdf9291906147ad565b60405180910390a15b50508080612cf59061418d565b91505061298c565b508060016000828254612d109190614611565b9250508190555060006009600086815260200190815260200160002081905550600860008581526020019081526020016000206000612d4f9190613808565b50505050565b612d5e83612968565b60008251905060007f000000000000000000000000000000000000000000000000000000000000000073ffffffffffffffffffffffffffffffffffffffff1663e7e242d4866040518263ffffffff1660e01b8152600401612dbf9190613928565b602060405180830381865afa158015612ddc573d6000803e3d6000fd5b505050506040513d601f19601f82011682018060405250810190612e00919061437d565b90506000806000805b85811015612e98576000878281518110612e2657612e25614041565b5b602002602001015113612e5c57868181518110612e4657612e45614041565b5b6020026020010151612e57906147d6565b612e78565b868181518110612e6f57612e6e614041565b5b60200260200101515b84612e839190614719565b93508080612e909061418d565b915050612e09565b5060005b858110156132bd576000888281518110612eb957612eb8614041565b5b602002602001015190506000600360008373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060009054906101000a900473ffffffffffffffffffffffffffffffffffffffff169050600a60008273ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060009054906101000a900460ff16156132a857600086888b8681518110612f9057612f8f614041565b5b6020026020010151612fa2919061481f565b612fac9190614936565b90506000600760008e815260200190815260200160002060008573ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff168152602001908152602001600020541461300b57600080fd5b600081141561301957600080fd5b613022826135e0565b600860008d8152602001908152602001600020839080600181540180825580915050600190039060005260206000200160009091909190916101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff16021790555080600660008573ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060008282546130e59190614719565b9250508190555080600760008e815260200190815260200160002060008573ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff168152602001908152602001600020600082825461314c9190614719565b92505081905550600081131561322d57600560008373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1663f3207723828e6040518363ffffffff1660e01b81526004016131f69291906145e8565b600060405180830381600087803b15801561321057600080fd5b505af1158015613224573d6000803e3d6000fd5b5050505061323a565b80613237906147d6565b90505b80856132469190614719565b945080866132549190614719565b95503373ffffffffffffffffffffffffffffffffffffffff167f1263a2295e53acd6ef8f655b8afc11fa0f2cf11925be7aa1757d741ef32a926c8d8360405161329e9291906147ad565b60405180910390a2505b505080806132b59061418d565b915050612e9c565b506000811315613353577f000000000000000000000000000000000000000000000000000000000000000073ffffffffffffffffffffffffffffffffffffffff1663fd4a77f1896040518263ffffffff1660e01b81526004016133209190613928565b600060405180830381600087803b15801561333a57600080fd5b505af115801561334e573d6000803e3d6000fd5b505050505b81600160008282546133659190614312565b9250508190555080600960008a8152602001908152602001600020819055505050505050505050565b60008473ffffffffffffffffffffffffffffffffffffffff163b116133b257600080fd5b6000808573ffffffffffffffffffffffffffffffffffffffff166323b872dd60e01b8686866040516024016133e9939291906149a0565b604051602081830303815290604052907bffffffffffffffffffffffffffffffffffffffffffffffffffffffff19166020820180517bffffffffffffffffffffffffffffffffffffffffffffffffffffffff83818316178352505050506040516134539190614a51565b6000604051808303816000865af19150503d8060008114613490576040519150601f19603f3d011682016040523d82523d6000602084013e613495565b606091505b50915091508180156134c357506000815114806134c25750808060200190518101906134c1919061422b565b5b5b6134cc57600080fd5b505050505050565b600b60008273ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060009054906101000a900460ff161561352b57600080fd5b6001600b60008373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060006101000a81548160ff0219169083151502179055508073ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff167f6661a7108aecd07864384529117d96c319c1163e3010c01390f6b704726e07de60405160405180910390a350565b6000600460008373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1690506000600660008373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002054905060008113156137bc576000600e60008573ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1681526020019081526020016000205490506000600d54905080600e60008773ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff168152602001908152602001600020819055506000828261372e9190614611565b905060008111156137b4576000670de0b6b3a764000082866137509190614258565b61375a91906142e1565b905080600f60008973ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060008282546137ab9190614312565b92505081905550505b505050613803565b600d54600e60008573ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff168152602001908152602001600020819055505b505050565b50805460008255906000526020600020908101906138269190613829565b50565b5b8082111561384257600081600090555060010161382a565b5090565b6000604051905090565b600080fd5b600080fd5b600073ffffffffffffffffffffffffffffffffffffffff82169050919050565b60006138858261385a565b9050919050565b6138958161387a565b81146138a057600080fd5b50565b6000813590506138b28161388c565b92915050565b6000602082840312156138ce576138cd613850565b5b60006138dc848285016138a3565b91505092915050565b6138ee8161387a565b82525050565b600060208201905061390960008301846138e5565b92915050565b6000819050919050565b6139228161390f565b82525050565b600060208201905061393d6000830184613919565b92915050565b600080fd5b6000601f19601f8301169050919050565b7f4e487b7100000000000000000000000000000000000000000000000000000000600052604160045260246000fd5b61399182613948565b810181811067ffffffffffffffff821117156139b0576139af613959565b5b80604052505050565b60006139c3613846565b90506139cf8282613988565b919050565b600067ffffffffffffffff8211156139ef576139ee613959565b5b602082029050602081019050919050565b600080fd5b6000613a18613a13846139d4565b6139b9565b90508083825260208201905060208402830185811115613a3b57613a3a613a00565b5b835b81811015613a645780613a5088826138a3565b845260208401935050602081019050613a3d565b5050509392505050565b600082601f830112613a8357613a82613943565b5b8135613a93848260208601613a05565b91505092915050565b600067ffffffffffffffff821115613ab757613ab6613959565b5b602082029050602081019050919050565b6000613adb613ad684613a9c565b6139b9565b90508083825260208201905060208402830185811115613afe57613afd613a00565b5b835b81811015613b4557803567ffffffffffffffff811115613b2357613b22613943565b5b808601613b308982613a6e565b85526020850194505050602081019050613b00565b5050509392505050565b600082601f830112613b6457613b63613943565b5b8135613b74848260208601613ac8565b91505092915050565b60008060408385031215613b9457613b93613850565b5b600083013567ffffffffffffffff811115613bb257613bb1613855565b5b613bbe85828601613a6e565b925050602083013567ffffffffffffffff811115613bdf57613bde613855565b5b613beb85828601613b4f565b9150509250929050565b613bfe8161390f565b8114613c0957600080fd5b50565b600081359050613c1b81613bf5565b92915050565b600060208284031215613c3757613c36613850565b5b6000613c4584828501613c0c565b91505092915050565b60008115159050919050565b613c6381613c4e565b82525050565b6000602082019050613c7e6000830184613c5a565b92915050565b60008060408385031215613c9b57613c9a613850565b5b6000613ca985828601613c0c565b9250506020613cba858286016138a3565b9150509250929050565b60008060408385031215613cdb57613cda613850565b5b600083013567ffffffffffffffff811115613cf957613cf8613855565b5b613d0585828601613a6e565b9250506020613d16858286016138a3565b9150509250929050565b600060208284031215613d3657613d35613850565b5b600082013567ffffffffffffffff811115613d5457613d53613855565b5b613d6084828501613a6e565b91505092915050565b600080600060608486031215613d8257613d81613850565b5b600084013567ffffffffffffffff811115613da057613d9f613855565b5b613dac86828701613a6e565b935050602084013567ffffffffffffffff811115613dcd57613dcc613855565b5b613dd986828701613b4f565b9250506040613dea86828701613c0c565b9150509250925092565b60008060408385031215613e0b57613e0a613850565b5b6000613e1985828601613c0c565b9250506020613e2a85828601613c0c565b9150509250929050565b60008060408385031215613e4b57613e4a613850565b5b6000613e59858286016138a3565b9250506020613e6a85828601613c0c565b9150509250929050565b600080600060608486031215613e8d57613e8c613850565b5b6000613e9b86828701613c0c565b9350506020613eac868287016138a3565b9250506040613ebd86828701613c0c565b9150509250925092565b6000819050919050565b613eda81613ec7565b82525050565b6000602082019050613ef56000830184613ed1565b92915050565b600080fd5b60008083601f840112613f1657613f15613943565b5b8235905067ffffffffffffffff811115613f3357613f32613efb565b5b602083019150836020820283011115613f4f57613f4e613a00565b5b9250929050565b60008083601f840112613f6c57613f6b613943565b5b8235905067ffffffffffffffff811115613f8957613f88613efb565b5b602083019150836020820283011115613fa557613fa4613a00565b5b9250929050565b600080600080600060608688031215613fc857613fc7613850565b5b6000613fd688828901613c0c565b955050602086013567ffffffffffffffff811115613ff757613ff6613855565b5b61400388828901613f00565b9450945050604086013567ffffffffffffffff81111561402657614025613855565b5b61403288828901613f56565b92509250509295509295909350565b7f4e487b7100000000000000000000000000000000000000000000000000000000600052603260045260246000fd5b600081519050919050565b600082825260208201905092915050565b6000819050602082019050919050565b6140a58161387a565b82525050565b60006140b7838361409c565b60208301905092915050565b6000602082019050919050565b60006140db82614070565b6140e5818561407b565b93506140f08361408c565b8060005b8381101561412157815161410888826140ab565b9750614113836140c3565b9250506001810190506140f4565b5085935050505092915050565b600060408201905061414360008301856138e5565b818103602083015261415581846140d0565b90509392505050565b7f4e487b7100000000000000000000000000000000000000000000000000000000600052601160045260246000fd5b60006141988261390f565b91507fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff8214156141cb576141ca61415e565b5b600182019050919050565b60006040820190506141eb60008301856138e5565b6141f86020830184613919565b9392505050565b61420881613c4e565b811461421357600080fd5b50565b600081519050614225816141ff565b92915050565b60006020828403121561424157614240613850565b5b600061424f84828501614216565b91505092915050565b60006142638261390f565b915061426e8361390f565b9250817fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff04831182151516156142a7576142a661415e565b5b828202905092915050565b7f4e487b7100000000000000000000000000000000000000000000000000000000600052601260045260246000fd5b60006142ec8261390f565b91506142f78361390f565b925082614307576143066142b2565b5b828204905092915050565b600061431d8261390f565b91506143288361390f565b9250827fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff0382111561435d5761435c61415e565b5b828201905092915050565b60008151905061437781613bf5565b92915050565b60006020828403121561439357614392613850565b5b60006143a184828501614368565b91505092915050565b60006040820190506143bf6000830185613919565b81810360208301526143d181846140d0565b90509392505050565b6000815190506143e98161388c565b92915050565b60006020828403121561440557614404613850565b5b6000614413848285016143da565b91505092915050565b600082825260208201905092915050565b7f6578697374730000000000000000000000000000000000000000000000000000600082015250565b600061446360068361441c565b915061446e8261442d565b602082019050919050565b6000602082019050818103600083015261449281614456565b9050919050565b7f215f706f6f6c0000000000000000000000000000000000000000000000000000600082015250565b60006144cf60068361441c565b91506144da82614499565b602082019050919050565b600060208201905081810360008301526144fe816144c2565b9050919050565b6000806040838503121561451c5761451b613850565b5b600061452a858286016143da565b925050602061453b858286016143da565b9150509250929050565b7f2177686974656c69737465640000000000000000000000000000000000000000600082015250565b600061457b600c8361441c565b915061458682614545565b602082019050919050565b600060208201905081810360008301526145aa8161456e565b9050919050565b60006060820190506145c660008301866138e5565b6145d360208301856138e5565b6145e060408301846138e5565b949350505050565b60006040820190506145fd6000830185613919565b61460a6020830184613919565b9392505050565b600061461c8261390f565b91506146278361390f565b92508282101561463a5761463961415e565b5b828203905092915050565b6000806040838503121561465c5761465b613850565b5b600061466a85828601614368565b925050602061467b85828601614368565b9150509250929050565b600061469082613ec7565b915061469b83613ec7565b9250827f8000000000000000000000000000000000000000000000000000000000000000018212600084121516156146d6576146d561415e565b5b827f7fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff01821360008412161561470e5761470d61415e565b5b828203905092915050565b600061472482613ec7565b915061472f83613ec7565b9250817f7fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff0383136000831215161561476a5761476961415e565b5b817f80000000000000000000000000000000000000000000000000000000000000000383126000831216156147a2576147a161415e565b5b828201905092915050565b60006040820190506147c26000830185613919565b6147cf6020830184613ed1565b9392505050565b60006147e182613ec7565b91507f80000000000000000000000000000000000000000000000000000000000000008214156148145761481361415e565b5b816000039050919050565b600061482a82613ec7565b915061483583613ec7565b9250827f7fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff04821160008413600084131616156148745761487361415e565b5b817f800000000000000000000000000000000000000000000000000000000000000005831260008412600084131616156148b1576148b061415e565b5b827f800000000000000000000000000000000000000000000000000000000000000005821260008413600084121616156148ee576148ed61415e565b5b827f7fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff058212600084126000841216161561492b5761492a61415e565b5b828202905092915050565b600061494182613ec7565b915061494c83613ec7565b92508261495c5761495b6142b2565b5b600160000383147f8000000000000000000000000000000000000000000000000000000000000000831416156149955761499461415e565b5b828205905092915050565b60006060820190506149b560008301866138e5565b6149c260208301856138e5565b6149cf6040830184613919565b949350505050565b600081519050919050565b600081905092915050565b60005b83811015614a0b5780820151818401526020810190506149f0565b83811115614a1a576000848401525b50505050565b6000614a2b826149d7565b614a3581856149e2565b9350614a458185602086016149ed565b80840191505092915050565b6000614a5d8284614a20565b91508190509291505056fea26469706673582212208a4ff121d3a7fe5073a56511415821f523abba871b7a2460847ba3c81a13401064736f6c634300080b0033";
        public BaseVoterDeploymentBase() : base(BYTECODE) { }
        public BaseVoterDeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("address", "__ve", 1)]
        public virtual string Ve { get; set; }
        [Parameter("address", "_factory", 2)]
        public virtual string Factory { get; set; }
        [Parameter("address", "_gauges", 3)]
        public virtual string Gauges { get; set; }
        [Parameter("address", "_bribes", 4)]
        public virtual string Bribes { get; set; }
    }

    public partial class VeFunction : VeFunctionBase { }

    [Function("_ve", "address")]
    public class VeFunctionBase : FunctionMessage
    {

    }

    public partial class AttachTokenToGaugeFunction : AttachTokenToGaugeFunctionBase { }

    [Function("attachTokenToGauge")]
    public class AttachTokenToGaugeFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
        [Parameter("address", "account", 2)]
        public virtual string Account { get; set; }
    }

    public partial class BribefactoryFunction : BribefactoryFunctionBase { }

    [Function("bribefactory", "address")]
    public class BribefactoryFunctionBase : FunctionMessage
    {

    }

    public partial class BribesFunction : BribesFunctionBase { }

    [Function("bribes", "address")]
    public class BribesFunctionBase : FunctionMessage
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class ClaimBribesFunction : ClaimBribesFunctionBase { }

    [Function("claimBribes")]
    public class ClaimBribesFunctionBase : FunctionMessage
    {
        [Parameter("address[]", "_bribes", 1)]
        public virtual List<string> Bribes { get; set; }
        [Parameter("address[][]", "_tokens", 2)]
        public virtual List<List<string>> Tokens { get; set; }
        [Parameter("uint256", "_tokenId", 3)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class ClaimFeesFunction : ClaimFeesFunctionBase { }

    [Function("claimFees")]
    public class ClaimFeesFunctionBase : FunctionMessage
    {
        [Parameter("address[]", "_fees", 1)]
        public virtual List<string> Fees { get; set; }
        [Parameter("address[][]", "_tokens", 2)]
        public virtual List<List<string>> Tokens { get; set; }
        [Parameter("uint256", "_tokenId", 3)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class ClaimRewardsFunction : ClaimRewardsFunctionBase { }

    [Function("claimRewards")]
    public class ClaimRewardsFunctionBase : FunctionMessage
    {
        [Parameter("address[]", "_gauges", 1)]
        public virtual List<string> Gauges { get; set; }
        [Parameter("address[][]", "_tokens", 2)]
        public virtual List<List<string>> Tokens { get; set; }
    }

    public partial class ClaimableFunction : ClaimableFunctionBase { }

    [Function("claimable", "uint256")]
    public class ClaimableFunctionBase : FunctionMessage
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class CreateGaugeFunction : CreateGaugeFunctionBase { }

    [Function("createGauge", "address")]
    public class CreateGaugeFunctionBase : FunctionMessage
    {
        [Parameter("address", "_pool", 1)]
        public virtual string Pool { get; set; }
    }

    public partial class DetachTokenFromGaugeFunction : DetachTokenFromGaugeFunctionBase { }

    [Function("detachTokenFromGauge")]
    public class DetachTokenFromGaugeFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
        [Parameter("address", "account", 2)]
        public virtual string Account { get; set; }
    }

    public partial class DistributeFunction : DistributeFunctionBase { }

    [Function("distribute")]
    public class DistributeFunctionBase : FunctionMessage
    {
        [Parameter("address[]", "_gauges", 1)]
        public virtual List<string> Gauges { get; set; }
    }


    public partial class DistributeFeesFunction : DistributeFeesFunctionBase { }

    [Function("distributeFees")]
    public class DistributeFeesFunctionBase : FunctionMessage
    {
        [Parameter("address[]", "_gauges", 1)]
        public virtual List<string> Gauges { get; set; }
    }

    public partial class DistroFunction : DistroFunctionBase { }

    [Function("distro")]
    public class DistroFunctionBase : FunctionMessage
    {

    }

    public partial class EmitDepositFunction : EmitDepositFunctionBase { }

    [Function("emitDeposit")]
    public class EmitDepositFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
        [Parameter("address", "account", 2)]
        public virtual string Account { get; set; }
        [Parameter("uint256", "amount", 3)]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class EmitWithdrawFunction : EmitWithdrawFunctionBase { }

    [Function("emitWithdraw")]
    public class EmitWithdrawFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
        [Parameter("address", "account", 2)]
        public virtual string Account { get; set; }
        [Parameter("uint256", "amount", 3)]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class FactoryFunction : FactoryFunctionBase { }

    [Function("factory", "address")]
    public class FactoryFunctionBase : FunctionMessage
    {

    }

    public partial class GaugefactoryFunction : GaugefactoryFunctionBase { }

    [Function("gaugefactory", "address")]
    public class GaugefactoryFunctionBase : FunctionMessage
    {

    }

    public partial class GaugesFunction : GaugesFunctionBase { }

    [Function("gauges", "address")]
    public class GaugesFunctionBase : FunctionMessage
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class InitializeFunction : InitializeFunctionBase { }

    [Function("initialize")]
    public class InitializeFunctionBase : FunctionMessage
    {
        [Parameter("address[]", "_tokens", 1)]
        public virtual List<string> Tokens { get; set; }
        [Parameter("address", "_minter", 2)]
        public virtual string Minter { get; set; }
    }

    public partial class IsGaugeFunction : IsGaugeFunctionBase { }

    [Function("isGauge", "bool")]
    public class IsGaugeFunctionBase : FunctionMessage
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class IsWhitelistedFunction : IsWhitelistedFunctionBase { }

    [Function("isWhitelisted", "bool")]
    public class IsWhitelistedFunctionBase : FunctionMessage
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class LengthFunction : LengthFunctionBase { }

    [Function("length", "uint256")]
    public class LengthFunctionBase : FunctionMessage
    {

    }

    public partial class Listing_feeFunction : Listing_feeFunctionBase { }

    [Function("listing_fee", "uint256")]
    public class Listing_feeFunctionBase : FunctionMessage
    {

    }

    public partial class MinterFunction : MinterFunctionBase { }

    [Function("minter", "address")]
    public class MinterFunctionBase : FunctionMessage
    {

    }

    public partial class NotifyRewardAmountFunction : NotifyRewardAmountFunctionBase { }

    [Function("notifyRewardAmount")]
    public class NotifyRewardAmountFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "amount", 1)]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class PokeFunction : PokeFunctionBase { }

    [Function("poke")]
    public class PokeFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class PoolForGaugeFunction : PoolForGaugeFunctionBase { }

    [Function("poolForGauge", "address")]
    public class PoolForGaugeFunctionBase : FunctionMessage
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class PoolVoteFunction : PoolVoteFunctionBase { }

    [Function("poolVote", "address")]
    public class PoolVoteFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
        [Parameter("uint256", "", 2)]
        public virtual BigInteger ReturnValue2 { get; set; }
    }

    public partial class PoolsFunction : PoolsFunctionBase { }

    [Function("pools", "address")]
    public class PoolsFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class ResetFunction : ResetFunctionBase { }

    [Function("reset")]
    public class ResetFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class TotalWeightFunction : TotalWeightFunctionBase { }

    [Function("totalWeight", "uint256")]
    public class TotalWeightFunctionBase : FunctionMessage
    {

    }

    public partial class UpdateAllFunction : UpdateAllFunctionBase { }

    [Function("updateAll")]
    public class UpdateAllFunctionBase : FunctionMessage
    {

    }

    public partial class UpdateForFunction : UpdateForFunctionBase { }

    [Function("updateFor")]
    public class UpdateForFunctionBase : FunctionMessage
    {
        [Parameter("address[]", "_gauges", 1)]
        public virtual List<string> Gauges { get; set; }
    }

    public partial class UpdateForRangeFunction : UpdateForRangeFunctionBase { }

    [Function("updateForRange")]
    public class UpdateForRangeFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "start", 1)]
        public virtual BigInteger Start { get; set; }
        [Parameter("uint256", "end", 2)]
        public virtual BigInteger End { get; set; }
    }

    public partial class UpdateGaugeFunction : UpdateGaugeFunctionBase { }

    [Function("updateGauge")]
    public class UpdateGaugeFunctionBase : FunctionMessage
    {
        [Parameter("address", "_gauge", 1)]
        public virtual string Gauge { get; set; }
    }

    public partial class UsedWeightsFunction : UsedWeightsFunctionBase { }

    [Function("usedWeights", "uint256")]
    public class UsedWeightsFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class VoteFunction : VoteFunctionBase { }

    [Function("vote")]
    public class VoteFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
        [Parameter("address[]", "_poolVote", 2)]
        public virtual List<string> PoolVote { get; set; }
        [Parameter("int256[]", "_weights", 3)]
        public virtual List<BigInteger> Weights { get; set; }
    }

    public partial class VotesFunction : VotesFunctionBase { }

    [Function("votes", "int256")]
    public class VotesFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
        [Parameter("address", "", 2)]
        public virtual string ReturnValue2 { get; set; }
    }

    public partial class WeightsFunction : WeightsFunctionBase { }

    [Function("weights", "int256")]
    public class WeightsFunctionBase : FunctionMessage
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class WhitelistFunction : WhitelistFunctionBase { }

    [Function("whitelist")]
    public class WhitelistFunctionBase : FunctionMessage
    {
        [Parameter("address", "_token", 1)]
        public virtual string Token { get; set; }
        [Parameter("uint256", "_tokenId", 2)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class AbstainedEventDTO : AbstainedEventDTOBase { }

    [Event("Abstained")]
    public class AbstainedEventDTOBase : IEventDTO
    {
        [Parameter("uint256", "tokenId", 1, false)]
        public virtual BigInteger TokenId { get; set; }
        [Parameter("int256", "weight", 2, false)]
        public virtual BigInteger Weight { get; set; }
    }

    public partial class AttachEventDTO : AttachEventDTOBase { }

    [Event("Attach")]
    public class AttachEventDTOBase : IEventDTO
    {
        [Parameter("address", "owner", 1, true)]
        public virtual string Owner { get; set; }
        [Parameter("address", "gauge", 2, true)]
        public virtual string Gauge { get; set; }
        [Parameter("uint256", "tokenId", 3, false)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class DepositEventDTO : DepositEventDTOBase { }

    [Event("Deposit")]
    public class DepositEventDTOBase : IEventDTO
    {
        [Parameter("address", "lp", 1, true)]
        public virtual string Lp { get; set; }
        [Parameter("address", "gauge", 2, true)]
        public virtual string Gauge { get; set; }
        [Parameter("uint256", "tokenId", 3, false)]
        public virtual BigInteger TokenId { get; set; }
        [Parameter("uint256", "amount", 4, false)]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class DetachEventDTO : DetachEventDTOBase { }

    [Event("Detach")]
    public class DetachEventDTOBase : IEventDTO
    {
        [Parameter("address", "owner", 1, true)]
        public virtual string Owner { get; set; }
        [Parameter("address", "gauge", 2, true)]
        public virtual string Gauge { get; set; }
        [Parameter("uint256", "tokenId", 3, false)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class DistributeRewardEventDTO : DistributeRewardEventDTOBase { }

    [Event("DistributeReward")]
    public class DistributeRewardEventDTOBase : IEventDTO
    {
        [Parameter("address", "sender", 1, true)]
        public virtual string Sender { get; set; }
        [Parameter("address", "gauge", 2, true)]
        public virtual string Gauge { get; set; }
        [Parameter("uint256", "amount", 3, false)]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class GaugeCreatedEventDTO : GaugeCreatedEventDTOBase { }

    [Event("GaugeCreated")]
    public class GaugeCreatedEventDTOBase : IEventDTO
    {
        [Parameter("address", "gauge", 1, true)]
        public virtual string Gauge { get; set; }
        [Parameter("address", "creator", 2, false)]
        public virtual string Creator { get; set; }
        [Parameter("address", "bribe", 3, true)]
        public virtual string Bribe { get; set; }
        [Parameter("address", "pool", 4, true)]
        public virtual string Pool { get; set; }
    }

    public partial class NotifyRewardEventDTO : NotifyRewardEventDTOBase { }

    [Event("NotifyReward")]
    public class NotifyRewardEventDTOBase : IEventDTO
    {
        [Parameter("address", "sender", 1, true)]
        public virtual string Sender { get; set; }
        [Parameter("address", "reward", 2, true)]
        public virtual string Reward { get; set; }
        [Parameter("uint256", "amount", 3, false)]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class VotedEventDTO : VotedEventDTOBase { }

    [Event("Voted")]
    public class VotedEventDTOBase : IEventDTO
    {
        [Parameter("address", "voter", 1, true)]
        public virtual string Voter { get; set; }
        [Parameter("uint256", "tokenId", 2, false)]
        public virtual BigInteger TokenId { get; set; }
        [Parameter("int256", "weight", 3, false)]
        public virtual BigInteger Weight { get; set; }
    }

    public partial class WhitelistedEventDTO : WhitelistedEventDTOBase { }

    [Event("Whitelisted")]
    public class WhitelistedEventDTOBase : IEventDTO
    {
        [Parameter("address", "whitelister", 1, true)]
        public virtual string Whitelister { get; set; }
        [Parameter("address", "token", 2, true)]
        public virtual string Token { get; set; }
    }

    public partial class WithdrawEventDTO : WithdrawEventDTOBase { }

    [Event("Withdraw")]
    public class WithdrawEventDTOBase : IEventDTO
    {
        [Parameter("address", "lp", 1, true)]
        public virtual string Lp { get; set; }
        [Parameter("address", "gauge", 2, true)]
        public virtual string Gauge { get; set; }
        [Parameter("uint256", "tokenId", 3, false)]
        public virtual BigInteger TokenId { get; set; }
        [Parameter("uint256", "amount", 4, false)]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class VeOutputDTO : VeOutputDTOBase { }

    [FunctionOutput]
    public class VeOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }



    public partial class BribefactoryOutputDTO : BribefactoryOutputDTOBase { }

    [FunctionOutput]
    public class BribefactoryOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class BribesOutputDTO : BribesOutputDTOBase { }

    [FunctionOutput]
    public class BribesOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }







    public partial class ClaimableOutputDTO : ClaimableOutputDTOBase { }

    [FunctionOutput]
    public class ClaimableOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }





















    public partial class FactoryOutputDTO : FactoryOutputDTOBase { }

    [FunctionOutput]
    public class FactoryOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class GaugefactoryOutputDTO : GaugefactoryOutputDTOBase { }

    [FunctionOutput]
    public class GaugefactoryOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class GaugesOutputDTO : GaugesOutputDTOBase { }

    [FunctionOutput]
    public class GaugesOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }



    public partial class IsGaugeOutputDTO : IsGaugeOutputDTOBase { }

    [FunctionOutput]
    public class IsGaugeOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class IsWhitelistedOutputDTO : IsWhitelistedOutputDTOBase { }

    [FunctionOutput]
    public class IsWhitelistedOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class LengthOutputDTO : LengthOutputDTOBase { }

    [FunctionOutput]
    public class LengthOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class Listing_feeOutputDTO : Listing_feeOutputDTOBase { }

    [FunctionOutput]
    public class Listing_feeOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class MinterOutputDTO : MinterOutputDTOBase { }

    [FunctionOutput]
    public class MinterOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }





    public partial class PoolForGaugeOutputDTO : PoolForGaugeOutputDTOBase { }

    [FunctionOutput]
    public class PoolForGaugeOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class PoolVoteOutputDTO : PoolVoteOutputDTOBase { }

    [FunctionOutput]
    public class PoolVoteOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class PoolsOutputDTO : PoolsOutputDTOBase { }

    [FunctionOutput]
    public class PoolsOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }



    public partial class TotalWeightOutputDTO : TotalWeightOutputDTOBase { }

    [FunctionOutput]
    public class TotalWeightOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }









    public partial class UsedWeightsOutputDTO : UsedWeightsOutputDTOBase { }

    [FunctionOutput]
    public class UsedWeightsOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }



    public partial class VotesOutputDTO : VotesOutputDTOBase { }

    [FunctionOutput]
    public class VotesOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("int256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class WeightsOutputDTO : WeightsOutputDTOBase { }

    [FunctionOutput]
    public class WeightsOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("int256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }
}
