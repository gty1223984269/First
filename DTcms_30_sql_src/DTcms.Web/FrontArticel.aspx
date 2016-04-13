<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrontArticel.aspx.cs" Inherits="DTcms.Web.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   <%-- <title></title>--%>
 <%--   <meta charset="utf-8"/>--%>
  <%--<script src="js/jQuery.1.8.2.min.js"></script>--%>
    <script src="jiaoyanstyle/js/jQuery.1.8.2.min.js"></script>
  <%--<script src="jiaoyanstyle/js/slider.js"></script>--%>
    <script src="jiaoyanstyle/js/slider.js"></script>
<script type="text/javascript">
    $(function () {
        $('.flexslider').flexslider({
            animation: "slide"
        });
        $("#g1").click(function () {
            var id = $(".Navigation span:eq(0)").text();
            alert(id);
        });
        $("#g2").click(function () {
            var id = $(".Navigation span:eq(1)").text();
            alert(id);

        });
        $("#g3").click(function () {

            var id = $(".Navigation span:eq(2)").text();
            alert(id);

        });

    });
  </script>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <title>灵宝教育</title>
    <link href="jiaoyanstyle/css/global.css" rel="stylesheet" />
    <link href="jiaoyanstyle/css/layout.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="jiaoyanstyle/css/global.css"/>
    <link rel="stylesheet" type="text/css" href="jiaoyanstyle/css/layout.css"/>
    <style type="text/css">
       .Navigation{
        list-style:none;
        float:left;
        margin-left:10px;
        }
        ul {
          
        }
        li {
            
        }
        .jiaoyanchengguo {
           margin-top:200px;
           height:400px;
           width :400px;
        }
        #ul3{
    margin-left:300px;
    width:300px;
                }
        #ul4{
    margin-left:300px;
     width:300px;
                }
          #ul5{
    margin-left:600px;
     width:300px;
                }
        #ul6{
    margin-left:600px;
     width:300px;
                }
    </style>
   <%-- <script type="text/javascript">
        $(document).ready(function() {

            function GetId(){
                var id = $("#1").html();
                return id;
            
            };

          
        });
      


    </script>--%>
   
</head>
<body>
    <!--顶部-->
<div class="topbar-wrap">
    <div class="w">
        <div class="topbar-l fl">
            <div class="welcome">基础教育教学研究室主办</div>
        </div>
        <div class="topbar-r fr">
            <a href="">登录</a><a href="">帮助</a>
        </div>
        <span class="clr"></span>
    </div>
</div>
<!--顶部end-->
<!--头部-->
<div class="header-wrap">
    <div class="w header">
        <h1 class="logo"><img src="jiaoyanstyle/jiaoyanimages/logo.png" alt="灵宝教育"> </h1>
        <div class="search-box">
            <input type="text" class="text"><input type="submit" class="submit-btn" value="">
        </div>
</div>
</div>

<!--主导航begin-->
<div class="w nav">
    <ul class="clearfix">
            <li class="cur"><a href="">首    页</a></li>
            <%--<li><a href="">实验成果</a></li>
            <li><a href="">课型例析</a></li>
            <li><a href="">模式探索</a></li>--%>
        <ul><%=GetMenu()%></ul>
        </ul>
</div>
<!--头部end-->

