/// <summary>
/// 网络事件协议ID
/// </summary>
public enum eProtocalCommand
{
    LOGIN_CMD 				= 1,
    REGISTER_CMD 			= 2,
	LOGIN_HALL_CMD 			= 3,

	CREATE_ROOM_CMD 		= 4,
	JOIN_ROOM_CMD 			= 5,
    ROOM_ENTER_NOTIFY_CMD   = 6;
	ROOM_STATE_CHANGE_CMD 	= 7,

	GAME_DEAL_CARD      	= 8,
	GAME_CARD_SOLUTION  	= 9,
}
