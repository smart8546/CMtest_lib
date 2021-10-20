#CMtest_lib

The Project using Powershell7.1 calling C# dll on Cmtest for factory test.  
The project using  C# Net core 3.1 to build.  
Powershell7.1.3 install step in Powersehll_install files.  

The Project fun is:  
	Fun1 SUM:  
		input int1 plus int2 out Sum_int.  
	Fun2 IsNumber:  
		Input String , Input Split char[] , Out Split String.  
	Fun3 Split_str_Ind:  
		Input String , Input Split char[] ,int count, Out Split count String.  
	Fun4 Split_string:  
		Input String , Input Split char[] ,Out Split String.  
			
	Fun5 UART_list:  
		Print COM PORT list  
	FUN6 Connect:  
		Input Connect device name  
	FUN7 Send:  
		Input Connect device name  , Input send command , output receive  
	FUN8 Disconnect:  
		Input Disonnect device name  
	FUN9 Str_Contains:  
		Input1 and Inpit2 with String, Compare two string not Case,print compare result.  
	FUN10 Str_case_contains:  
		Input1 and Inpit2 with String, Compare two string  Case,print compare result.  
		
		
    Example1:
      $CurrentLocation = Get-Location
      $PSLib = "$CurrentLocation\Cmtest_lib.dll"
      [Reflection.Assembly]::LoadFile($PSLib)       
      [Cmtest_lib.Methods]::Sum(10,2)
    Example2:
      $CurrentLocation = Get-Location
      $PSLib = "$CurrentLocation\Cmtest_lib.dll"
      [Reflection.Assembly]::LoadFile($PSLib) 
      [Cmtest_lib.Methods]::IsNumber("8526")
    Example3:
      $CurrentLocation = Get-Location
      $PSLib = "$CurrentLocation\Cmtest_lib.dll"
      [Reflection.Assembly]::LoadFile($PSLib) 
      [Cmtest_lib.Methods]::Split_str_Ind("PCT8210-D97(RoHS)",'-,(,)',0)
    Example4:
      $CurrentLocation = Get-Location
      $PSLib = "$CurrentLocation\Cmtest_lib.dll"
      [Reflection.Assembly]::LoadFile($PSLib) 
      [Cmtest_lib.Methods]::Split_string("PCT8210-D97(RoHS)",'-,(,)')
	Example5:
      $CurrentLocation = Get-Location
      $PSLib = "$CurrentLocation\Cmtest_lib.dll"
      [Reflection.Assembly]::LoadFile($PSLib) 
      [Cmtest_lib.Methods]::UART_list()
	Example6:
      $CurrentLocation = Get-Location
      $PSLib = "$CurrentLocation\Cmtest_lib.dll"
      [Reflection.Assembly]::LoadFile($PSLib) 
      [Cmtest_lib.Methods]::Connect("COM6")
	Example7:
      $CurrentLocation = Get-Location
      $PSLib = "$CurrentLocation\Cmtest_lib.dll"
      [Reflection.Assembly]::LoadFile($PSLib) 
      [Cmtest_lib.Methods]::Send("COM6","123")
	Example8:
      $CurrentLocation = Get-Location
      $PSLib = "$CurrentLocation\Cmtest_lib.dll"
      [Reflection.Assembly]::LoadFile($PSLib) 
      [Cmtest_lib.Methods]::Disconnect("COM6")
	Example9:
      $CurrentLocation = Get-Location
      $PSLib = "$CurrentLocation\Cmtest_lib.dll"
      [Reflection.Assembly]::LoadFile($PSLib) 
      [Cmtest_lib.Methods]::Str_Contains("AAAbbb","aaa")
	Example10:
      $CurrentLocation = Get-Location
      $PSLib = "$CurrentLocation\Cmtest_lib.dll"
      [Reflection.Assembly]::LoadFile($PSLib) 
      [Cmtest_lib.Methods]::Str_Contains("AAAbbb","aaa")