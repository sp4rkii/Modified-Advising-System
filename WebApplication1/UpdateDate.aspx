<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateDate.aspx.cs" Inherits="Admin.UpdateDate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   <style>
        body {
            margin: 0;
            padding: 0;
            font-family: 'Arial', sans-serif; /* Change the font family as needed */
        }

        .container {
    position: fixed;
    height: 100vh;
    width: 150px;
    background-color: #45b3e7;
    overflow: hidden;
    transition: width 0.3s;
    z-index: 2; /* Set a higher z-index for the container */
}


        .container:hover {
            width: 300px; /* Adjust the expanded width as needed */
        }


        .dropdown {
            width: 100%;
            height: 30px; /* Adjust the height as needed */
            padding: 5px;
            box-sizing: border-box;
            border: none;
            border-radius: 5px;
            margin-bottom: 10px;
            position: relative;
            cursor: pointer;
            text-align:center;
             position: relative;
            
        }

        .buttons {
        display: none;
        position: absolute;
        top: 100%; /* Position below the dropdown */
        left: 0;
        width: 100%;
        background-color: #45b3e7;
        border-radius: 0 0 5px 5px;
        box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        z-index: 1; /* Ensure the dropdown is on top */
        padding-top: 5px; /* Add some padding for separation */
    }

    

    .dropdown:hover .buttons {
            display: block;
    }


        .button {
            width: 100%;
            padding: 8px;
            box-sizing: border-box;
            text-align: left;
            color: #fff;
            text-decoration: none;
            display: block;
            transition: background-color 0.3s;
            text-align:center;
        }

        .button:hover {
            background-color: #1a6ca4;
        }

        .title {
            text-align: center;
            color: #fff;
            font-size: 18px; /* Adjust the font size as needed */
            font-weight: bold;
            padding: 10px 0;
        }
        .submit-style {
  width: 100%;
  padding: 5%;
  -moz-border-radius: 6px;
  -webkit-border-radius: 6px;
  border: 1px solid #45b3e7;
  font-size: 15px;
  background-color: #45b3e7;
  color: #fff;
  margin-top: 25px;
  -webkit-transition: all .2s ease-in-out;
  -moz-transition: all .2s ease-in-out;
  transition: all .2s ease-in-out;
}

.submit-style:hover {
  width: 100%;
  padding: 5%;
  -moz-border-radius: 6px;
  -webkit-border-radius: 6px;
  border: 1px solid #32CD32;
  font-size: 15px;
  background-color: #32CD32;
  color: #fff;
  margin-top: 25px;
  -webkit-transition: all .2s ease-in-out;
  -moz-transition: all .2s ease-in-out;
  transition: all .2s ease-in-out;
}
    
.header {
     background-color:#004225;
    color: #fff;
    padding: 10px;
    text-align: center;
    position: fixed;
    width: 100%;
    height: 50px;
    top: 0;
    display: flex;
    align-items: center;
           left: 0px;
       }

.title2 {
    flex: 1; 
    color: #000;
    text-align: center; 
}
.input-style {
  width: 90%;
  margin-bottom: 10px;
  padding: 5%;
  -moz-border-radius: 6px;
  -webkit-border-radius: 6px;
  border: 1px solid #000;
  font-size: 15px;
  -webkit-transition: all .2s ease-in-out;
  -moz-transition: all .2s ease-in-out;
  transition: all .2s ease-in-out;
}
.input-style:focus {
  outline: none;
  border-color: #9ecaed;
  box-shadow: 0 0 10px #9ecaed;
  -webkit-transition: all .2s ease-in-out;
  -moz-transition: all .2s ease-in-out;
  transition: all .2s ease-in-out;
}

.logo {
    width: auto;
    height: 100%;
    display: flex;
    align-items: center;
    justify-content: flex-start;
}

.logo img {
    max-height: 100%;
    max-width: 100%;
}
.content {
    margin-top: 70px; /* Adjust this value to match the header height */

}
.user-box {
    width: auto;
    padding:10px;
    background-color: #fff;
    border: 1px solid #ccc;
    border-radius:10px;
    box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
    overflow: hidden;
    position: absolute;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
    z-index: 1;
   overflow-y: auto;
}

.user-header {
    position: relative;
    height: 200px;
}

.user-photo {
    position: absolute;
    top: 10px;
    left: 10px;
    width: 80px;
    height: 80px;
    border-radius: 50%;
    z-index: 2; 
}

.background-overlay {
    position: absolute;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%; 
    z-index: 1;
    overflow: hidden;
}
.custom-gridview {
        font-family: Arial, sans-serif;
        border-collapse: separate;
        border-spacing: 0;
        border: 2px solid #ccc; /* Border color /
        border-radius: 15px; / Rounded corners /
        box-shadow: 0px 4px 8px rgba(0, 0, 0, 0.2); / Shadow effect /
        transform: scale(0.9); / Scale down the table /
        margin: auto; / Center horizontally /
        position: absolute; / Positioning /
        top: 50%; / Move table from the top /
        left: 50%; / Move table from the left /
        transform: translate(-50%, -50%); / Centering trick /
    }

    .custom-gridview th,
    .custom-gridview td {
        border: 1px solid #ccc; / Border color for cells */
        padding: 8px;
        text-align: left;
    }

    .custom-gridview th {
        background-color: #f2f2f2;
        color: #333;
    }

    .custom-gridview tr:nth-child(even) {
        background-color: #f9f9f9;
    }

    .custom-gridview tr:hover {
        background-color: #f1f1f1;
    }

