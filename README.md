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
