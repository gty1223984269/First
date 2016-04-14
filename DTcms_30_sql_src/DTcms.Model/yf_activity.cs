using System;
namespace DTcms.Model
{
	/// <summary>
	/// yf_activity:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class yf_activity
	{
		public yf_activity()
		{}
		#region Model
		private int _id;
		private string _title;
		private string _img_url;
		private string _html_url;
		private string _content;
		private string _starttime;
		private string _endtime;
		private string _youraddress;
		private int? _click=0;
		private int? _is_lock=0;
		private string _add_time;
		private string _filed1;
		private string _filed2;
		private string _filed3;
		private string _filed4;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string img_url
		{
			set{ _img_url=value;}
			get{return _img_url;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string html_url
		{
			set{ _html_url=value;}
			get{return _html_url;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string starttime
		{
			set{ _starttime=value;}
			get{return _starttime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string endtime
		{
			set{ _endtime=value;}
			get{return _endtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string youraddress
		{
			set{ _youraddress=value;}
			get{return _youraddress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? click
		{
			set{ _click=value;}
			get{return _click;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? is_lock
		{
			set{ _is_lock=value;}
			get{return _is_lock;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string add_time
		{
			set{ _add_time=value;}
			get{return _add_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string filed1
		{
			set{ _filed1=value;}
			get{return _filed1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string filed2
		{
			set{ _filed2=value;}
			get{return _filed2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string filed3
		{
			set{ _filed3=value;}
			get{return _filed3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string filed4
		{
			set{ _filed4=value;}
			get{return _filed4;}
		}
		#endregion Model

	}
}

