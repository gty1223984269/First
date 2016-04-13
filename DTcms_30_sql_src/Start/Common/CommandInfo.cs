using MySql.Data.MySqlClient;
using System;
using System.Data.SqlClient;

namespace Start.info
{
    /// <summary>
    /// 事务相关
    /// </summary>
    public enum EffentNextType
    {
        /// <summary>
        /// 对其他语句无任何影响 
        /// </summary>
        None,
        /// <summary>
        /// 当前语句必须为"select count(1) from .."格式，如果存在则继续执行，不存在回滚事务
        /// </summary>
        WhenHaveContine,
        /// <summary>
        /// 当前语句必须为"select count(1) from .."格式，如果不存在则继续执行，存在回滚事务
        /// </summary>
        WhenNoHaveContine,
        /// <summary>
        /// 当前语句影响到的行数必须大于0，否则回滚事务
        /// </summary>
        ExcuteEffectRows,
        /// <summary>
        /// 引发事件-当前语句必须为"select count(1) from .."格式，如果不存在则继续执行，存在回滚事务
        /// </summary>
        SolicitationEvent
    }   
    /// <summary>
    /// 命令信息
    /// </summary>
    public class CommandInfo
    {
       /// <summary>
       /// ShareObject
       /// </summary>
        public object ShareObject = null;
        /// <summary>
        /// OriginalData
        /// </summary>
        public object OriginalData = null;
        /// <summary>
        /// _solicitationEvent
        /// </summary>
        event EventHandler _solicitationEvent;
        /// <summary>
        /// SolicitationEvent
        /// </summary>
        public event EventHandler SolicitationEvent
        {
            add
            {
                _solicitationEvent += value;
            }
            remove
            {
                _solicitationEvent -= value;
            }
        }
        /// <summary>
        /// 开始。。。
        /// </summary>
        public void OnSolicitationEvent()
        {
            if (_solicitationEvent != null)
            {
                _solicitationEvent(this,new EventArgs());
            }
        }
        /// <summary>
        /// 命令语句
        /// </summary>
        public string CommandText;
        /// <summary>
        /// 参数
        /// </summary>
        public System.Data.Common.DbParameter[] Parameters;
        /// <summary>
        /// 定义EffentNextType的类型
        /// </summary>
        public EffentNextType EffentNextType = EffentNextType.None;
        /// <summary>
        /// 构造函数
        /// </summary>
        public CommandInfo()
        {

        }
        /// <summary>
        /// 命令信息
        /// </summary>
        /// <param name="sqlText">语句</param>
        /// <param name="para">参数</param>
        public CommandInfo(string sqlText, SqlParameter[] para)
        {
            this.CommandText = sqlText;
            this.Parameters = para;
        }
        public CommandInfo(string sqlText, MySqlParameter[] para)
        {
            this.CommandText = sqlText;
            this.Parameters = para;
        }
        /// <summary>
        /// 命令信息
        /// </summary>
        /// <param name="sqlText">语句</param>
        /// <param name="para">参数</param>
        /// <param name="type">类型</param>
        public CommandInfo(string sqlText, SqlParameter[] para, EffentNextType type)
        {
            this.CommandText = sqlText;
            this.Parameters = para;
            this.EffentNextType = type;
        }
    }
}
