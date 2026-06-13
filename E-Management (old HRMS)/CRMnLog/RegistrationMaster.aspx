<%@ Page Language="vb" AutoEventWireup="false" Codebehind="RegistrationMaster.aspx.vb" Inherits="E_Management.RegistrationMaster" MasterPageFile="~/ems.Master" Title="Vehicle Registration"  %>

		<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">	
			<table cellpadding="0" cellspacing="0" align="center" width="500">
        <tr>
            <td width="16" style="height: 16px">
                <img height="16" src="../images/top_lef.gif" width="16"  alt=""/></td>
            <td background="../images/top_mid.gif" style="height: 16px">
                <img height="16" src="../images/top_mid.gif" width="16"  alt="" /></td>
            <td style="width: 24px; height: 16px;">
                <img height="16" src="../images/top_rig.gif" width="24"  alt="" /></td>
        </tr>
        <tr>
            <td background="../images/cen_lef.gif"  width="16">
                <img height="11" src=    "../images/cen_lef.gif" width="16"  alt="" /></td>
            <td bgcolor="#ffffff" valign="top">
            <table width="500" >
                    <tr>
                        <td colspan="2" align="center" style="width: 435px">
                            <asp:Panel ID="Panel1" runat="server">
				
		 
				
			 
				
				<table>
					<tr>
						<td style="WIDTH: 644px; HEIGHT: 27px; text-align: center; background-color: #336699;" valign="middle" align="center" colspan="5">
                            <span style="color: white"><strong>Registration Master</strong>&nbsp;</span></td>
					</tr>
					<tr>
						<td style="HEIGHT: 20px; width: 121px; background-color: beige;">
                            <span style="font-size: 11pt">Register :</span></td>
						<td style="WIDTH: 769px; HEIGHT: 25px" valign="middle" align="left" colspan="8" rowspan="1"><asp:radiobuttonlist id="rblType" runat="server" Width="382px" Height="38px" AutoPostBack="True" RepeatDirection="Horizontal">
								<asp:ListItem Value="Flight">Air</asp:ListItem>
								<asp:ListItem Value="Vessel">Sea</asp:ListItem>
								<asp:ListItem Value="Truck">Truck</asp:ListItem>
                            <asp:ListItem>Courier</asp:ListItem>
							</asp:radiobuttonlist></td>
					</tr>
					<tr>
						<td style="WIDTH: 121px; HEIGHT: 20px; background-color: beige;"><asp:label id="lblname" Width="100px" Height="15px" CssClass="lbldesign" Runat="server">Airways Name</asp:label></td>
						<td style="WIDTH: 154px; HEIGHT: 35px"><asp:dropdownlist id="ddlname" runat="server" Width="160px" AutoPostBack="True"></asp:dropdownlist></td>
						<td style="WIDTH: 147px; HEIGHT: 20px; text-align: left; background-color: beige;"><asp:label id="lblnamenew" Width="99px" Height="15px" CssClass="lbldesign" Runat="server">Airways Name</asp:label></td>
						<td style="WIDTH: 263px; HEIGHT: 35px; text-align: left;"><asp:textbox id="txtnamenew" Width="140px" Runat="server"></asp:textbox></td>
					</tr>
					<tr>
						<td style="WIDTH: 121px; HEIGHT: 20px; background-color: beige;"><asp:label id="lblno" Width="100px" Height="15px" CssClass="lbldesign" Runat="server">Flight No</asp:label></td>
						<td style="WIDTH: 154px; HEIGHT: 27px"><asp:dropdownlist id="ddlno" runat="server" Width="160px" ForeColor="#404040" AutoPostBack="True"></asp:dropdownlist></td>
						<td style="WIDTH: 147px; HEIGHT: 20px; text-align: left; background-color: beige;"><asp:label id="lblnonew" Width="71px" Height="15px" CssClass="lbldesign" Runat="server">Flight No</asp:label></td>
						<td style="WIDTH: 263px; HEIGHT: 27px; text-align: left;"><asp:textbox id="txtnonew" Width="140px" Runat="server"></asp:textbox></td>
					</tr>
					<tr>
						<td style="WIDTH: 121px; HEIGHT: 20px; background-color: beige;"><asp:label id="lbldescriptname" Width="100px" CssClass="lbldesign" Runat="server">Flight Name</asp:label></td>
						<td style="WIDTH: 154px; HEIGHT: 22px"><asp:textbox id="txtDescriptName" Width="160px" Runat="server"></asp:textbox></td>
						<td style="WIDTH: 147px; HEIGHT: 20px; background-color: beige; text-align: left;"></td>
						<td style="WIDTH: 263px; HEIGHT: 22px"></td>
					</tr>
					<tr>
						<td style="WIDTH: 121px; HEIGHT: 20px; background-color: beige;"><asp:label id="lblFrom" Width="118px" CssClass="lbldesign" Runat="server">Departure Place</asp:label></td>
						<td style="WIDTH: 154px; HEIGHT: 21px; text-align: left;"><asp:textbox id="txtfrom" Width="160px" Runat="server"></asp:textbox></td>
						<td style="WIDTH: 147px; HEIGHT: 20px; text-align: left; background-color: beige;"><asp:label id="lblTo" Width="99px" CssClass="lbldesign" Runat="server">Arrival Place</asp:label></td>
						<td style="WIDTH: 263px; HEIGHT: 36px; text-align: left;"><asp:textbox id="txtTo" Width="140px" Runat="server"></asp:textbox></td>
					</tr>
					<tr>
						<td style="WIDTH: 121px; HEIGHT: 20px; background-color: beige; text-align: right;"><asp:label id="lblDepTime" Width="98px" CssClass="lbldesign" Runat="server">Departure Time</asp:label>
                            &nbsp; <asp:label id="Label5" runat="server" Width="80px" CssClass="lbldesign">Hour         :        Min</asp:label></td>
						<td style="WIDTH: 154px; HEIGHT: 21px; text-align: left;"><asp:dropdownlist id="ddlDepHour" tabIndex="7" runat="server">
								<asp:ListItem Value="01">01</asp:ListItem>
								<asp:ListItem Value="02">02</asp:ListItem>
								<asp:ListItem Value="03">03</asp:ListItem>
								<asp:ListItem Value="04">04</asp:ListItem>
								<asp:ListItem Value="05">05</asp:ListItem>
								<asp:ListItem Value="06">06</asp:ListItem>
								<asp:ListItem Value="07">07</asp:ListItem>
								<asp:ListItem Value="08">08</asp:ListItem>
								<asp:ListItem Value="09">09</asp:ListItem>
								<asp:ListItem Value="10">10</asp:ListItem>
								<asp:ListItem Value="11">11</asp:ListItem>
								<asp:ListItem Value="12">12</asp:ListItem>
								<asp:ListItem Value="13">13</asp:ListItem>
								<asp:ListItem Value="14">14</asp:ListItem>
								<asp:ListItem Value="15">15</asp:ListItem>
								<asp:ListItem Value="16">16</asp:ListItem>
								<asp:ListItem Value="17">17</asp:ListItem>
								<asp:ListItem Value="18">18</asp:ListItem>
								<asp:ListItem Value="19">19</asp:ListItem>
								<asp:ListItem Value="20">20</asp:ListItem>
								<asp:ListItem Value="21">21</asp:ListItem>
								<asp:ListItem Value="22">22</asp:ListItem>
								<asp:ListItem Value="23">23</asp:ListItem>
								<asp:ListItem Value="24">24</asp:ListItem>
							</asp:dropdownlist>&nbsp;<asp:dropdownlist id="ddlDepMin" tabIndex="8" runat="server">
								<asp:ListItem Value="01">00</asp:ListItem>
								<asp:ListItem Value="01">01</asp:ListItem>
								<asp:ListItem Value="02">02</asp:ListItem>
								<asp:ListItem Value="03">03</asp:ListItem>
								<asp:ListItem Value="04">04</asp:ListItem>
								<asp:ListItem Value="05">05</asp:ListItem>
								<asp:ListItem Value="06">06</asp:ListItem>
								<asp:ListItem Value="07">07</asp:ListItem>
								<asp:ListItem Value="08">08</asp:ListItem>
								<asp:ListItem Value="09">09</asp:ListItem>
								<asp:ListItem Value="10">10</asp:ListItem>
								<asp:ListItem Value="11">11</asp:ListItem>
								<asp:ListItem Value="12">12</asp:ListItem>
								<asp:ListItem Value="13">13</asp:ListItem>
								<asp:ListItem Value="14">14</asp:ListItem>
								<asp:ListItem Value="15">15</asp:ListItem>
								<asp:ListItem Value="16">16</asp:ListItem>
								<asp:ListItem Value="17">17</asp:ListItem>
								<asp:ListItem Value="18">18</asp:ListItem>
								<asp:ListItem Value="19">19</asp:ListItem>
								<asp:ListItem Value="20">20</asp:ListItem>
								<asp:ListItem Value="21">21</asp:ListItem>
								<asp:ListItem Value="22">22</asp:ListItem>
								<asp:ListItem Value="23">23</asp:ListItem>
								<asp:ListItem Value="24">24</asp:ListItem>
								<asp:ListItem Value="25">25</asp:ListItem>
								<asp:ListItem Value="26">26</asp:ListItem>
								<asp:ListItem Value="27">27</asp:ListItem>
								<asp:ListItem Value="28">28</asp:ListItem>
								<asp:ListItem Value="29">29</asp:ListItem>
								<asp:ListItem Value="30">30</asp:ListItem>
								<asp:ListItem Value="31">31</asp:ListItem>
								<asp:ListItem Value="32">32</asp:ListItem>
								<asp:ListItem Value="33">33</asp:ListItem>
								<asp:ListItem Value="34">34</asp:ListItem>
								<asp:ListItem Value="35">35</asp:ListItem>
								<asp:ListItem Value="36">36</asp:ListItem>
								<asp:ListItem Value="37">37</asp:ListItem>
								<asp:ListItem Value="38">38</asp:ListItem>
								<asp:ListItem Value="39">39</asp:ListItem>
								<asp:ListItem Value="40">40</asp:ListItem>
								<asp:ListItem Value="41">41</asp:ListItem>
								<asp:ListItem Value="42">42</asp:ListItem>
								<asp:ListItem Value="43">43</asp:ListItem>
								<asp:ListItem Value="44">44</asp:ListItem>
								<asp:ListItem Value="45">45</asp:ListItem>
								<asp:ListItem Value="46">46</asp:ListItem>
								<asp:ListItem Value="47">47</asp:ListItem>
								<asp:ListItem Value="48">48</asp:ListItem>
								<asp:ListItem Value="49">49</asp:ListItem>
								<asp:ListItem Value="50">50</asp:ListItem>
								<asp:ListItem Value="51">51</asp:ListItem>
								<asp:ListItem Value="52">52</asp:ListItem>
								<asp:ListItem Value="53">53</asp:ListItem>
								<asp:ListItem Value="54">54</asp:ListItem>
								<asp:ListItem Value="55">55</asp:ListItem>
								<asp:ListItem Value="56">56</asp:ListItem>
								<asp:ListItem Value="57">57</asp:ListItem>
								<asp:ListItem Value="58">58</asp:ListItem>
								<asp:ListItem Value="59">59</asp:ListItem>
							</asp:dropdownlist>&nbsp;&nbsp; &nbsp; &nbsp;</td>
						<td style="WIDTH: 147px; HEIGHT: 21px; text-align: right; background-color: beige;">
                            &nbsp;<asp:label id="lblArrTime" Width="84px" CssClass="lbldesign" Runat="server">Arrival Time</asp:label>
                            &nbsp; <asp:label id="Label4" runat="server" Width="72px" CssClass="lbldesign">Hour         :        Min</asp:label></td>
						<td style="WIDTH: 263px; HEIGHT: 20px; text-align: left;">
							<asp:dropdownlist id="ddlArrHour" tabIndex="7" runat="server">
									<asp:ListItem Value="01">01</asp:ListItem>
									<asp:ListItem Value="02">02</asp:ListItem>
									<asp:ListItem Value="03">03</asp:ListItem>
									<asp:ListItem Value="04">04</asp:ListItem>
									<asp:ListItem Value="05">05</asp:ListItem>
									<asp:ListItem Value="06">06</asp:ListItem>
									<asp:ListItem Value="07">07</asp:ListItem>
									<asp:ListItem Value="08">08</asp:ListItem>
									<asp:ListItem Value="09">09</asp:ListItem>
									<asp:ListItem Value="10">10</asp:ListItem>
									<asp:ListItem Value="11">11</asp:ListItem>
									<asp:ListItem Value="12">12</asp:ListItem>
									<asp:ListItem Value="13">13</asp:ListItem>
									<asp:ListItem Value="14">14</asp:ListItem>
									<asp:ListItem Value="15">15</asp:ListItem>
									<asp:ListItem Value="16">16</asp:ListItem>
									<asp:ListItem Value="17">17</asp:ListItem>
									<asp:ListItem Value="18">18</asp:ListItem>
									<asp:ListItem Value="19">19</asp:ListItem>
									<asp:ListItem Value="20">20</asp:ListItem>
									<asp:ListItem Value="21">21</asp:ListItem>
									<asp:ListItem Value="22">22</asp:ListItem>
									<asp:ListItem Value="23">23</asp:ListItem>
									<asp:ListItem Value="24">24</asp:ListItem>
								</asp:dropdownlist>
                            <asp:dropdownlist id="ddlArrMin" tabIndex="8" runat="server">
									<asp:ListItem Value="01">00</asp:ListItem>
									<asp:ListItem Value="01">01</asp:ListItem>
									<asp:ListItem Value="02">02</asp:ListItem>
									<asp:ListItem Value="03">03</asp:ListItem>
									<asp:ListItem Value="04">04</asp:ListItem>
									<asp:ListItem Value="05">05</asp:ListItem>
									<asp:ListItem Value="06">06</asp:ListItem>
									<asp:ListItem Value="07">07</asp:ListItem>
									<asp:ListItem Value="08">08</asp:ListItem>
									<asp:ListItem Value="09">09</asp:ListItem>
									<asp:ListItem Value="10">10</asp:ListItem>
									<asp:ListItem Value="11">11</asp:ListItem>
									<asp:ListItem Value="12">12</asp:ListItem>
									<asp:ListItem Value="13">13</asp:ListItem>
									<asp:ListItem Value="14">14</asp:ListItem>
									<asp:ListItem Value="15">15</asp:ListItem>
									<asp:ListItem Value="16">16</asp:ListItem>
									<asp:ListItem Value="17">17</asp:ListItem>
									<asp:ListItem Value="18">18</asp:ListItem>
									<asp:ListItem Value="19">19</asp:ListItem>
									<asp:ListItem Value="20">20</asp:ListItem>
									<asp:ListItem Value="21">21</asp:ListItem>
									<asp:ListItem Value="22">22</asp:ListItem>
									<asp:ListItem Value="23">23</asp:ListItem>
									<asp:ListItem Value="24">24</asp:ListItem>
									<asp:ListItem Value="25">25</asp:ListItem>
									<asp:ListItem Value="26">26</asp:ListItem>
									<asp:ListItem Value="27">27</asp:ListItem>
									<asp:ListItem Value="28">28</asp:ListItem>
									<asp:ListItem Value="29">29</asp:ListItem>
									<asp:ListItem Value="30">30</asp:ListItem>
									<asp:ListItem Value="31">31</asp:ListItem>
									<asp:ListItem Value="32">32</asp:ListItem>
									<asp:ListItem Value="33">33</asp:ListItem>
									<asp:ListItem Value="34">34</asp:ListItem>
									<asp:ListItem Value="35">35</asp:ListItem>
									<asp:ListItem Value="36">36</asp:ListItem>
									<asp:ListItem Value="37">37</asp:ListItem>
									<asp:ListItem Value="38">38</asp:ListItem>
									<asp:ListItem Value="39">39</asp:ListItem>
									<asp:ListItem Value="40">40</asp:ListItem>
									<asp:ListItem Value="41">41</asp:ListItem>
									<asp:ListItem Value="42">42</asp:ListItem>
									<asp:ListItem Value="43">43</asp:ListItem>
									<asp:ListItem Value="44">44</asp:ListItem>
									<asp:ListItem Value="45">45</asp:ListItem>
									<asp:ListItem Value="46">46</asp:ListItem>
									<asp:ListItem Value="47">47</asp:ListItem>
									<asp:ListItem Value="48">48</asp:ListItem>
									<asp:ListItem Value="49">49</asp:ListItem>
									<asp:ListItem Value="50">50</asp:ListItem>
									<asp:ListItem Value="51">51</asp:ListItem>
									<asp:ListItem Value="52">52</asp:ListItem>
									<asp:ListItem Value="53">53</asp:ListItem>
									<asp:ListItem Value="54">54</asp:ListItem>
									<asp:ListItem Value="55">55</asp:ListItem>
									<asp:ListItem Value="56">56</asp:ListItem>
									<asp:ListItem Value="57">57</asp:ListItem>
									<asp:ListItem Value="58">58</asp:ListItem>
									<asp:ListItem Value="59">59</asp:ListItem>
								</asp:dropdownlist></td>
					</tr>
					<tr>
                        <td align="left" bgcolor="#87cefa" colspan="8" nowrap="nowrap" style="height: 25px;
                            background-color: #336699; text-align: center" valign="middle">
                            <span style="color: #ffffff">&nbsp; (VIA - Optional)</span></td>
					</tr>
					<tr>
						<td style="WIDTH: 331px; HEIGHT: 12px; text-align: right;"></td>
						<td style="WIDTH: 331px; HEIGHT: 12px; text-align: center;" colspan="2">
                            <asp:label id="lblVia" Width="101px" CssClass="lbldesign" Runat="server">Transit Location</asp:label>
                            <asp:textbox id="txtvialoc" Width="167px" Runat="server"></asp:textbox>
                            &nbsp; &nbsp; &nbsp; &nbsp;
                        </td>
						<td style="WIDTH: 331px; HEIGHT: 12px; text-align: right;">
                            &nbsp;</td>
					</tr>
					<tr>
						<td style="WIDTH: 331px; HEIGHT: 22px; background-color: beige; text-align: right;">
                            <asp:label id="Label1" Width="76px" CssClass="lbldesign" Runat="server">Arrival Time</asp:label>
                            &nbsp; 
                            <asp:label id="Label8" runat="server" Width="68px" CssClass="lbldesign">Hour         :        Min</asp:label>
                            </td>
						<td style="WIDTH: 331px; HEIGHT: 22px; text-align: left;">
                            &nbsp;<asp:dropdownlist id="ddlviaHour" tabIndex="7" runat="server">
								<asp:ListItem Value="01">01</asp:ListItem>
								<asp:ListItem Value="02">02</asp:ListItem>
								<asp:ListItem Value="03">03</asp:ListItem>
								<asp:ListItem Value="04">04</asp:ListItem>
								<asp:ListItem Value="05">05</asp:ListItem>
								<asp:ListItem Value="06">06</asp:ListItem>
								<asp:ListItem Value="07">07</asp:ListItem>
								<asp:ListItem Value="08">08</asp:ListItem>
								<asp:ListItem Value="09">09</asp:ListItem>
								<asp:ListItem Value="10">10</asp:ListItem>
								<asp:ListItem Value="11">11</asp:ListItem>
								<asp:ListItem Value="12">12</asp:ListItem>
								<asp:ListItem Value="13">13</asp:ListItem>
								<asp:ListItem Value="14">14</asp:ListItem>
								<asp:ListItem Value="15">15</asp:ListItem>
								<asp:ListItem Value="16">16</asp:ListItem>
								<asp:ListItem Value="17">17</asp:ListItem>
								<asp:ListItem Value="18">18</asp:ListItem>
								<asp:ListItem Value="19">19</asp:ListItem>
								<asp:ListItem Value="20">20</asp:ListItem>
								<asp:ListItem Value="21">21</asp:ListItem>
								<asp:ListItem Value="22">22</asp:ListItem>
								<asp:ListItem Value="23">23</asp:ListItem>
								<asp:ListItem Value="24">24</asp:ListItem>
							</asp:dropdownlist><asp:dropdownlist id="ddlviaMin" tabIndex="8" runat="server">
								<asp:ListItem Value="01">00</asp:ListItem>
								<asp:ListItem Value="01">01</asp:ListItem>
								<asp:ListItem Value="02">02</asp:ListItem>
								<asp:ListItem Value="03">03</asp:ListItem>
								<asp:ListItem Value="04">04</asp:ListItem>
								<asp:ListItem Value="05">05</asp:ListItem>
								<asp:ListItem Value="06">06</asp:ListItem>
								<asp:ListItem Value="07">07</asp:ListItem>
								<asp:ListItem Value="08">08</asp:ListItem>
								<asp:ListItem Value="09">09</asp:ListItem>
								<asp:ListItem Value="10">10</asp:ListItem>
								<asp:ListItem Value="11">11</asp:ListItem>
								<asp:ListItem Value="12">12</asp:ListItem>
								<asp:ListItem Value="13">13</asp:ListItem>
								<asp:ListItem Value="14">14</asp:ListItem>
								<asp:ListItem Value="15">15</asp:ListItem>
								<asp:ListItem Value="16">16</asp:ListItem>
								<asp:ListItem Value="17">17</asp:ListItem>
								<asp:ListItem Value="18">18</asp:ListItem>
								<asp:ListItem Value="19">19</asp:ListItem>
								<asp:ListItem Value="20">20</asp:ListItem>
								<asp:ListItem Value="21">21</asp:ListItem>
								<asp:ListItem Value="22">22</asp:ListItem>
								<asp:ListItem Value="23">23</asp:ListItem>
								<asp:ListItem Value="24">24</asp:ListItem>
								<asp:ListItem Value="25">25</asp:ListItem>
								<asp:ListItem Value="26">26</asp:ListItem>
								<asp:ListItem Value="27">27</asp:ListItem>
								<asp:ListItem Value="28">28</asp:ListItem>
								<asp:ListItem Value="29">29</asp:ListItem>
								<asp:ListItem Value="30">30</asp:ListItem>
								<asp:ListItem Value="31">31</asp:ListItem>
								<asp:ListItem Value="32">32</asp:ListItem>
								<asp:ListItem Value="33">33</asp:ListItem>
								<asp:ListItem Value="34">34</asp:ListItem>
								<asp:ListItem Value="35">35</asp:ListItem>
								<asp:ListItem Value="36">36</asp:ListItem>
								<asp:ListItem Value="37">37</asp:ListItem>
								<asp:ListItem Value="38">38</asp:ListItem>
								<asp:ListItem Value="39">39</asp:ListItem>
								<asp:ListItem Value="40">40</asp:ListItem>
								<asp:ListItem Value="41">41</asp:ListItem>
								<asp:ListItem Value="42">42</asp:ListItem>
								<asp:ListItem Value="43">43</asp:ListItem>
								<asp:ListItem Value="44">44</asp:ListItem>
								<asp:ListItem Value="45">45</asp:ListItem>
								<asp:ListItem Value="46">46</asp:ListItem>
								<asp:ListItem Value="47">47</asp:ListItem>
								<asp:ListItem Value="48">48</asp:ListItem>
								<asp:ListItem Value="49">49</asp:ListItem>
								<asp:ListItem Value="50">50</asp:ListItem>
								<asp:ListItem Value="51">51</asp:ListItem>
								<asp:ListItem Value="52">52</asp:ListItem>
								<asp:ListItem Value="53">53</asp:ListItem>
								<asp:ListItem Value="54">54</asp:ListItem>
								<asp:ListItem Value="55">55</asp:ListItem>
								<asp:ListItem Value="56">56</asp:ListItem>
								<asp:ListItem Value="57">57</asp:ListItem>
								<asp:ListItem Value="58">58</asp:ListItem>
								<asp:ListItem Value="59">59</asp:ListItem>
							</asp:dropdownlist></td>
						<td style="WIDTH: 331px; HEIGHT: 22px; text-align: right; background-color: beige;"><asp:label id="lblviati" Width="100px" CssClass="lbldesign" Runat="server">Departure Time</asp:label>
                            &nbsp; 
                            <asp:label id="lblviahm" runat="server" Width="70px" CssClass="lbldesign">Hour         :        Min</asp:label></td>
						<td style="WIDTH: 331px; HEIGHT: 22px; text-align: left;">
                            <asp:dropdownlist id="ddlViaDHour" tabIndex="7" runat="server">
								<asp:ListItem Value="01">01</asp:ListItem>
								<asp:ListItem Value="02">02</asp:ListItem>
								<asp:ListItem Value="03">03</asp:ListItem>
								<asp:ListItem Value="04">04</asp:ListItem>
								<asp:ListItem Value="05">05</asp:ListItem>
								<asp:ListItem Value="06">06</asp:ListItem>
								<asp:ListItem Value="07">07</asp:ListItem>
								<asp:ListItem Value="08">08</asp:ListItem>
								<asp:ListItem Value="09">09</asp:ListItem>
								<asp:ListItem Value="10">10</asp:ListItem>
								<asp:ListItem Value="11">11</asp:ListItem>
								<asp:ListItem Value="12">12</asp:ListItem>
								<asp:ListItem Value="13">13</asp:ListItem>
								<asp:ListItem Value="14">14</asp:ListItem>
								<asp:ListItem Value="15">15</asp:ListItem>
								<asp:ListItem Value="16">16</asp:ListItem>
								<asp:ListItem Value="17">17</asp:ListItem>
								<asp:ListItem Value="18">18</asp:ListItem>
								<asp:ListItem Value="19">19</asp:ListItem>
								<asp:ListItem Value="20">20</asp:ListItem>
								<asp:ListItem Value="21">21</asp:ListItem>
								<asp:ListItem Value="22">22</asp:ListItem>
								<asp:ListItem Value="23">23</asp:ListItem>
								<asp:ListItem Value="24">24</asp:ListItem>
							</asp:dropdownlist>
                            &nbsp;<asp:dropdownlist id="ddlviaDMin" tabIndex="8" runat="server" AutoPostBack="True">
								<asp:ListItem Value="01">00</asp:ListItem>
								<asp:ListItem Value="01">01</asp:ListItem>
								<asp:ListItem Value="02">02</asp:ListItem>
								<asp:ListItem Value="03">03</asp:ListItem>
								<asp:ListItem Value="04">04</asp:ListItem>
								<asp:ListItem Value="05">05</asp:ListItem>
								<asp:ListItem Value="06">06</asp:ListItem>
								<asp:ListItem Value="07">07</asp:ListItem>
								<asp:ListItem Value="08">08</asp:ListItem>
								<asp:ListItem Value="09">09</asp:ListItem>
								<asp:ListItem Value="10">10</asp:ListItem>
								<asp:ListItem Value="11">11</asp:ListItem>
								<asp:ListItem Value="12">12</asp:ListItem>
								<asp:ListItem Value="13">13</asp:ListItem>
								<asp:ListItem Value="14">14</asp:ListItem>
								<asp:ListItem Value="15">15</asp:ListItem>
								<asp:ListItem Value="16">16</asp:ListItem>
								<asp:ListItem Value="17">17</asp:ListItem>
								<asp:ListItem Value="18">18</asp:ListItem>
								<asp:ListItem Value="19">19</asp:ListItem>
								<asp:ListItem Value="20">20</asp:ListItem>
								<asp:ListItem Value="21">21</asp:ListItem>
								<asp:ListItem Value="22">22</asp:ListItem>
								<asp:ListItem Value="23">23</asp:ListItem>
								<asp:ListItem Value="24">24</asp:ListItem>
								<asp:ListItem Value="25">25</asp:ListItem>
								<asp:ListItem Value="26">26</asp:ListItem>
								<asp:ListItem Value="27">27</asp:ListItem>
								<asp:ListItem Value="28">28</asp:ListItem>
								<asp:ListItem Value="29">29</asp:ListItem>
								<asp:ListItem Value="30">30</asp:ListItem>
								<asp:ListItem Value="31">31</asp:ListItem>
								<asp:ListItem Value="32">32</asp:ListItem>
								<asp:ListItem Value="33">33</asp:ListItem>
								<asp:ListItem Value="34">34</asp:ListItem>
								<asp:ListItem Value="35">35</asp:ListItem>
								<asp:ListItem Value="36">36</asp:ListItem>
								<asp:ListItem Value="37">37</asp:ListItem>
								<asp:ListItem Value="38">38</asp:ListItem>
								<asp:ListItem Value="39">39</asp:ListItem>
								<asp:ListItem Value="40">40</asp:ListItem>
								<asp:ListItem Value="41">41</asp:ListItem>
								<asp:ListItem Value="42">42</asp:ListItem>
								<asp:ListItem Value="43">43</asp:ListItem>
								<asp:ListItem Value="44">44</asp:ListItem>
								<asp:ListItem Value="45">45</asp:ListItem>
								<asp:ListItem Value="46">46</asp:ListItem>
								<asp:ListItem Value="47">47</asp:ListItem>
								<asp:ListItem Value="48">48</asp:ListItem>
								<asp:ListItem Value="49">49</asp:ListItem>
								<asp:ListItem Value="50">50</asp:ListItem>
								<asp:ListItem Value="51">51</asp:ListItem>
								<asp:ListItem Value="52">52</asp:ListItem>
								<asp:ListItem Value="53">53</asp:ListItem>
								<asp:ListItem Value="54">54</asp:ListItem>
								<asp:ListItem Value="55">55</asp:ListItem>
								<asp:ListItem Value="56">56</asp:ListItem>
								<asp:ListItem Value="57">57</asp:ListItem>
								<asp:ListItem Value="58">58</asp:ListItem>
								<asp:ListItem Value="59">59</asp:ListItem>
							</asp:dropdownlist>
                            &nbsp; &nbsp;<asp:button id="btnAddVia" Width="77px" CssClass="btnSubmitStyle" Runat="server" Text="Add Via"
								CausesValidation="False"></asp:button>
                        </td>
					</tr>
                    <tr>
                        <td colspan="4" style="width: 688px;">
                        </td>
                    </tr>
					<tr>
					
						<td style="WIDTH: 688px; HEIGHT: 35px" colspan="4">
								<asp:button id="btnSubmit" Width="80px" CssClass="btnSubmitStyle" Runat="server" Text="Submit" Font-Bold="False" Font-Underline="False"></asp:button>&nbsp;&nbsp;
								<asp:button id="btnclearall" runat="server" Width="74px" Text="Clear All"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;<asp:button id="btnclear" Width="75px" CssClass="btnSubmitStyle" Runat="server" Text="Clear Via"
								CausesValidation="False"></asp:button>&nbsp;&nbsp;
								<asp:button id="btnexit" Width="80px" CssClass="btnSubmitStyle" Runat="server" Text="Exit" CausesValidation="False"></asp:button>
                            &nbsp;&nbsp;
						</td>
					</tr>
                    <tr>
                        <td colspan="4" style="width: 688px;">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" style="width: 688px; height: 35px">
        <asp:datagrid id="VehicleGrid" 
					runat="server" Width="737px" Height="142px" UseAccessibleHeader="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
					<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>
					<Columns>
						<asp:EditCommandColumn UpdateText="Update" HeaderText="Edit" CancelText="Exit"
							EditText="Edit"></asp:EditCommandColumn>
						<asp:ButtonColumn Text="Delete" HeaderText="Delete" CommandName="Delete"></asp:ButtonColumn>
						<asp:BoundColumn DataField="VehicleNo" ReadOnly="True" HeaderText="VehicleNo"></asp:BoundColumn>
						<asp:BoundColumn DataField="TransportName" ReadOnly="True" HeaderText="TransportName"></asp:BoundColumn>
						<asp:BoundColumn DataField="VehicleName" HeaderText="VehicleName"></asp:BoundColumn>
						<asp:BoundColumn DataField="DepartPlace" ReadOnly="True" HeaderText="DepartPlace"></asp:BoundColumn>
						<asp:BoundColumn DataField="ArrivalPlace" ReadOnly="True" HeaderText="ArrivalPlace"></asp:BoundColumn>
						<asp:BoundColumn DataField="DepartTime" HeaderText="DepartTime"></asp:BoundColumn>
						<asp:BoundColumn DataField="ArrivalTime" HeaderText="ArrivalTime"></asp:BoundColumn>
						<asp:BoundColumn DataField="ViaRoute" ReadOnly="True" HeaderText="ViaRoute"></asp:BoundColumn>
						<asp:BoundColumn DataField="ViaArrTime" HeaderText="ViaArrTime"></asp:BoundColumn>
						<asp:BoundColumn DataField="ViaDeptTime" HeaderText="ViaDeptTime"></asp:BoundColumn>
					</Columns>
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditItemStyle BackColor="#2461BF" />
            <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <AlternatingItemStyle BackColor="White" />
            <ItemStyle BackColor="#EFF3FB" />
				</asp:datagrid></td>
                    </tr>
				</table>
				
			
			
				
				</asp:Panel>
                        </td>
                    </tr>
                </table>
                </td>
				  <td background="../images/cen_rig.gif" style="width: 24px">
                <img height="11" src="../images/cen_rig.gif" width="24"  alt="" /></td>
        </tr>
        <tr>
            <td height="16" width="16">
                <img height="16" src="../images/bot_lef.gif" width="16"  alt="" /></td>
            <td background="../images/bot_mid.gif" height="16">
                <img height="16" src="../images/bot_mid.gif" width="16"  alt="" /></td>
            <td height="16" style="width: 24px">
                <img height="16" src="../images/bot_rig.gif" width="24" alt="" /></td>
        </tr>
        
        <tr>
        <td colspan="4">
            &nbsp;</td>
        </tr>
        
    </table>
				<asp:placeholder id="PlaceHolder1" runat="server"></asp:placeholder>
		</asp:Content>