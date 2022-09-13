using UnityEngine;
using System.Collections.Generic;


namespace SmalBox
{

	/// <summary>
	/// Create by Auto
	/// ProtobufConfig
	/// </summary>
	public partial class ProtocbufCMD : ScriptableObject {

		[SerializeField]
		public List<CMDInfo> cmdList;


		/// <summary> LoginRequest </summary>
		public static int LoginRequest = 1;

		/// <summary> LoginResponse </summary>
		public static int LoginResponse = 2;

		/// <summary> HeartBeatRequest </summary>
		public static int HeartBeatRequest = 3;

		/// <summary> HeartBeatResponse </summary>
		public static int HeartBeatResponse = 4;

		/// <summary> TestRequest </summary>
		public static int TestRequest = 5;

		/// <summary> MD_OfflineRequest </summary>
		public static int MD_OfflineRequest = 5;

		/// <summary> MD_OfflineResponse </summary>
		public static int MD_OfflineResponse = 6;

		/// <summary> TestResponse </summary>
		public static int TestResponse = 6;

		/// <summary> UseItemRequest </summary>
		public static int UseItemRequest = 21;

		/// <summary> UseItemResponse </summary>
		public static int UseItemResponse = 22;

		/// <summary> ItemChangePush </summary>
		public static int ItemChangePush = 23;

		/// <summary> MD_ItemInfoPush </summary>
		public static int MD_ItemInfoPush = 24;

		/// <summary> MD_AddAttributeRequest </summary>
		public static int MD_AddAttributeRequest = 26;

		/// <summary> MD_AddAttributeResponse </summary>
		public static int MD_AddAttributeResponse = 27;

		/// <summary> MD_AttributeInfoPush </summary>
		public static int MD_AttributeInfoPush = 28;

		/// <summary> SceneChangeRequest </summary>
		public static int SceneChangeRequest = 35;

		/// <summary> SceneChangeResponse </summary>
		public static int SceneChangeResponse = 36;

		/// <summary> SceneUnlockPush </summary>
		public static int SceneUnlockPush = 37;

		/// <summary> FishingInfoPush </summary>
		public static int FishingInfoPush = 40;

		/// <summary> FishingStartRequest </summary>
		public static int FishingStartRequest = 45;

		/// <summary> FishingStartResponse </summary>
		public static int FishingStartResponse = 46;

		/// <summary> FishingCatchRequest </summary>
		public static int FishingCatchRequest = 47;

		/// <summary> FishingCatchResponse </summary>
		public static int FishingCatchResponse = 48;

		/// <summary> FishingRefreshUseItemRequest </summary>
		public static int FishingRefreshUseItemRequest = 49;

		/// <summary> FishingRefreshUseItemResponse </summary>
		public static int FishingRefreshUseItemResponse = 50;

		/// <summary> FishingRefreshPush </summary>
		public static int FishingRefreshPush = 51;

		/// <summary> InsectInfoPush </summary>
		public static int InsectInfoPush = 55;

		/// <summary> InsectCatchRequest </summary>
		public static int InsectCatchRequest = 58;

		/// <summary> InsectCatchResponse </summary>
		public static int InsectCatchResponse = 59;

		/// <summary> InsectQTERequest </summary>
		public static int InsectQTERequest = 60;

		/// <summary> InsectQTEResponse </summary>
		public static int InsectQTEResponse = 61;

		/// <summary> InsectRefreshPush </summary>
		public static int InsectRefreshPush = 62;

		/// <summary> InsectChangeToolRequest </summary>
		public static int InsectChangeToolRequest = 63;

		/// <summary> InsectChangeToolResponse </summary>
		public static int InsectChangeToolResponse = 64;

		/// <summary> InsectStartRequest </summary>
		public static int InsectStartRequest = 65;

		/// <summary> InsectStartResponse </summary>
		public static int InsectStartResponse = 66;

		/// <summary> HandbookInfoRequest </summary>
		public static int HandbookInfoRequest = 71;

		/// <summary> HandbookInfoResponse </summary>
		public static int HandbookInfoResponse = 72;

		/// <summary> HandbookReceiveRequest </summary>
		public static int HandbookReceiveRequest = 73;

		/// <summary> HandbookReceiveResponse </summary>
		public static int HandbookReceiveResponse = 74;

		/// <summary> HandbookCollectionRevRequest </summary>
		public static int HandbookCollectionRevRequest = 75;

