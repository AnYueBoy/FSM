/**
 * 创建者：栾浩元
 * 描述：状态转换条件枚举
 */

public enum Transition 
{
    /// <summary>
    /// 空
    /// </summary>
    NULL,

    /// <summary>
    /// 未发现玩家
    /// </summary>
    NO_SEE_PLAYER,

    /// <summary>
    /// 发现玩家
    /// </summary>
    SEE_PLAYER,

    /// <summary>
    /// 游戏暂停
    /// </summary>
    GAME_PAUSE

}