<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Course.aspx.cs" Inherits="Admin.Course" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
 <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

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
.button2 {
    max-width: 150px; /* Adjust the max-width as needed */
    white-space: nowrap;
    overflow: hidden;
    text-overflow: ellipsis;
    padding: 8px;
    box-sizing: border-box;
    text-align: left;
    color: #000;
    text-decoration: none;
    display: block;
    transition: background-color 0.3s;
    text-align: center;
}
.button2:hover {
    background-color: #5A5A5A;
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
    background-color: #004225;
    color: #fff;
    padding: 10px;
    text-align: center;
    position: fixed;
    width: 100%;
    height: 50px;
    top: 0;
    display: flex;
    align-items: center;
    justify-content: space-between; /* Add this line */
}

.title2 {
    flex: 1;
    color: #000;
    text-align: center;
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
    width: 400px;
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

.background-img {
    width: 100%;
    height: 100px;
    opacity: 0.3; 
    object-fit: cover;
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
.detail-label {
    font-size: 20px; /* Adjust the font size as needed */
    font-weight: bold;
    text-align: left;
    display: block; /* Treat each element as a block-level element */
    
    padding-top: 5px; /* Add some top padding for spacing */
}

.detail-value {
    border-bottom: 1px solid black; /* Add a black line at the bottom of the element */
    padding-bottom: 5px; /* Add some bottom padding for spacing */
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
    </div>
</div> 

        </div>
    <div class="user-box" style="top:300px;left:40%;" >
        <div class="user-header" >
            <div class="background-overlay">
                <img src="https://www.pomona.edu/sites/default/files/zoom-background-11.jpg" alt="Background Image" class="background-img">
            </div>
            <img src="https://www.pngarts.com/files/10/Default-Profile-Picture-Download-PNG-Image.png" alt="User Photo" class="user-photo">
        </div>
        <div class="user-content">
    <table>
        
        <tr>
            <td class="detail-label"><asp:Literal ID="lblAdvisorId" runat="server"></asp:Literal></td>
            
        </tr>
        <tr>
            <td class="detail-label"><asp:Literal ID="lblAdvisorName" runat="server"></asp:Literal></td>
            
        </tr>
        <tr>
            <td class="detail-label"><asp:Literal ID="lblAdvisorEmail" runat="server"></asp:Literal></td>
            
        </tr>
        <tr>
            <td class="detail-label"><asp:Literal ID="lblAdvisorOffice" runat="server"></asp:Literal></td>
            
        </tr>
        
    </table>
</div>
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