		/// <summary> HandbookCollectionRevResponse </summary>
		public static int HandbookCollectionRevResponse = 76;

		/// <summary> HandbookChangePush </summary>
		public static int HandbookChangePush = 77;

		/// <summary> MissionQueryRequest </summary>
		public static int MissionQueryRequest = 81;

		/// <summary> MissionQueryResponse </summary>
		public static int MissionQueryResponse = 82;

		/// <summary> MissionReceiveRequest </summary>
		public static int MissionReceiveRequest = 83;

		/// <summary> MissionReceiveResponse </summary>
		public static int MissionReceiveResponse = 84;

		/// <summary> MissionChangeOnePush </summary>
		public static int MissionChangeOnePush = 85;

		/// <summary> MissionRewardRequest </summary>
		public static int MissionRewardRequest = 86;

		/// <summary> MissionRewardResponse </summary>
		public static int MissionRewardResponse = 87;

		/// <summary> MissionChangeManyPush </summary>
		public static int MissionChangeManyPush = 88;

		/// <summary> EnterMuseumInfoPush </summary>
		public static int EnterMuseumInfoPush = 91;

		/// <summary> PlaceShowcaseRequest </summary>
		public static int PlaceShowcaseRequest = 93;

		/// <summary> PlaceShowcaseResponse </summary>
		public static int PlaceShowcaseResponse = 94;

		/// <summary> MoveShowcaseRequest </summary>
		public static int MoveShowcaseRequest = 95;

		/// <summary> MoveShowcaseResponse </summary>
		public static int MoveShowcaseResponse = 96;

		/// <summary> PackShowcaseRequest </summary>
		public static int PackShowcaseRequest = 97;

		/// <summary> PackShowcaseResponse </summary>
		public static int PackShowcaseResponse = 98;

		/// <summary> PlaceExhibitsRequest </summary>
		public static int PlaceExhibitsRequest = 99;

		/// <summary> PlaceExhibitsResponse </summary>
		public static int PlaceExhibitsResponse = 100;

		/// <summary> MoveExhibitsRequest </summary>
		public static int MoveExhibitsRequest = 101;

		/// <summary> MoveExhibitsResponse </summary>
		public static int MoveExhibitsResponse = 102;

		/// <summary> UnlockMuseumAreaRequest </summary>
		public static int UnlockMuseumAreaRequest = 103;

		/// <summary> UnlockMuseumAreaResponse </summary>
		public static int UnlockMuseumAreaResponse = 104;

		/// <summary> MuseumOfflineRewardPush </summary>
		public static int MuseumOfflineRewardPush = 105;

		/// <summary> LevelupShowcasePush </summary>
		public static int LevelupShowcasePush = 106;

		/// <summary> ReceiveShowcaseRewardRequest </summary>
		public static int ReceiveShowcaseRewardRequest = 107;

		/// <summary> ReceiveShowcaseRewardResponse </summary>
		public static int ReceiveShowcaseRewardResponse = 108;

		/// <summary> RemoveExhibitsRequest </summary>
		public static int RemoveExhibitsRequest = 109;

		/// <summary> RemoveExhibitsResponse </summary>
		public static int RemoveExhibitsResponse = 110;

		/// <summary> ResearchRequest </summary>
		public static int ResearchRequest = 111;

		/// <summary> ResearchResponse </summary>
		public static int ResearchResponse = 112;

		/// <summary> GetAllResearchIdRequest </summary>
		public static int GetAllResearchIdRequest = 113;

		/// <summary> GetAllResearchIdResponse </summary>
		public static int GetAllResearchIdResponse = 114;

		/// <summary> CreateVisitorPush </summary>
		public static int CreateVisitorPush = 121;

		/// <summary> LevelupVisitorRequest </summary>
		public static int LevelupVisitorRequest = 122;

		/// <summary> LevelupVisitorResponse </summary>
		public static int LevelupVisitorResponse = 123;

		/// <summary> VisitorLeaveMuseumRequest </summary>
		public static int VisitorLeaveMuseumRequest = 124;

		/// <summary> VisitorLeaveMuseumResponse </summary>
		public static int VisitorLeaveMuseumResponse = 125;

		/// <summary> VisitShowcaseRequest </summary>
		public static int VisitShowcaseRequest = 126;

		/// <summary> VisitShowcaseResponse </summary>
		public static int VisitShowcaseResponse = 127;

