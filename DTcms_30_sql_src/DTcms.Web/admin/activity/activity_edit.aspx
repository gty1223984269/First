<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="activity_edit.aspx.cs" Inherits="DTcms.Web.admin.activity.activity_edit" ValidateRequest="false" %>

<%@ Import Namespace="DTcms.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>编辑广告</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../../scripts/datepicker/WdatePicker.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.queue.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.handlers.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../editor/kindeditor-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../editor/lang/zh_CN.js"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            //初始化表单验证
            $("#form1").initValidform();
            //计算用户组价格
            $("#field_control_sell_price").change(function () {
                var sprice = $(this).val();
                if (sprice > 0) {
                    $(".groupprice").each(function () {
                        var num = $(this).attr("discount") * sprice / 100;
                        $(this).val(ForDight(num, 2));
                    });
                }
            });
            //初始化编辑器
            var editor = KindEditor.create('.editor', {
                width: '98%',
                height: '350px',
                resizeType: 1,
                uploadJson: '../../tools/upload_ajax.ashx?action=EditorFile&IsWater=1',
                fileManagerJson: '../../tools/upload_ajax.ashx?action=ManagerFile',
                allowFileManager: true
            });
            var editorMini = KindEditor.create('.editor-mini', {
                width: '98%',
                height: '250px',
                resizeType: 1,
                uploadJson: '../../tools/upload_ajax.ashx?action=EditorFile&IsWater=1',
                items: [
				'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
				'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
				'insertunorderedlist', '|', 'emoticons', 'image', 'link']
            });
            //初始化上传控件
            $(".upload-img").each(function () {
                $(this).InitSWFUpload({ sendurl: "../../tools/upload_ajax.ashx", flashurl: "../../scripts/swfupload/swfupload.swf" });
            });
            $(".upload-album").each(function () {
                $(this).InitSWFUpload({ btntext: "批量上传", btnwidth: 66, single: false, water: true, thumbnail: true, filesize: "2048", sendurl: "../../tools/upload_ajax.ashx", flashurl: "../../scripts/swfupload/swfupload.swf", filetypes: "*.jpg;*.jpge;*.png;*.gif;" });
            });
            $(".attach-btn").click(function () {
                showAttachDialog();
            });
            //设置封面图片的样式
            $(".photo-list ul li .img-box img").each(function () {
                if ($(this).attr("src") == $("#hidFocusPhoto").val()) {
                    $(this).parent().addClass("selected");
                }
            });
        });
        //创建附件窗口
        function showAttachDialog(obj) {
            var objNum = arguments.length;
            var attachDialog = $.dialog({
                id: 'attachDialogId',
                lock: true,
                max: false,
                min: false,
                title: "上传附件",
                content: 'url:dialog/dialog_attach.aspx',
                width: 500,
                height: 180
            });
            //如果是修改状态，将对象传进去
            if (objNum == 1) {
                attachDialog.data = obj;
            }
        }
    </script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="activity_list.aspx" class="back"><i></i><span>返回列表页</span></a>
            <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>广告管理</span>
            <i class="arrow"></i>
            <span>编辑广告</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->
        <!--内容-->
        <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">基本信息</a></li>
                        <%--<li id="field_tab_item" runat="server" visible="false"><a href="javascript:;" onclick="tabs(this);">扩展选项</a></li>--%>
                    </ul>
                </div>
            </div>
        </div>
        <div class="tab-content">
         
                
            <dl>
                <dt>标题</dt>
                <dd>
                    <asp:TextBox ID="txtTitle" runat="server" CssClass="input normal" datatype="*" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*标题</span></dd>
            </dl>
            <dl>
                <dt>显示状态</dt>
                <dd>
                    <div class="rule-multi-radio">
                    <asp:RadioButtonList ID="rblStatus" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem Value="0" Selected="True">显示</asp:ListItem>
                    <asp:ListItem Value="1">隐藏</asp:ListItem>
                    </asp:RadioButtonList>
                    </div>
                    <span class="Validform_checktip">*隐藏后，将不显示该教程</span>
                </dd>
            </dl>
            <dl>
                <dt>浏览次数</dt>
                <dd>
                    <asp:Label ID="lblClick" Text="0" runat="server"></asp:Label>
                    <span class="Validform_checktip">点击浏览该信息自动+1</span>
                </dd>
            </dl>
            <dl>
                <dt>上传封面图片</dt>
                <dd>
                    <asp:TextBox ID="txtImgUrl" runat="server" locked="true" CssClass="input normal upload-path" datatype="*"></asp:TextBox>
                    <div class="upload-box upload-img"></div>
                    <span class="Validform_checktip">*</span>
                </dd>
            </dl>
            <dl>
                <dt>内容</dt>
                <dd>
                    <textarea id="txtContent" class="editor" style="visibility: hidden;" runat="server"></textarea>
                </dd>
            </dl>
            <dl>
                <dt>添加时间</dt>
                <dd>
                    <asp:Label ID="lblRegTime" Text="-" runat="server"></asp:Label></dd>
            </dl>
        </div>
        <!--/内容-->

        <!--工具栏-->
        <div class="page-footer">
            <div class="btn-list">
                <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" />
                <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
            </div>
            <div class="clear"></div>
        </div>
        <!--/工具栏-->

    </form>
</body>
</html>
