# CMtest_lib
The Project using Powershell7.1 calling C# dll on Cmtest for factory test.
The project using  C# Net core 3.1 to build.
Powershell7.1.3 install step in Powersehll_install files.

The Project fun is:
  1.SUM : input int1 plus int2 out Sum_int.
  2.IsNumber : Input String , Input Split char[] , Out Split String.
 
 Example:
  PowerShell call Dll Step:
   $CurrentLocation = Get-Location
   $PSLib = "$CurrentLocation\Cmtest_lib.dll"
   [Reflection.Assembly]::LoadFile($PSLib) 
    
    Example1:
      [Cmtest_lib.Methods]::Sum(10,2)
    Example2:
      [Cmtest_lib.Methods]::IsNumber("8526")
