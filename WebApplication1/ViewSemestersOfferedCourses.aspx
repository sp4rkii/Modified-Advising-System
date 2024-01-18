<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewSemestersOfferedCourses.aspx.cs" Inherits="Admin.ViewSemestersOfferedCourses" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   <style>
                      body {
    margin: 0;
    padding: 0;
    font-family: 'Arial', sans-serif; /* Change the font family as needed */
    background-image: url('https://images.unsplash.com/20/cambridge.JPG?q=80&w=2047&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D');
    background-size: cover; /* Adjust this property */
    background-position: center;
    background-repeat: no-repeat;
    height: 100vh;
    overflow: hidden;
}

        .container {
    position: fixed;
    height: 100vh;
    width: 150px;
    background-color: darkred;
    overflow: hidden;
    transition: width 0.3s;
    z-index: 2; /* Set a higher z-index for the container */
        display: flex;
        flex-direction: column;
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
  border: 1px solid red;
  font-size: 15px;
  background-color: darkred;
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
  border: 1px solid red;
  font-size: 15px;
  background-color: darkred;
  color: darkred;
  margin-top: 25px;
  -webkit-transition: all .2s ease-in-out;
  -moz-transition: all .2s ease-in-out;
  transition: all .2s ease-in-out;
}
    
.header {
     background-color:#d3d3d3;
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
.container {
            background-color: darkred;
        }

        .buttons-container,
        .btnIssueInstallment,
        input[type="submit"],
        .dropdown .buttons {
            background-color: #610c04 ;
        }

        .btnIssueInstallment:hover,
        input[type="submit"]:hover,
        .button:hover {
            background-color: #d21404 ;
        }

   </style>
</head>
<body>
    <form id="form2" runat="server">
    <div class="header">
       <div class="logo">
            <img src="https://www.guc.edu.eg/img/guc_logo_og.png" alt="Logo" />
        </div>
        <div class="title2">
            <h1>Admin Portal - GUC</h1>
        </div>

        </div>
<div class="content">
 <div class="container">
            <div class="title">Admin Portal</div>
      <div class="dropdown" onclick="toggleDropdown(this)">
   <span class="dropdown-text" style="text-align: center;color: #fff; font-size: 18px; font-weight: bold;">Main Menu</span>
    <div class="buttons">
        <a href="AdminDashBoard.aspx" class="button">DashBoard</a>
    </div>
</div>
            <div class="dropdown" onclick="toggleDropdown(this)">
               <span class="dropdown-text" style="text-align: center;color: #fff; font-size: 18px; font-weight: bold;">View</span>
                <div class="buttons">
                    
                    <a href="ListAdvisors.aspx" class="button">Advisors</a>
                    <a href="ListStudents.aspx" class="button">Students With Advisors</a>
                    <a href="ViewInstructorsAssignedCourses.aspx" class="button">Instructors Assigned Courses</a>
                    <a href="PendingRequests.aspx" class="button">Pending Requests</a>
                    <a href="ViewSemestersOfferedCourses.aspx" class="button">Semesters With Offered Courses</a>
                    <a href="FetchActiveStudents.aspx" class="button">Active Students</a>
                    <a href="ViewGradPlan.aspx" class="button">Graduation plan</a>
                    <a href="ViewStudentTranscript.aspx" class="button">Student Transcript</a>
                    
                    
                </div>
            </div>

     <div class="dropdown" onclick="toggleDropdown(this)">
   <span class="dropdown-text" style="text-align: center;color: #fff; font-size: 18px; font-weight: bold;">Create</span>
    <div class="buttons">
        
        <a href="AddNewSemester.aspx" class="button">Add New Semester</a>
        <a href="AddNewCourse.aspx" class="button">Add New Course</a>
        <a href="AdminAddExam.aspx" class="button">Add Exam</a>
        <a href="AdminInstallment.aspx" class="button">Issue Installment</a>

    </div>
</div>

     <div class="dropdown" onclick="toggleDropdown(this)">
   <span class="dropdown-text" style="text-align: center;color: #fff; font-size: 18px; font-weight: bold;">Link</span>
    <div class="buttons">
        
        <a href="AdminLinkInstructor.aspx" class="button">Instructor To Course</a>
        <a href="LinkStudentToAdvisor.aspx" class="button">Student To Advisor</a>
        <a href="LinkStudentToCourse.aspx" class="button">Student To Course</a>
    </div>
</div>
          <div class="dropdown" onclick="toggleDropdown(this)">
   <span class="dropdown-text" style="text-align: center;color: #fff; font-size: 18px; font-weight: bold;">Delete</span>
    <div class="buttons">
        
        <a href="DeleteCourse.aspx" class="button">Delete Course</a>
        <a href="DeleteSlots.aspx" class="button">Delete Slot</a>
    </div>
</div>

               <div class="dropdown" onclick="toggleDropdown(this)">
   <span class="dropdown-text" style="text-align: center;color: #fff; font-size: 18px; font-weight: bold;">Update</span>
    <div class="buttons">
        
        <a href="AdminUpdateStatus.aspx" class="button">Student Status</a>
        
    </div>
</div>
             

</div>   
        
    </div>
   
    <div class="user-box" style="top:350px;left:50%">
        <h3 style="text-align:center">
           Semesters and Offered Courses </h3>
       
        <asp:GridView ID="GridViewSemesters" runat="server" CssClass="custom-gridview">
   
</asp:GridView>

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