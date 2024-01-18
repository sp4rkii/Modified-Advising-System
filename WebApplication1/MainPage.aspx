<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="Admin.MainPage" %>


<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="UTF-8">
  <title>Main Page</title>
  <style>
    body, html {
      margin: 0;
      padding: 0;
      height: 100%;
      font-family: Arial, sans-serif; 
      background: linear-gradient(to bottom, #0099CC
, #ffffff); 
    }

    .container {
      width: 100%;
      height: 100%;
      display: flex;
      flex-direction: column;
    }

    .content {
      flex: 1;
      display: flex;
      flex-direction: column;
      align-items: center;
      justify-content: center;
      position: relative;
      overflow: hidden;
    }

    .logo {
      width: 200px;
      height: auto;
    }

    .buttons-container {
      width: 100%; 
      background-color: #0099CC
; 
      border-radius: 10px;
      padding: 10px; 
      margin-top: 20px; 
      display: flex;
      justify-content: center;
      align-items: center;
      height: 20px; 
      transition: transform 0.3s, box-shadow 0.3s; 
    }

    .buttons-container:hover {
      transform: translateY(-3px); 
      box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1); 
    }

    .buttons {
      display: flex;
      justify-content: center;
    }

    button {
      padding: 10px 20px;
      font-size: 16px;
      border: none;
      border-radius: 5px;
      cursor: pointer;
      background-color: #0099CC
; 
      color: #fff;
      margin: 0 5px; 
      transition: transform 0.3s, box-shadow 0.3s;
    }

    button:hover {
      transform: translateY(-3px);
      box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1); 
    }    }

  </style>
</head>
<body>
     
  <div class="container">
  <div class="content">
    <div class="logo">
      <img src="https://www.guc.edu.eg/img/guc_logo_og.png" alt="Logo">
    </div>
    <div class="buttons-container">
      <div class="buttons">
        <a href="Login.aspx" class="button-link"><button>Admin</button></a>
        <a href="#" class="button-link"><button>Student</button></a>
        <a href="Login1.aspx" class="button-link">
          <button>Advisor</button>
          </a>

       
      </div>
    </div>
  </div>
</div>

</body>
</html>