.background-img {
    width: 100%;
    height: 100px;
    opacity: 0.3; 
    object-fit: cover;
}
  .info-bar {
    text-align: center;
    color: #666;
    font-size: 15px;
    padding-bottom: 10px; /* Adjust as needed */
  }

  .info-bar a {
    color: #45b3e7;
    text-decoration: none;
  }
  .container {
            background-color:  #004225;
        }

        .buttons-container,
        .btnIssueInstallment,
        input[type="submit"],
        .dropdown .buttons {
            background-color: #00703C  ;
        }

        .btnIssueInstallment:hover,
        input[type="submit"]:hover,
        .button:hover {
            background-color:   #004225;
        }
 body {
    margin: 0;
    padding: 0;
    font-family: 'Arial', sans-serif;
    background-image: url('https://images.unsplash.com/photo-1591123120675-6f7f1aae0e5b?q=80&w=2069&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D');
    background-size: cover; / Adjust this property */
    background-position: center;
    background-repeat: no-repeat;
    height: 100vh;
    overflow: hidden;
    
}
 header{background-color:#004225}
   </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="header">
       <div class="logo">
            <img src="https://images-ext-2.discordapp.net/external/xelmIX6OTFHwn2J73JwP0rv5hfLnEwvakKZZLMGC08c/https/static.wixstatic.com/media/a0f2a3_be80e1eea60346428345ef09f184b64b~mv2.png/v1/crop/x_0%2Cy_55%2Cw_614%2Ch_268/fill/w_412%2Ch_178%2Cal_c%2Cq_85%2Cusm_0.66_1.00_0.01%2Cenc_auto/23687_edited.png?format=webp&quality=lossless" alt="Logo" />
        </div>
        <div class="title2" style="color:white">
            <h1>Advisor Portal - GUC</h1>
        </div>

    </div>
<div class="content">
 <div class="container">
            <div class="title">Advisor Portal</div>
      <div class="dropdown" onclick="toggleDropdown(this)">
   <span class="dropdown-text" style="text-align: center;color: #fff; font-size: 18px; font-weight: bold;">Main Menu</span>
    <div class="buttons">
        <a href="Course.aspx" class="button">DashBoard</a>
    </div>
</div>
            <div class="dropdown" onclick="toggleDropdown(this)">
               <span class="dropdown-text" style="text-align: center;color: #fff; font-size: 18px; font-weight: bold;">View</span>
                <div class="buttons">
                    <a href="ViewStudent.aspx" class="button">My Advising Students</a>
                    <a href="ViewRequests.aspx" class="button">Requests</a>
                    <a href="AssignedStudents.aspx" class="button">Assigned Students</a>
                    <a href="PendingRequests1.aspx" class="button">pending requests</a>
                </div>
            </div>
             <div class="dropdown" onclick="toggleDropdown(this)">
   <span class="dropdown-text" style="text-align: center;color: #fff; font-size: 18px; font-weight: bold;">Graduation Plan</span>
    <div class="buttons">
        <a href="CreateGraduation.aspx" class="button">New Graduation Plan</a>
        <a href="AddCourse.aspx" class="button">Add Courses</a>
        <a href="UpdateDate.aspx" class="button">Update Graduation Date</a>
        <a href="DeleteCourse1.aspx" class="button">Delete Courses</a>
    </div>

</div> 
        <div class="dropdown" onclick="toggleDropdown(this)">
     <span class="dropdown-text" style="text-align: center;color: #fff; font-size: 18px; font-weight: bold;">Requests</span>
      <div class="buttons">
          <a href="ExtraHour.aspx" class="button">Approve/ reject extra credit hours</a>
          <a href="ExtraCredit.aspx" class="button"> Approve/ reject extra courses</a>
      </div>
  </div>     
            <div class="dropdown" onclick="toggleDropdown(this)">
<span class="dropdown-text" style="text-align: center;color: #fff; font-size: 18px; font-weight: bold;">Settings</span>
 <div class="buttons">
     <a href="MainPage.aspx" class="button"> Sign Out</a>
 </div></div>
        </div>
    <div class="user-box" style="top:400px;left:50%"><h3 style="text-align:center">
   Update Expected Graduation Date </h3>  
                        <div class="info-bar">
    Expected Graduation Date
</div>
<asp:TextBox ID="gradDate" runat="server" type="date" CssClass="input-style" required ></asp:TextBox>
            <div class="info-bar">
                         Student ID
            </div>
<asp:TextBox ID="studentid1" runat="server"  CssClass="input-style" required ></asp:TextBox>
        <asp:Literal ID="lblError1" runat="server" ></asp:Literal>
        <asp:Button ID="confirm" runat="server" OnClick="confirmClick" Text="Confirm" CssClass="submit-style" />
         
        <asp:Label ID="lblResult1" runat="server" ForeColor="Green" EnableViewState="False"></asp:Label>
    </div>
   

    </div>
        <script>
            function toggleDropdown(dropdown) {
                dropdown.querySelector('.buttons').classList.toggle('show');
            }

            // Close the dropdown if the user clicks outside of it
            window.onclick = function (event) {
                if (!event.target.matches('.dropdown')) {
                    var dropdowns = document.getElementsByClassName('buttons');
                    for (var i = 0; i < dropdowns.length; i++) {
                        var openDropdown = dropdowns[i];
                        if (openDropdown.classList.contains('show')) {
                            openDropdown.classList.remove('show');
                        }
                    }
                }
            }
        </script>
            
    </form>
</body>
</html>
