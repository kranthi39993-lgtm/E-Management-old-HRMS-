<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="logincovid.aspx.vb" Inherits="E_Management.logincovid" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >


    <head>
        <meta charset="utf-8"/>
        <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
        <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
        <link rel="icon" href="images/icons/favicon.png"/>
        <title></title>


        <!-- Bootstrap core CSS -->
       <%-- <link href="~Css/bootstrap.min.css" rel="stylesheet"/>--%>
    <link href="Css/bootstrap.min.css" rel="stylesheet" type="text/css" />
        <link href="font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
        <!-- Custom styles for this template -->
        <link href="Css/style.css" rel="stylesheet"/>
        <link href="fonts/antonio-exotic/stylesheet.css" rel="stylesheet"/>
        <link rel="stylesheet" href="Css/lightbox.min.css"/>
        <link href="Css/responsive.css" rel="stylesheet"/>
        <script src="js/jquery.min.js" type="text/javascript"></script>
        <script src="js/bootstrap.min.js" type="text/javascript"></script>
        <script src="js/lightbox-plus-jquery.min.js" type="text/javascript"></script>
        <script src="js/instafeed.min.js" type="text/javascript"></script>
        <script src="js/custom.js" type="text/javascript"></script>


        
  
    </head>
    <body>
     <form id="form2" runat="server">
        <div id="page">
        
          
            <header class="header-container">
                <div class="container">
                    <div class="top-row">
                      
                            <div class="col-md-2 col-sm-6 col-xs-6">
                                <div id="logo">
                                    <!--<a href="home.html"><img src="images/logo.png" alt="logo"></a>-->
                                   <a href="Logincovid.aspx"> <img alt="image" class="img-responsive" src="images/icons/logo.jpg"/></a>
                                
                                   <%-- <a href="index.aspx"> <img alt="image" class="img-responsive" src="../images/icons/logo.jpg"/></a>--%>
                                </div>   
                                </div>
                                  <div class="col-md-2 col-sm-6 col-xs-6">
                                  </div>
                                  
                                   <div class="col-md-2 col-sm-6 col-xs-6">
                                  </div>
                                  
                                
                              <%--  <div class="col-md-2 col-sm-6 col-xs-6">
                                 <label  class="col-form-label">UserName:</label> 
                               <asp:TextBox  class="form-control" runat="server"  Text="" id="TxtUserId"></asp:TextBox>
                                
                                 
                                                   
                                                    
                            </div>
                             <div class="col-md-2 col-sm-6 col-xs-6">
                                      <label  class="col-form-label">Password:</label>            
                                 <asp:TextBox id="TxtPwd" TextMode="Password" Text=""   class="form-control" runat="server" ></asp:TextBox>                    
                           
                            </div>
                                                      <div class="col-md-2 col-sm-6 col-xs-6">
                                                          <label  class="col-form-label" runat="server" visible="false">Password:</label>   
                               <asp:Button id="BtnLogin"  runat="server" OnClick="BtnLogin_Click"  class="book-now-btn1"  style="padding-top:10px"  text="Login" ></asp:Button>
                            </div>--%>
                      
                </div>
                  </div>
            </header>
<br/>
            
            
       

            <!--end-->
     <%--   <div id="myCarousel1" class="carousel slide" data-ride="carousel"> 
                <!-- Indicators -->

                <ol class="carousel-indicators">
                    <li data-target="#myCarousel1" data-slide-to="0" class="active"></li>
                    <li data-target="#myCarousel1" data-slide-to="1"></li>
                    <li data-target="#myCarousel1" data-slide-to="2"></li>
                </ol>
                <div class="carousel-inner">
                    <div class="item active"> <img src="../images/banner.png" style="width:100%; height: 250px" alt="First slide">
                        <div class="carousel-caption">
                            <h1>Maruwa<br> Malaysia Sdn Bhd</h1>
                        </div>
                    </div>
                    <div class="item"> <img src="../images/banner2.png" style="width:100%; height: 250px" alt="Second slide">
                        <div class="carousel-caption">
                            <h1>Maruwa<br> Malaysia Sdn Bhd</h1>
                        </div>
                    </div>
                    <div class="item"> <img src="../images/banner3.png" style="width:100%; height: 250px" alt="Third slide">
                        <div class="carousel-caption">
                            <h1>Maruwa<br> Malaysia Sdn Bhd</h1>
                        </div>
                    </div>

                </div>
                <a class="left carousel-control" href="#myCarousel1" data-slide="prev"> <img src="../images/icons/left-arrow.png" onmouseover="this.src = '../images/icons/left-arrow-hover.png'" onmouseout="this.src = '../images/icons/left-arrow.png'" alt="left"/></a>
                <a class="right carousel-control" href="#myCarousel1" data-slide="next"><img src="../images/icons/right-arrow.png" onmouseover="this.src = '../images/icons/right-arrow-hover.png'" onmouseout="this.src = '../images/icons/right-arrow.png'" alt="left"/></a>

            </div>--%>
        

        
       <div class="row"  >                            <div class="col-md-4 col-sm-4 col-xs-4" style="left: 0px; top: 0px">                            </div>                           <div class="col-md-4 col-sm-4 col-xs-4">                <div class="md-form mb-5">            <label  class="col-form-label" style="width: 310px; text-align: center">
    <span style="font-size: 24pt">
        <br />
        <span style="font-size: 16pt">&nbsp; 
            <img alt="image" class="img-responsive" src="images/icons/logo.jpg" />
            &nbsp;&nbsp;&nbsp;
            <br />
            LOGIN<br />
        </span></span>