<!--主要内容-->
<div class="content">
    <div class="w">
        <div class="section mt">
            <div class="grid260 fl">
                <div class="slider">
                    <div class="flexslider">
                        <ul class="slides">
                            <li>
                                <div class="img"><img src="jiaoyanstyle/images/01.jpg" width="260" height="260"></div>
                            </li>
                            <li>
                                <div class="img"><img src="jiaoyanstyle/images/01.jpg" width="260" height="260"></div>
                            </li>
                            <li>
                                <div class="img"><img src="jiaoyanstyle/images/01.jpg" width="260" height="260"></div>
                            </li>
                        </ul>
                    </div>
                </div>

            </div>
            <div class="grid450 fl">
                <div class="news-box">
                    <div class="hot-news">
                        <div class="hot-inner">
                            <div class="top-news">
                                <h3><a href="#">高效课堂“导学讲练”教学模式实验成果报告</a></h3>
                                <div class="summary">
                                    构建高效课堂教学模式是一个动态的过程，需要理论与实践相结合，在今后的工作中，我们会以近几年的课改实验为基础，进一步总结经验，不断创新构建更合适的教学模式…… <a class="more" href="#">[查看更多]</a>
                                </div>
                            </div>
                            <div class="news-list">
                                <ul>
                                    <li><span class="school">五亩乡第一初级中学</span><a href="#">构建高效课堂教学模式是</a></li>
                                    <li><span class="school">五亩乡第一初级中学</span><a href="#">构建高效课堂教学模式是</a></li>
                                    <li><span class="school">五亩乡第一初级中学</span><a href="#">构建高效课堂教学模式是</a></li>
                                    <li><span class="school">五亩乡第一初级中学</span><a href="#">构建高效课堂教学模式是</a></li>
                                    <li><span class="school">五亩乡第一初级中学</span><a href="#">构建高效课堂教学模式是</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="grid260 fr">
                <div class="login-box">
                    <h3>用户登录</h3>
                    <div class="bd">
                        <p><input type="text" class="text"></p>

                        <p><input type="password" class="text psw"></p>

                        <p><input type="submit" class="submit-btn"></p>
                    </div>
                </div>
            </div>
            <span class="clr"></span>
        </div>
        <div class="section">
            <div class="grid260 fl">
                <div class="mod">
                    <div class="mod-hd">
                       <%-- <ul id="ul1">--%>

   
   <%--   </ul>--%>
                        <a href="news_list.aspx?category_id=1" class="more" id="g1">更多>></a><h4><li><%=Getcategory("1") %></li>  </h4>
                    </div>
                    <div class="mod-bd">
                        <ul>
                             <%=GetArticel("1")%>
                        </ul>
                    </div>
                </div>
            </div>
            <div class="grid450 fl">
                <div class="mod">
                    <div class="mod-hd">
                        <a href="" class="more" id="g2">更多>></a><h4><li><%=Getcategory("2") %></li>  </h4>
                    </div>
                    <div class="mod-bd">
                           <%=GetArticel("2")%>                    
                    </div>
                </div>
            </div>
            <div class="grid260 fr">
                <div class="mod">
                     <%-- <ul id="ul3">

  
      </ul>--%>
                    <div class="mod-hd">
                       <a href="" class="more" id="g3">更多>></a> <h4><li><%=Getcategory("3") %></li>  </h4>
                    </div>
                    <div class="mod-bd">
                        <ul>
                              <%=GetArticel("3")%>
                        </ul>
                    </div>
                </div>
            </div>
            <span class="clr"></span>
        </div>
    </div>
</div>
<!--尾部-->
<div class="footer-wrap">
	<div class="w footer">
        <p>灵宝市教育体育局 主管</p>
        <p>基础教育教学研究室  主办</p>
    </div>
</div>
<!--尾部end-->
<%--<ul><%=GetMenu()%></ul>
   <div  class="jiaoyanchengguo">

     
       <ul id="ul4">
<li style="list-style:none; font-size:30px;color:red "><%=Getcategory("4") %></li>  
    <%=GetArticel("4")%>
      </ul>
       <ul id="ul5">
<li style="list-style:none; font-size:30px;color:red "><%=Getcategory("5") %></li>  
    <%=GetArticel("5")%>
      </ul>
       <ul id="ul6">
<li style="list-style:none; font-size:30px;color:red "><%=Getcategory("6") %></li>  
    <%=GetArticel("6")%>
      </ul>
    </div>
    
     <div>
        
    </div>--%>
  
</body>
</html>
