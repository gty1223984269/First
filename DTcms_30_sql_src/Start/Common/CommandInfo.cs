using MySql.Data.MySqlClient;
using System;
using System.Data.SqlClient;

namespace Start.info
{
    /// <summary>
    /// �������
    /// </summary>
    public enum EffentNextType
    {
        /// <summary>
        /// ������������κ�Ӱ�� 
        /// </summary>
        None,
        /// <summary>
        /// ��ǰ������Ϊ"select count(1) from .."��ʽ��������������ִ�У������ڻع�����
        /// </summary>
        WhenHaveContine,
        /// <summary>
        /// ��ǰ������Ϊ"select count(1) from .."��ʽ����������������ִ�У����ڻع�����
        /// </summary>
        WhenNoHaveContine,
        /// <summary>
        /// ��ǰ���Ӱ�쵽�������������0������ع�����
        /// </summary>
        ExcuteEffectRows,
        /// <summary>
        /// �����¼�-��ǰ������Ϊ"select count(1) from .."��ʽ����������������ִ�У����ڻع�����
        /// </summary>
        SolicitationEvent
    }   
    /// <summary>
    /// ������Ϣ
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
        /// ��ʼ������
        /// </summary>
        public void OnSolicitationEvent()
        {
            if (_solicitationEvent != null)
            {
                _solicitationEvent(this,new EventArgs());
            }
        }
        /// <summary>
        /// �������
        /// </summary>
        public string CommandText;
        /// <summary>
        /// ����
        /// </summary>
        public System.Data.Common.DbParameter[] Parameters;
        /// <summary>
        /// ����EffentNextType������
        /// </summary>
        public EffentNextType EffentNextType = EffentNextType.None;
        /// <summary>
        /// ���캯��
        /// </summary>
        public CommandInfo()
        {

        }
        /// <summary>
        /// ������Ϣ
        /// </summary>
        /// <param name="sqlText">���</param>
        /// <param name="para">����</param>
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
        /// ������Ϣ
        /// </summary>
        /// <param name="sqlText">���</param>
        /// <param name="para">����</param>
        /// <param name="type">����</param>
        public CommandInfo(string sqlText, SqlParameter[] para, EffentNextType type)
        {
            this.CommandText = sqlText;
            this.Parameters = para;
            this.EffentNextType = type;
        }
    }
}