</label>
    <br />
    <label  class="col-form-label">UserID:</label>           <asp:TextBox  class="form-control" runat="server"  Text="" id="TxtUserId"></asp:TextBox>          </div>          <div class="md-form mb-5">            <label  class="col-form-label">Password:</label>            <asp:TextBox id="TxtPwd" TextMode="Password" Text=""   class="form-control" runat="server" ></asp:TextBox>          </div>                       <div class="md-form mb-5">           <asp:Label id="LblMsg" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>          </div>                   <div class="md-form mb-5" >        <%--<button type="button" class="btn btn-secondary" data-dismiss="modal">C</button>--%>        <asp:Button id="BtnLogin"  runat="server" OnClick="BtnLogin_Click"  class="book-now-btn1"   text="Login"  ></asp:Button>        <asp:Button id="Button2" runat="server"  class="book-now-btn1"  text="Cancel" ></asp:Button>            </div>              </div>           <div class="col-md-4 col-sm-4 col-xs-4">              </div>            
 </div>
          
            
     
	
            <!---footer--->
            <footer>
                <div class="container">
                  <%--  <div class="row">
                      <%--  <div class="col-md-3 col-sm-6 col-xs-12 width-set-50">
                            <div class="footer-details">
                                <h4>Get in touch</h4>
                                <ul class="list-unstyled footer-contact-list">
                                    <li>
                                        <i class="fa fa-map-marker fa-lg"></i>
                                        <p>Lot 2,3,4,27,28,30 & 31, <br> Batu Berendam FTZ,</p>
										<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Phase 3, Industrial Estate,,</p>
                                    </li>
                                    <li>
                                        <i class="fa fa-phone fa-lg"></i>
                                        <p><a href="tel:+601116666543"> +601116666543</a></p>
                                    </li>
                                    <li>
                                        <i class="fa fa-envelope-o fa-lg"></i>
                                        <p><a href="mailto:hr@maruwa.com.my"> hr@maruwa.com.my</a></p>
                                    </li>
                                </ul>
                              
                            </div>
                        </div>--%>
               <%--         <div class="col-md-3 col-sm-6 col-xs-12 width-50 width-set-50">
                            <div class="footer-details">
                                <h4>explore</h4>
                                <ul class="list-unstyled footer-links">
                                    <li class="active"><a>Home</a></li>
                                   
                                   <%-- <li><a id="A5" runat="server" onserverclick="LinkButton1_Click" >Leave Application</a></li>
                                    <li><a id="A6" runat="server" onserverclick="LinkButton2_Click" >Gate Pass</a></li>
                                    <li><a id="A7" runat="server" onserverclick="LinkButton3_Click" >Clinic Pass</a></li>
                                 
                                </ul>
                            </div>
                        </div>--%>
                      <%--  <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="footer-details">
                                <h4>Manuals</h4>
                                <div class="row">
                                    <ul class="list-unstyled footer-links">
                                    <li class="active"><a  href="mhtml:http://mmsbsql1/form/it/safety/Employee_Handbook.mht!employee_handbook_files/frame.htm">Employee Handbook (English)</a></li>
                                    <li><a href="mhtml:http://mmsbsql1/form/it/safety/Employee_Handbook_M.mht!employee_handbook_M_files/frame.htm">Employee Handbook (Malay)</a></li>
                                    <li><a href="mhtml:http://mmsbsql1/form/it/safety/Safety_Handbook.mht!safety_handbook_files/frame.htm">Safety Handbook (English)</a></li>
                                    <li><a href="mhtml:http://mmsbsql1/form/it/safety/Safety_Handbook_M.mht!employee_handbook_files/frame.htm">Safety Handbook (Malay)</a></li>                                    
                                </ul>
                                </div>
                            </div>
                        </div>--%>

                    <div class="copyright">                    
                        &copy; 2018 All right reserved. Designed by <a href="http://www.maruwa.com.my/" target="_blank">Maruwa Malaysia Sdn Bhd</a>
                    </div>

                </div>
            </footer>

            
           
        </div>
             
        
        
  
        
     
        
       </form>  
        
    </body>
    
    
    
      


</html>