		/// <summary> GiveUpPathRequest </summary>
		public static int GiveUpPathRequest = 128;

		/// <summary> GiveUpPathResponse </summary>
		public static int GiveUpPathResponse = 129;

		/// <summary> GetAllVisitorInfoPush </summary>
		public static int GetAllVisitorInfoPush = 130;

		/// <summary> CreateVisitorGroupPush </summary>
		public static int CreateVisitorGroupPush = 131;

		/// <summary> NpcTalkRequest </summary>
		public static int NpcTalkRequest = 136;

		/// <summary> NpcTalkResponse </summary>
		public static int NpcTalkResponse = 137;

		/// <summary> PurchaseGoodsRequest </summary>
		public static int PurchaseGoodsRequest = 141;

		/// <summary> PurchaseGoodsResponse </summary>
		public static int PurchaseGoodsResponse = 142;

		/// <summary> ReplaceNickNameRequest </summary>
		public static int ReplaceNickNameRequest = 146;

		/// <summary> ReplaceNickNameResponse </summary>
		public static int ReplaceNickNameResponse = 147;

		/// <summary> ReplaceHeadUrlRequest </summary>
		public static int ReplaceHeadUrlRequest = 148;

		/// <summary> ReplaceHeadUrlResponse </summary>
		public static int ReplaceHeadUrlResponse = 149;

		/// <summary> StrengthSyncRequest </summary>
		public static int StrengthSyncRequest = 151;

		/// <summary> StrengthSyncResponse </summary>
		public static int StrengthSyncResponse = 152;

		/// <summary> RepairBoxRequest </summary>
		public static int RepairBoxRequest = 153;

		/// <summary> RepairBoxResponse </summary>
		public static int RepairBoxResponse = 154;

		/// <summary> GMChangeAssetRequest </summary>
		public static int GMChangeAssetRequest = 9000000;

		/// <summary> GMChangeAssetResponse </summary>
		public static int GMChangeAssetResponse = 9000001;

		/// <summary> GMUnlockMapRequest </summary>
		public static int GMUnlockMapRequest = 9000002;

		/// <summary> GMUnlockMapResponse </summary>
		public static int GMUnlockMapResponse = 9000003;

		/// <summary> GMAddCollectionLvRequest </summary>
		public static int GMAddCollectionLvRequest = 9000004;

		/// <summary> GMAddCollectionLvResponse </summary>
		public static int GMAddCollectionLvResponse = 9000005;

		/// <summary> GMShowcaseAddExpRequest </summary>
		public static int GMShowcaseAddExpRequest = 9000006;

		/// <summary> GMShowcaseAddExpResponse </summary>
		public static int GMShowcaseAddExpResponse = 9000007;

		/// <summary> GMVisitorAddExpRequest </summary>
		public static int GMVisitorAddExpRequest = 9000008;

		/// <summary> GMVisitorAddExpResponse </summary>
		public static int GMVisitorAddExpResponse = 9000009;

		/// <summary> GMUnlockHandbookRequest </summary>
		public static int GMUnlockHandbookRequest = 9000010;

		/// <summary> GMUnlockHandbookResponse </summary>
		public static int GMUnlockHandbookResponse = 9000011;

		/// <summary> GMUnlockMuseumAreaRequest </summary>
		public static int GMUnlockMuseumAreaRequest = 9000012;

		/// <summary> GMUnlockMuseumAreaResponse </summary>
		public static int GMUnlockMuseumAreaResponse = 9000013;

		/// <summary> GmFinishMissionRequest </summary>
		public static int GmFinishMissionRequest = 9000014;

		/// <summary> GmFinishMissionResponse </summary>
		public static int GmFinishMissionResponse = 9000015;

		/// <summary> GMUnlockResearchRequest </summary>
		public static int GMUnlockResearchRequest = 9000016;

		/// <summary> GMUnlockResearchResponse </summary>
		public static int GMUnlockResearchResponse = 9000017;

		/// <summary> GMUnlockAllHandbookRequest </summary>
		public static int GMUnlockAllHandbookRequest = 9000018;

		/// <summary> GMUnlockAllHandbookResponse </summary>
		public static int GMUnlockAllHandbookResponse = 9000019;

		/// <summary> GMSkipMissionByIdRequest </summary>
		public static int GMSkipMissionByIdRequest = 9000020;

		/// <summary> GMSkipMissionByIdResponse </summary>
		public static int GMSkipMissionByIdResponse = 9000021;


	}

}

